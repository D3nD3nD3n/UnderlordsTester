using System;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;
using static UnderlordsTracker.Structs;

namespace UnderlordsTracker
{
    class Addresses
    {
        private int serverOffset = 0xCED5D8;
        private int firstServerOffset = 0x390; //Round offset
        private int firstServerPlayerOffset = 0x1C8;//Player/unit info offset from round offset
        
        public Process gameProcess;
        public IntPtr serverAddress;
        public bool foundServer = false;

        private byte[] MoveOpcodeBytes = { 0x4D, 0x89, 0x41, 0x08 };
        private int MoveOpOffset = 0x17EFAF;
        
        private byte[] SwapOpcodeBytes = { 0x48, 0x89, 0x42, 0x08 };
        private int SwapOpOffset = 0x17EFA6;

        private byte[] BotOpcodeBytes = { 0x83, 0x7F, 0x0C, 0xFF }; // cmp dword ptr [rdi+0C], -01
        private int BotLogicOpOffset = 0x156853;

        private byte[] ItemOpcodeBytes = { 0x41, 0x89, 0x7E, 0x04 };
        private int ItemOpOffset = 0x17CCD5;

        private byte[] TickOpCodeBytes = { 0xF3, 0x05, 0x11, 0x8F, 0x94, 0x06, 0x00, 0x00 };
        private int TickOpOffset = 0xE48A0;

        private int[] PlayerXpValues = { 0, 1, 2, 4, 8, 16, 32, 56, 88, 128 };
        IntPtr NewHeroPtr = IntPtr.Zero;


        public Addresses()
        { 
            gameProcess = GetGameProcess();
            if (gameProcess != null)
            {
                ProcessModuleCollection modules = gameProcess.Modules;
                foreach (ProcessModule p in modules)
                {
                    if (p.ModuleName == "server.dll")
                    {
                        serverAddress = p.BaseAddress;
                    }
                    
                }
            }
        }


        public Process GetGameProcess()
        {
            try
            {
                var processes = Process.GetProcessesByName("underlords");
                if (processes.Length > 0)
                {
                    return processes[0];
                }
                throw new Exception("Client was not found.");
            }
            catch
            {
                return null;
            }
        }
        public bool CheckGameStatus()
        {
            if (GetGameProcess() == null)
                return false;
            else
                return true;
        }
        private IntPtr GetLayeredPointer(IntPtr ptr, int[] offset)//https://stackoverflow.com/questions/47481769/c-sharp-multi-level-pointers-memory-reading
        {
            IntPtr output = ptr;
            for (int i = 0; i < offset.Length - 1 ; i++)
            {
                output = IntPtr.Add(output, offset[i]);
                output = new IntPtr(BitConverter.ToInt64(MemoryApi.ReadMemoryPtr(gameProcess, output, 8, out _), 0));
                
            }
            output = IntPtr.Add(output, offset[offset.Length - 1]);
            return output;
        }

        public byte[] GetByteDistance(IntPtr location, IntPtr destination)
        {
            Int64 LocInt = location.ToInt64();
            Int64 DestInt = destination.ToInt64();
            UInt32 Bytes = 0;
            if (LocInt > DestInt)
            {
                Int64 difference = DestInt - LocInt;
                Bytes += (UInt32)difference;
            }
            else
            {
                Int64 difference = LocInt - DestInt;
                Bytes -= (UInt32)difference;
            }
            byte[] output = BitConverter.GetBytes(Bytes);
            return output;
        }

        public bool CreateHeroInjection()
        {
            
            bool ByteCountError = false;
            Byte[] write;
            Dictionary<string, IntPtr> Locations = new Dictionary<string, IntPtr>();
            Locations.Add("herofunc", IntPtr.Add(serverAddress, 0xF6AA0 - 5));
            Locations.Add("returntick", IntPtr.Add(serverAddress, 0xE48A0 + 8 - 5));
            Locations.Add("tickfunc", IntPtr.Add(serverAddress, 0xE48A0));

            IntPtr target = IntPtr.Subtract(serverAddress, 0x10000);
            int trycount = 1000;
            IntPtr newMem = IntPtr.Zero;
            while (newMem == IntPtr.Zero && trycount > 0)
            {
                trycount--;
                newMem = MemoryApi.MemoryAlloc(gameProcess, target, 0x100);
                target = IntPtr.Subtract(target, 0x10000);
            }
            if (newMem != IntPtr.Zero)
            {
                Assembly assembly = Assembly.GetExecutingAssembly(); //https://stackoverflow.com/questions/3314140/how-to-read-embedded-resource-text-file
                using (Stream stream = assembly.GetManifestResourceStream("UnderlordsTracker.TextFiles.AddHeroInjection.txt"))
                {
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        string line;
                        List<byte> code = new List<byte>();
                        while ((line = sr.ReadLine()) != null && !ByteCountError)
                        {
                            string[] split = line.Split('-');
                            split[0] = split[0].Replace(" ", "");
                            split[0] = split[0].Trim();
                            if (split[0].Contains("%"))
                            {
                                int byteOffset = code.Count;
                                string[] secondSplit = split[0].Split('%');
                                byte[] jumpDistance = GetByteDistance(IntPtr.Add(newMem, byteOffset), Locations[secondSplit[1]]);
                                code.Add(BitConverter.GetBytes(int.Parse(secondSplit[0], System.Globalization.NumberStyles.HexNumber))[0]);
                                code.AddRange(jumpDistance);
                            }
                            else
                            {
                                if (split[0].Length % 2 != 0)
                                {
                                    ByteCountError = true;
                                }
                                else
                                {
                                    for (int i = 0; i < split[0].Length / 2; i++)
                                    {
                                        code.Add(BitConverter.GetBytes(int.Parse(split[0].Substring(i * 2, 2), System.Globalization.NumberStyles.HexNumber))[0]);
                                    }
                                }
                            }

                        }
                        write = code.ToArray();
                    }
                }
                if (!ByteCountError)
                {
                    MemoryApi.WriteMemoryPtrBytes(gameProcess, newMem, write);
                    List<byte> code = new List<byte>();
                    code.Add(0xE9);
                    code.AddRange(GetByteDistance(Locations["tickfunc"], newMem - 5));
                    for(int i = 0; i < 3; i++)
                    {
                        code.Add(0x90);
                    }
                    MemoryApi.WriteMemoryPtrBytes(gameProcess, Locations["tickfunc"], code.ToArray());
                    NewHeroPtr = newMem;
                    return true;
                }
            }
            return false;
        }

        public bool HeroInjectionActive()
        {
            byte[] code = MemoryApi.ReadMemoryPtr(gameProcess, IntPtr.Add(serverAddress, TickOpOffset), 1, out _);
            if (code[0] == 0xE9)
            {
                code = MemoryApi.ReadMemoryPtr(gameProcess, IntPtr.Add(serverAddress, TickOpOffset + 1), 4, out _);
                int offset = BitConverter.ToInt32(code, 0);
                IntPtr testPtr = IntPtr.Add(serverAddress, TickOpOffset + 5 + offset);

                if (NewHeroPtr != testPtr)
                {
                    NewHeroPtr = testPtr;
                }
                return true;
            }
            else
                return false;
        }

#region GetAddresses
        public IntPtr GetUnitCountPtr(int player)
        {
            int[] offsets = { serverOffset, firstServerPlayerOffset + firstServerOffset, player * 0x8, 0x58 };

            return GetLayeredPointer(serverAddress, offsets);
        }
        public IntPtr GetRoundPtr()
        {
            int[] offsets = { serverOffset, firstServerOffset };

            return GetLayeredPointer(serverAddress, offsets);
        }

        public IntPtr GetUnitUniqueIDPtr(int player, int unitIndex)
        {
            int[] offsets = { serverOffset, firstServerPlayerOffset + firstServerOffset, (player * 0x8), 0x60, (unitIndex * 0x8), 0x0 };

            return GetLayeredPointer(serverAddress, offsets);
        }
        public IntPtr GetUnitIDPtr(int player, int unitIndex)
        {
            int[] offsets = { serverOffset, firstServerPlayerOffset + firstServerOffset, (player * 0x8), 0x60, (unitIndex * 0x8), 0x4 };

            return GetLayeredPointer(serverAddress, offsets);
        }
        public IntPtr GetUnitXPtr(int player, int unitIndex)
        {
            int[] offsets = { serverOffset, firstServerPlayerOffset + firstServerOffset, (player * 0x8), 0x60, (unitIndex * 0x8), 0x8 };
            
            return GetLayeredPointer(serverAddress, offsets);
        }
        public IntPtr GetUnitYPtr(int player, int unitIndex)
        {
            int[] offsets = { serverOffset, firstServerPlayerOffset + firstServerOffset, (player * 0x8), 0x60, (unitIndex * 0x8), 0xC };

            return GetLayeredPointer(serverAddress, offsets);
        }
        public IntPtr GetUnitLevelPtr(int player, int unitIndex)
        {
            int[] offsets = { serverOffset, firstServerPlayerOffset + firstServerOffset, (player * 0x8), 0x60, (unitIndex * 0x8), 0x10 };

            return GetLayeredPointer(serverAddress, offsets);
        }
        public IntPtr GetUnitKillsPtr(int player, int unitIndex)
        {
            int[] offsets = { serverOffset, firstServerPlayerOffset + firstServerOffset, (player * 0x8), 0x60, (unitIndex * 0x8), 0x24 };

            return GetLayeredPointer(serverAddress, offsets);
        }
        public IntPtr GetUnitSupplyCountPtr(int player, int unitIndex)
        {
            int[] offsets = { serverOffset, firstServerPlayerOffset + firstServerOffset, (player * 0x8), 0x60, (unitIndex * 0x8), 0x2C };

            return GetLayeredPointer(serverAddress, offsets);
        }
        public IntPtr GetPlayerLifePtr(int player)
        {
            int[] offsets = { serverOffset, firstServerPlayerOffset + firstServerOffset, (player * 0x8), 0x8 };

            return GetLayeredPointer(serverAddress, offsets);
        }
        public IntPtr GetPlayerGoldPtr(int player)
        {
            int[] offsets = { serverOffset, firstServerPlayerOffset + firstServerOffset, (player * 0x8), 0xC };

            return GetLayeredPointer(serverAddress, offsets);
        }
        public IntPtr GetPlayerLevelPtr(int player)
        {
            int[] offsets = { serverOffset, firstServerPlayerOffset + firstServerOffset, (player * 0x8), 0x10 };

            return GetLayeredPointer(serverAddress, offsets);
        }
        public IntPtr GetPlayerXPPtr(int player)
        {
            int[] offsets = { serverOffset, firstServerPlayerOffset + firstServerOffset, (player * 0x8), 0x14 };

            return GetLayeredPointer(serverAddress, offsets);
        }

        public IntPtr GetItemIDPtr(int player, int itemIndex)
        {
            int[] offsets = { serverOffset, firstServerPlayerOffset + firstServerOffset, (player * 0x8), 0x48, (0xC * itemIndex) };

            return GetLayeredPointer(serverAddress, offsets);
        }
        public IntPtr GetItemHolderPtr(int player, int itemIndex)
        {
            int[] offsets = { serverOffset, firstServerPlayerOffset + firstServerOffset, (player * 0x8), 0x48, 0x4 + (0xC * itemIndex) };

            return GetLayeredPointer(serverAddress, offsets);
        }
        public IntPtr GetOpMovePtr()
        {
            return IntPtr.Add(serverAddress, MoveOpOffset);
        }
        public IntPtr GetOpSwapPtr()
        {
            return IntPtr.Add(serverAddress, SwapOpOffset);
        }
        public IntPtr GetOpBotLogicPtr()
        {
            return IntPtr.Add(serverAddress, BotLogicOpOffset);
        }
        public IntPtr GetOpItemPtr()
        {
            return IntPtr.Add(serverAddress, ItemOpOffset);
        }
        public IntPtr GetBotLevelTest()
        {
            int[] offsets = { serverOffset, firstServerPlayerOffset + firstServerOffset, 0x8, 0x98, 0x178 };

            return GetLayeredPointer(serverAddress, offsets);
        }
        public IntPtr GetBotTierTest()
        {
            int[] offsets = { serverOffset, firstServerPlayerOffset + firstServerOffset, 0x8, 0x98, 0x17C };

            return GetLayeredPointer(serverAddress, offsets);
        }
        public IntPtr GetPausePtr()
        {
            int[] offsets = { serverOffset, 0x660 };

            return GetLayeredPointer(serverAddress, offsets);
        }
        #endregion

#region Hero/Item Get/Set
        public Hero GetHero(int player, int index)
        {
            Hero h;
            h.player = player;
            h.index = index;
            h.UID = BitConverter.ToInt32(MemoryApi.ReadMemoryPtr(gameProcess, GetUnitUniqueIDPtr(player, index), 4, out _), 0);
            h.HID = BitConverter.ToInt32(MemoryApi.ReadMemoryPtr(gameProcess, GetUnitIDPtr(player, index), 4, out _), 0);
            h.xPos = BitConverter.ToInt32(MemoryApi.ReadMemoryPtr(gameProcess, GetUnitXPtr(player, index), 4, out _), 0);
            h.yPos = BitConverter.ToInt32(MemoryApi.ReadMemoryPtr(gameProcess, GetUnitYPtr(player, index), 4, out _), 0);
            h.level = BitConverter.ToInt32(MemoryApi.ReadMemoryPtr(gameProcess, GetUnitLevelPtr(player, index), 4, out _), 0);
            h.kills = BitConverter.ToInt32(MemoryApi.ReadMemoryPtr(gameProcess, GetUnitKillsPtr(player, index), 4, out _), 0);
            return h;
        }
        public Item GetItem(int player, int index)
        {
            Item i;
            i.player = player;
            i.index = index;
            i.IID = BitConverter.ToInt32(MemoryApi.ReadMemoryPtr(gameProcess, GetItemIDPtr(player, index), 4, out _), 0);
            i.UID = BitConverter.ToInt32(MemoryApi.ReadMemoryPtr(gameProcess, GetItemHolderPtr(player, index), 4, out _), 0);
            return i;
        }

        public void SetHeroID(int player, int index, int newID)
        {
            MemoryApi.WriteMemoryPtrBytes(gameProcess, GetUnitIDPtr(player, index), BitConverter.GetBytes(newID));
            SetHeroSupplyCount(player, index, 1);

            for (int i = 91; i < 95; i++)
            {
                if(newID == i)
                {
                    SetHeroSupplyCount(player, index, 0);
                    break;
                }
            }
        }

        public void SetHeroPositionSmart(int player, int index, int xPos, int yPos)
        {
            if(player == 0)
            {
                yPos = 3 - yPos;
            }
            else
            {
                xPos = 7 - xPos;
                yPos -= 1;
            }
            MemoryApi.WriteMemoryPtrBytes(gameProcess, GetUnitXPtr(player, index), BitConverter.GetBytes(xPos));
            MemoryApi.WriteMemoryPtrBytes(gameProcess, GetUnitYPtr(player, index), BitConverter.GetBytes(yPos));
        }
        public void SetHeroPosition(int player, int index, int xPos, int yPos)
        {
            
            MemoryApi.WriteMemoryPtrBytes(gameProcess, GetUnitXPtr(player, index), BitConverter.GetBytes(xPos));
            MemoryApi.WriteMemoryPtrBytes(gameProcess, GetUnitYPtr(player, index), BitConverter.GetBytes(yPos));
        }
        public void SetHeroLevel(int player, int index, int newLevel)
        {
            MemoryApi.WriteMemoryPtrBytes(gameProcess, GetUnitLevelPtr(player, index), BitConverter.GetBytes(newLevel));
        }
        public void SetHeroKills(int player, int index, int kills)
        {
            MemoryApi.WriteMemoryPtrBytes(gameProcess, GetUnitKillsPtr(player, index), BitConverter.GetBytes(kills));
        }
        public void SetHeroSupplyCount(int player, int index, int count)
        {
            MemoryApi.WriteMemoryPtrBytes(gameProcess, GetUnitSupplyCountPtr(player, index), BitConverter.GetBytes(count));
        }

        public void SwapHeroes(Hero h1, Hero h2)
        {
            SetHeroPosition(h1.player, h1.index, h2.xPos, h2.yPos);
            SetHeroPosition(h2.player, h2.index, h1.xPos, h1.yPos);
        }

        public void SetItemID(int player, int index, int newID)
        {
            MemoryApi.WriteMemoryPtrBytes(gameProcess, GetItemIDPtr(player, index), BitConverter.GetBytes(newID));
        }
        public void SetItemHolder(int player, int index, int HeroUID)
        {
            MemoryApi.WriteMemoryPtrBytes(gameProcess, GetItemHolderPtr(player, index), BitConverter.GetBytes(HeroUID));
        }
        public void CreateHero(int player)
        {
            if (NewHeroPtr != IntPtr.Zero)
                MemoryApi.WriteMemoryPtrBytes(gameProcess, IntPtr.Add(NewHeroPtr, 0x8D), BitConverter.GetBytes(player));
        }
        #endregion

#region Game Get/Set
        public int GetPlayerLife(int player)
        {
            return BitConverter.ToInt32(MemoryApi.ReadMemoryPtr(gameProcess, GetPlayerLifePtr(player), 4, out _), 0);
        }
        public void SetPlayerLife(int player, int newLife)
        {
            MemoryApi.WriteMemoryPtrBytes(gameProcess, GetPlayerLifePtr(player), BitConverter.GetBytes(newLife));
        }
        public int GetPlayerGold(int player)
        {
            return BitConverter.ToInt32(MemoryApi.ReadMemoryPtr(gameProcess, GetPlayerGoldPtr(player), 4, out _), 0);
        }
        public void SetPlayerGold(int player, int newGold)
        {
            MemoryApi.WriteMemoryPtrBytes(gameProcess, GetPlayerGoldPtr(player), BitConverter.GetBytes(newGold));
        }
        public int GetPlayerLevel(int player)
        {
            return BitConverter.ToInt32(MemoryApi.ReadMemoryPtr(gameProcess, GetPlayerLevelPtr(player), 4, out _), 0);
        }
        public void SetBotShop(bool canShop)
        {
            if(canShop)
            {
                MemoryApi.WriteMemoryPtrBytes(gameProcess, GetBotLevelTest(), BitConverter.GetBytes(10));
                MemoryApi.WriteMemoryPtrBytes(gameProcess, GetBotTierTest(), BitConverter.GetBytes(99));
            }
            else
            {
                MemoryApi.WriteMemoryPtrBytes(gameProcess, GetBotLevelTest(), BitConverter.GetBytes(0));
                MemoryApi.WriteMemoryPtrBytes(gameProcess, GetBotTierTest(), BitConverter.GetBytes(0));
            }
        }
        public void SetPlayerLevel(int player, int newLevel)
        {
            MemoryApi.WriteMemoryPtrBytes(gameProcess, GetPlayerLevelPtr(player), BitConverter.GetBytes(newLevel));
            if(newLevel > 10)
            {
                MemoryApi.WriteMemoryPtrBytes(gameProcess, GetPlayerXPPtr(player), BitConverter.GetBytes(PlayerXpValues[9]));
            }
            else
            {
                MemoryApi.WriteMemoryPtrBytes(gameProcess, GetPlayerXPPtr(player), BitConverter.GetBytes(PlayerXpValues[newLevel - 1]));
            }

        }
        public int CurrentRound
        {
            get
            {
                return BitConverter.ToInt32(MemoryApi.ReadMemoryPtr(gameProcess, GetRoundPtr(), 4, out _), 0);
            }
            set
            {
                MemoryApi.WriteMemoryPtrBytes(gameProcess, GetRoundPtr(), BitConverter.GetBytes(value));
            }
        }
        public bool GamePaused
        {
            get
            {
                int i = BitConverter.ToInt32(MemoryApi.ReadMemoryPtr(gameProcess, GetPausePtr(), 4, out _), 0);
                if (i == 1)
                    return true;
                else
                    return false;
            }
            set
            {
                if (value)
                    MemoryApi.WriteMemoryPtrBytes(gameProcess, GetPausePtr(), BitConverter.GetBytes(1));
                else
                    MemoryApi.WriteMemoryPtrBytes(gameProcess, GetPausePtr(), BitConverter.GetBytes(0));
            }
        }
        #endregion

        #region OpCodes
        public bool MatchingOpCodes()
        {
            byte[] check = MemoryApi.ReadMemoryPtr(gameProcess, GetOpMovePtr(), MoveOpcodeBytes.Length, out _);
            if (!MatchingByteArray(check, MoveOpcodeBytes) && !MatchingByteArray(check, NoOpCode(MoveOpcodeBytes.Length)))
                return false;
            check = MemoryApi.ReadMemoryPtr(gameProcess, GetOpSwapPtr(), SwapOpcodeBytes.Length, out _);
            if (!MatchingByteArray(check, SwapOpcodeBytes) && !MatchingByteArray(check, NoOpCode(SwapOpcodeBytes.Length)))
                return false;
            check = MemoryApi.ReadMemoryPtr(gameProcess, GetOpBotLogicPtr(), BotOpcodeBytes.Length, out _);
            if (!MatchingByteArray(check, BotOpcodeBytes) && !MatchingByteArray(check, NoOpCode(BotOpcodeBytes.Length)))
                return false;
            check = MemoryApi.ReadMemoryPtr(gameProcess, GetOpItemPtr(), ItemOpcodeBytes.Length, out _);
            if (!MatchingByteArray(check, ItemOpcodeBytes) && !MatchingByteArray(check, NoOpCode(ItemOpcodeBytes.Length)))
                return false;
            return true;
        }
        private bool MatchingByteArray(byte[] a1, byte[] a2)
        {
            if(a1.Length == a2.Length)
            {
                for(int i = 0; i < a1.Length; i++)
                {
                    if (a1[i] != a2[i])
                        return false;
                }
                return true;
            }
            return false;
        }
        private void SetOpCode(IntPtr loc, byte[] code, bool Active)
        {
            byte[] check = MemoryApi.ReadMemoryPtr(gameProcess, loc, code.Length, out _);
            if (MatchingByteArray(check, code) && !Active)
            {
                MemoryApi.WriteMemoryPtrBytes(gameProcess, loc, NoOpCode(code.Length));
            }
            else if (MatchingByteArray(check, NoOpCode(code.Length)) && Active)
            {
                MemoryApi.WriteMemoryPtrBytes(gameProcess, loc, code);
            }
        }
        
        private bool IsOpCodeActive(IntPtr loc, int length)
        {
            byte[] check = MemoryApi.ReadMemoryPtr(gameProcess, loc, length, out _);
            if (MatchingByteArray(check, NoOpCode(length)))
                return false;
            else
                return true;
        }

        
        public bool MoveOpCodeActive
        {
            get
            {
                return IsOpCodeActive(GetOpMovePtr(), MoveOpcodeBytes.Length);
            }
            set
            {
                SetOpCode(GetOpMovePtr(), MoveOpcodeBytes, value);
            }
        }

        public bool SwapOpCodeActive
        {
            get
            {
                return IsOpCodeActive(GetOpSwapPtr(), SwapOpcodeBytes.Length);
            }
            set
            {
                SetOpCode(GetOpSwapPtr(), SwapOpcodeBytes, value);
            }
        }


        public bool BotOpCodeActive
        {
            get
            {
                return IsOpCodeActive(GetOpBotLogicPtr(), BotOpcodeBytes.Length);
            }
            set
            {
                SetOpCode(GetOpBotLogicPtr(), BotOpcodeBytes, value);
            }
        }

        public bool ItemOpCodeActive
        {
            get
            {
                return IsOpCodeActive(GetOpItemPtr(), ItemOpcodeBytes.Length);
            }
            set
            {
                SetOpCode(GetOpItemPtr(), ItemOpcodeBytes, value);
            }
        }
        public int LockedBoard
        {
            get
            {
                if (MoveOpCodeActive && SwapOpCodeActive && BotOpCodeActive && ItemOpCodeActive)
                {
                    return 0;
                }
                else if (!MoveOpCodeActive && !SwapOpCodeActive && !BotOpCodeActive && !ItemOpCodeActive)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            set
            {
                if(value == 0)
                {
                    MoveOpCodeActive = true;
                    SwapOpCodeActive = true;
                    BotOpCodeActive = true;
                    ItemOpCodeActive = true;
                    SetBotShop(true);
                }
                else if (value == 1)
                {
                    MoveOpCodeActive = false;
                    SwapOpCodeActive = false;
                    BotOpCodeActive = false;
                    ItemOpCodeActive = false;
                    SetBotShop(false);
                }
            }
        }

        private byte[] NoOpCode(int length)
        {
            byte[] output = new byte[length];
            for(int i = 0; i < length; i++)
            {
                output[i] = 0x90;
            }
            return output;
        }
        #endregion
    }

}

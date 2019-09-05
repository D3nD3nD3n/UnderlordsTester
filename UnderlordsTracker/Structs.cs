using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderlordsTracker
{
    static class Structs
    {
        public interface IDraggable
        {
            int GetID();
            int GetPlayer();
        }
        public struct Hero : IDraggable, IEquatable<Hero>
        {
            public int player;
            public int index;
            public int UID;
            public int HID;
            public int xPos;
            public int yPos;
            public int level;
            public int kills;

            public bool Equals(Hero other)
            {
                if (player != other.player)
                    return false;
                if (index != other.index)
                    return false;
                if (UID != other.UID)
                    return false;
                if (HID != other.HID)
                    return false;
                if (xPos != other.xPos)
                    return false;
                if (yPos != other.yPos)
                    return false;
                if (level != other.level)
                    return false;
                else
                    return true;
            }
            public override int GetHashCode()
            {
                int returnval = 0;
                returnval += UID * 32000;
                returnval += HID * 320;
                returnval += player * 160;
                returnval += xPos * 20;
                returnval += (yPos + 1) * 4;
                returnval += level;
                return returnval;
            }

            public int GetID()
            {
                return HID;
            }
            public int GetPlayer()
            {
                return player;
            }
        }
        public struct Item : IDraggable
        {
            public int player;
            public int index;
            public int IID;
            public int UID;

            public int GetID()
            {
                return IID;
            }
            public int GetPlayer()
            {
                return player;
            }
        }
    }
}

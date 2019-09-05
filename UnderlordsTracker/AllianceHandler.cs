using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UnderlordsTester
{
    class AllianceHandler
    {
        Dictionary<string, string> DACtoULDict = new Dictionary<string, string>();
        Dictionary<int, string> HIDtoAllianceDict = new Dictionary<int, string>();
        Dictionary<string, int>[] Alliances = new Dictionary<string, int>[2];
        Dictionary<int, int>[] CurrentHeroes = new Dictionary<int, int>[2];
        
        public AllianceHandler(Dictionary<string, string> DACConversionDict)
        {
            DACtoULDict = DACConversionDict;

            FillHIDDict();
            Alliances[0] = new Dictionary<string, int>();
            Alliances[1] = new Dictionary<string, int>();
            CurrentHeroes[0] = new Dictionary<int, int>();
            CurrentHeroes[1] = new Dictionary<int, int>();
        }
        private void FillHIDDict()
        {

            if (!File.Exists(@"TextFiles\\HeroAlliances.txt"))
            {
                File.WriteAllText("TextFiles\\HeroAlliances.txt", Properties.Resources.HeroAlliances);
            }
            if (File.Exists(@"TextFiles\\HeroAlliances.txt"))
            {
                using (StreamReader sr = new StreamReader(@"TextFiles\\HeroAlliances.txt"))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        string[] split = s.Split(',');
                        HIDtoAllianceDict.Add(int.Parse(split[0]), split[1]);
                    }
                }
            }
            else
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                using (Stream stream = assembly.GetManifestResourceStream("UnderlordsTracker.TextFiles.HeroAlliances.txt"))
                {
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        string s;
                        while ((s = sr.ReadLine()) != null)
                        {
                            string[] split = s.Split(',');
                            HIDtoAllianceDict.Add(int.Parse(split[0]), split[1]);
                        }
                    }
                }
            }
        }
        
        public void AddAlliance(int player, int HID)
        {
            if (CurrentHeroes[player].ContainsKey(HID))
            {
                CurrentHeroes[player][HID]++;
            }
            else
            {
                CurrentHeroes[player].Add(HID, 1);
                if (HIDtoAllianceDict[HID].Length > 1)
                {
                    string[] keywords = HIDtoAllianceDict[HID].Split(' ');
                    foreach (string s in keywords)
                    {
                        string convertedKeyword = ConvertToUnderlordsAlliance(s);
                        if (Alliances[player].ContainsKey(convertedKeyword))
                        {
                            Alliances[player][convertedKeyword]++;
                        }
                        else
                        {
                            Alliances[player].Add(convertedKeyword, 1);
                        }

                    }
                }
            }
        }

        public void RemoveAlliance(int player, int HID)
        {
            if (CurrentHeroes[player].ContainsKey(HID))
            {
                CurrentHeroes[player][HID]--;
            }
            if(CurrentHeroes[player][HID] == 0)
            {
                CurrentHeroes[player].Remove(HID);
                if (HIDtoAllianceDict[HID].Length > 1)
                {
                    string[] keywords = HIDtoAllianceDict[HID].Split(' ');
                    foreach (string s in keywords)
                    {
                        string convertedKeyword = ConvertToUnderlordsAlliance(s);
                        if (Alliances[player].ContainsKey(convertedKeyword))
                        {
                            Alliances[player][convertedKeyword]--;
                        }
                        if (Alliances[player][convertedKeyword] == 0)
                        {
                            Alliances[player].Remove(convertedKeyword);
                        }
                    }
                }
            }
        }

        public void ClearAlliances()
        {
            Alliances[0].Clear();
            Alliances[1].Clear();
        }

        public string GetAlliances(int player)
        {
            string s = "";
            foreach(KeyValuePair<string, int> kv in Alliances[player])
            {
                s += string.Format("{0}:{1}\n", kv.Key, kv.Value);
            }
            return s;
        }

        private string ConvertToUnderlordsAlliance(string s)
        {

            if (DACtoULDict.ContainsKey(s))
            {
                return DACtoULDict[s];
            }
            else
                return s;
        }
    }
}

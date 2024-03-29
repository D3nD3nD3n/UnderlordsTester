﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace UnderlordsTester
{
    class NameTranslator
    {
        Dictionary<string, string> InternalToTranslatedDict = new Dictionary<string, string>();
        Dictionary<int, string> IDToInternalDict = new Dictionary<int, string>();
        Dictionary<string, int> TranslatedToIDDict = new Dictionary<string, int>();
        Dictionary<string, string> DACtoULDict = new Dictionary<string, string>();

        public NameTranslator()
        {
            FillDictionaries();
        }
        private void FillDictionaries()
        {
            if (!File.Exists(@"TextFiles\\Translation.txt"))
            {
                File.WriteAllText("TextFiles\\Translation.txt", Properties.Resources.Translation);
            }
            if (File.Exists(@"TextFiles\\Translation.txt"))
            {
                using (StreamReader sr = new StreamReader(@"TextFiles\\Translation.txt"))
                {
                    readTranslation(sr);
                }
            }
            else
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                using (Stream stream = assembly.GetManifestResourceStream("UnderlordsTracker.TextFiles.Translation.txt"))
                {
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        readTranslation(sr);
                    }
                }
            }

            if (!File.Exists(@"TextFiles\\IDtoName.txt"))
            {
                File.WriteAllText("TextFiles\\IDtoName.txt", Properties.Resources.IDtoName);
            }
            if (File.Exists(@"TextFiles\\IDtoName.txt"))
            {
                using (StreamReader sr = new StreamReader(@"TextFiles\\IDtoName.txt"))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        string[] split = s.Split(',');
                        IDToInternalDict.Add(int.Parse(split[0]), split[1]);
                    }
                }
            }
            else
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                using (Stream stream = assembly.GetManifestResourceStream("UnderlordsTracker.TextFiles.IDtoName.txt"))
                {
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        string s;
                        while ((s = sr.ReadLine()) != null)
                        {
                            string[] split = s.Split(',');
                            IDToInternalDict.Add(int.Parse(split[0]), split[1]);
                        }
                    }
                }
            }

            foreach(KeyValuePair<int, string> kv in IDToInternalDict)
            {
                TranslatedToIDDict.Add(GetTranslatedName(kv.Key), kv.Key);
            }
        }
        public void readTranslation(StreamReader sr)
        {
            string s;
            char tab = '\u0009';
            while ((s = sr.ReadLine()) != null)
            {

                string clean = s.Replace(tab.ToString(), "");
                if (clean.Length > 0)
                {
                    string[] filter = { "\"\"" };
                    string[] split = clean.Split(filter, StringSplitOptions.None);
                    if (split.Length == 2)
                    {
                        split[0] = split[0].TrimStart('\"');
                        split[1] = split[1].Trim('\"');


                        if (split[0].Contains("dac_unit_") || split[0].Contains("dac_hero_name") || split[0].Contains("dac_name"))
                        {
                            if (!split[0].Substring(split[0].Length - 4).Equals("lore") && !split[0].Substring(split[0].Length - 4).Equals("desc"))
                            {
                                InternalToTranslatedDict.Add(split[0], split[1] + "h");
                            }
                        }
                        else if (split[0].Contains("dac_item"))
                        {
                            if (!split[0].Substring(split[0].Length - 4).Equals("lore") && !split[0].Substring(split[0].Length - 4).Equals("desc"))
                            {
                                InternalToTranslatedDict.Add(split[0], split[1] + "i");
                            }
                        }

                        else if (split[0].Contains("DAC_Synergy_"))
                        {
                            if (!split[0].Contains("DAC_Synergy_Desc") && !split[0].Contains("dac_synergy_popup"))
                                DACtoULDict.Add(split[0].Substring(12).ToLower(), split[1]);
                        }

                    }
                }
            }
        }

        public string GetTranslatedName(int ID)
        {
            if (IDToInternalDict.ContainsKey(ID))
            {
                string s = IDToInternalDict[ID];
                if (InternalToTranslatedDict.ContainsKey(s))
                {
                    return InternalToTranslatedDict[s];
                }
            }
            return "Missing String";
        }
        public int GetID(string TranslatedName)
        {
            if (TranslatedToIDDict.ContainsKey(TranslatedName))
                return TranslatedToIDDict[TranslatedName];
            else
                return 0;
        }

        public Dictionary<string, string> GetDACtoULDict()
        {
            return DACtoULDict;
        }
        public string[] GetHeroList()
        {
            List<string> strings = new List<string>();
            foreach (KeyValuePair<string,int> kv in TranslatedToIDDict)
            {
                if(kv.Value < 1000)
                {
                    strings.Add(kv.Key.Substring(0, kv.Key.Length - 1));
                }
            }
            strings.Sort();
            return strings.ToArray();
        }
        public string[] GetItemList()
        {
            List<string> strings = new List<string>();
            foreach (KeyValuePair<string, int> kv in TranslatedToIDDict)
            {
                if (kv.Value > 1000)
                {
                    strings.Add(kv.Key.Substring(0, kv.Key.Length - 1));
                }
            }
            strings.Sort();
            return strings.ToArray();
        }

    }
}

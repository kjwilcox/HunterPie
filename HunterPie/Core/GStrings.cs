﻿using System;
using System.Xml;
using System.IO;
using HunterPie.Logger;
using System.Text;

namespace HunterPie.Core {
    class GStrings {
        static private XmlDocument Translations = new XmlDocument();

        public static void InitStrings(string LangXml) {
            LoadTranslationXML(LangXml);
        }

        private static void LoadTranslationXML(string LangXML) {
            try {
                Translations.Load(LangXML);
                Debugger.Warn($"Loaded {Translations.DocumentElement.Attributes["lang"]?.Value ?? "Unknown language"} game strings");
            } catch(Exception err) {
                Debugger.Error(err);
                Debugger.Error($"Failed to load {LangXML}");
                LoadTranslationXML(@"Languages\en-us.xml");
            }
        }

        public static string GetMantleNameByID(int ID) {
            XmlNode Mantle = Translations.SelectSingleNode($"//Strings/Mantles/Mantle[@ID='{ID}']");
            return Mantle?.Attributes["Name"].Value;
        }

        public static string GetWeaponNameByID(int ID) {
            XmlNode Weapon = Translations.SelectSingleNode($"//Strings/Weapons/Weapon[@ID='{ID}']");
            return Weapon?.Attributes["Name"].Value;
        }

        public static string GetMonsterNameByID(string ID) {
            XmlNode Monster = Translations.SelectSingleNode($"//Strings/Monsters/Monster[@ID='{ID}']");
            return Monster?.Attributes["Name"].Value;
        }

        public static string GetFertilizerNameByID(int ID) {
            XmlNode Fertilizer = Translations.SelectSingleNode($"//Strings/Fertilizers/Fertilizer[@ID='{ID}']");
            return Fertilizer?.Attributes["Name"].Value;
        }

        public static string GetStageNameByID(int ID) {
            XmlNode Stage = Translations.SelectSingleNode($"//Strings/Stages/Stage[@ID='{ID}']");
            return Stage?.Attributes["Name"].Value;
        }

    }
}

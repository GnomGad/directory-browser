using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace DirectoryBrowser
{
    public class Constants
    {
        public static string PathSystemLanguage_xml = @"SystemLanguage.xml";
        public static string PathLanguages_xml = @"Languages.xml";
        public static XmlLanguage XMLLanguage = null;
    }
    /// <summary>
    /// Класс как структура, которая содержит в себе наименования, для изменения ленгвича
    /// </summary>
    [Serializable]
    public class XmlLanguage
    {
        public string Language { get; set; }
        public string FormDirectoryBrowser { get; set; }

        public XmlLanguage()
        {

        }
        /*
        public XmlLanguage(string Language, string FormDirectoryBrowser)
        {
            this.Language = Language;
            this.FormDirectoryBrowser = FormDirectoryBrowser;
        }*/
    }
    /// <summary>
    /// Класс для путей
    /// </summary>
    [Serializable]
    public class SysytemLanguages
    {
        public string[] Path { get; set; }

        public SysytemLanguages()
        {

        }
        public SysytemLanguages(string[] Path)
        {
            this.Path = Path;
        }
    }


    /// <summary>
    /// Содержит методы для работы с XmlLanguage и SysytemLanguages
    /// </summary>
    public class Language
    {
        XmlSerializer formatterLanguageXml = new XmlSerializer(typeof(XmlLanguage));
        XmlSerializer formatterLanguages = new XmlSerializer(typeof(SysytemLanguages));

        public XmlLanguage languageXml = new XmlLanguage();
        public SysytemLanguages sysytemLanguages = new SysytemLanguages();




        public void Test()
        {

            FirstInitSysytemLanguages();
            FirstInitXmlSerializer();
        }

        public SysytemLanguages DeserializeSysytemLanguages()
        {
            using (FileStream fs = new FileStream(Constants.PathLanguages_xml, FileMode.OpenOrCreate))
            {
                SysytemLanguages NewSysLangs = (SysytemLanguages)formatterLanguages.Deserialize(fs);
                return NewSysLangs;

            }
            
        }
        public XmlLanguage DeserializeXmSystemlLanguage()//траблы с читкой
        {
            using (FileStream fs = new FileStream(Constants.PathSystemLanguage_xml, FileMode.OpenOrCreate))
            {
                XmlLanguage NewSysLangs = (XmlLanguage)formatterLanguages.Deserialize(fs);
                return NewSysLangs;

            }
        }
        public XmlLanguage DeserializeXmllLanguage(string Path)
        {
            using (FileStream fs = new FileStream(Path, FileMode.OpenOrCreate))
            {
                XmlLanguage NewSysLangs = (XmlLanguage)formatterLanguages.Deserialize(fs);
                return NewSysLangs;

            }
        }


        // FirstInit нужны что бы заюзать для старта системы, или что бы починить систему
        /// <summary>
        /// FirstInit ибудет напрямую обращаться к методам с префиксом Info
        /// </summary>
        public void FirstInitSysytemLanguages()
        {
            using (FileStream fs = new FileStream(Constants.PathLanguages_xml, FileMode.Create))
            {
                formatterLanguages.Serialize(fs, InfoStandartSysytemLanguages());

                Console.WriteLine("Объект сериализован");
            }
        }
        /// <summary>
        /// FirstInit ибудет напрямую обращаться к методам с префиксом Info
        /// </summary>
        public void FirstInitXmlSerializer()
        {
            using (FileStream fs = new FileStream(Constants.PathSystemLanguage_xml, FileMode.Create))
            {
                formatterLanguageXml.Serialize(fs, InfoConstantsXMLLanguage());

                Console.WriteLine("Объект сериализован");
            }
        }
        
        // выдают инфо  один переменную, второй стандарт
        /// <summary>
        /// Что бы задать данные нужно вначале заполнить languagexml что бы его потом передать в фирст инит
        /// </summary>
        /// <returns></returns>
        public XmlLanguage InfoConstantsXMLLanguage()
        { 
            XmlLanguage language = new XmlLanguage();
            language= languageXml;
            return language;
        }
        public SysytemLanguages InfoStandartSysytemLanguages()
        {
            
            SysytemLanguages Sysyemlanguages = new SysytemLanguages();
            string[] kek = { Constants.PathLanguages_xml};
            Sysyemlanguages.Path = kek;
            return Sysyemlanguages;
        }


        /// <summary>
        /// Установка дефолтных значений в классе
        /// </summary>
        /// <param name="xml"></param>
        public void SetlanguageXml(XmlLanguage xml)
        {
            this.languageXml = xml;
        }
        /// <summary>
        /// Установка дефолтных значений в классе
        /// </summary>
        /// <param name="xml"></param>
        public void SetsysytemLanguages(SysytemLanguages xml)
        {
            this.sysytemLanguages = xml;
        }


    }

}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Config_xml_reader
{
    static class Settings
    {

        private static readonly string[] resolutions = {"640x480", "960x540", "1024x600", "1280x720", "1440x720", "1920x1080"};

        private static string resolution;
        public static string Resolution
        {
            get => resolution;
            set
            {
                    if (resolutions.Contains(value)) resolution = value;
                    else
                        throw new ArgumentException("Invalid screen-resolution value");
            }
        }


        private static int gamma;
        public static int Gamma
        {
            get => gamma;
            set
            {
                if (value > 0 && value <= 100) gamma = value;
                else
                    throw new ArgumentException("Invalid gamma value");
            }
        }


        private static int fps;
        public static int FPS
        {
            get => fps;
            set 
            {
                if (value == 30 || value == 60 || value == 120) fps = value;
                else
                    throw new ArgumentException("Invalid FPS value");
            }
        }

        public static string Vsinch { get; set; }

        static Settings()
        {
            XmlDocument XmlDoc = new XmlDocument();
            string[] allfiles = Directory.GetFiles(@"D:\Study\Workflow\С#\homeworks\Config_xml_reader\Configurations");

            foreach (string filepath in allfiles)
            {
                if (filepath.Contains(Game.Name.ToString())) //Содержит ли путь название игры?
                {
                    XmlDoc.Load(filepath);
                    XmlElement RootElement = XmlDoc.DocumentElement;

                    foreach (XmlNode xnode in RootElement)
                    {
                        XmlNode attr = xnode.Attributes.GetNamedItem("name");

                        foreach (XmlNode childnode in xnode.ChildNodes)
                        {
                            if (childnode.Name == "resolution") Resolution = childnode.InnerText;
                            if (childnode.Name == "gamma") Gamma = int.Parse(childnode.InnerText);
                            if (childnode.Name == "fps") FPS = int.Parse(childnode.InnerText);
                            if (childnode.Name == "vsinch")
                            {
                                switch(bool.Parse(childnode.InnerText))
                                {
                                    case true: Vsinch = "вкл.";
                                        break;
                                    case false: Vsinch = "откл.";
                                        break;
                                }
                            }
                        }
                    }
                }
            }
        }       
    }
}

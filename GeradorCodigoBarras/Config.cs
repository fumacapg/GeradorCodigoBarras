using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace GeradorCodigoBarras
{
    public static class Config
    {
        static Config()
        {
            Load();
        }
        public static string Valor { get; set; }
        public static string Sequecial { get; set; }
        public static string IP { get; set; }
        public static string Porta { get; set; }
        public static string Etiqueta { get; set; }
        public static string Delay { get; set; }


        public static void Salvar()
        {
            try
            {
                XmlTextWriter writer = new XmlTextWriter("Config.xml", System.Text.Encoding.UTF8);
                writer.WriteStartDocument(true);
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 2;
                writer.WriteStartElement("Config");
                writer.WriteStartElement("Valor");
                writer.WriteString(Valor);
                writer.WriteEndElement();
                writer.WriteStartElement("Sequencial");
                writer.WriteString(Sequecial);
                writer.WriteEndElement();
                writer.WriteStartElement("IP");
                writer.WriteString(IP);
                writer.WriteEndElement();
                writer.WriteStartElement("Porta");
                writer.WriteString(Porta);
                writer.WriteEndElement();
                writer.WriteStartElement("Etiqueta");
                writer.WriteString(Etiqueta);
                writer.WriteEndElement();
                writer.WriteStartElement("Delay");
                writer.WriteString(Delay);
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static void Load()
        {
            XDocument doc = XDocument.Load("Config.xml");

            foreach (XElement el in doc.Root.Elements())
            {


                switch (el.Name.ToString())
                {
                    case "Valor":
                        Valor = el.Value;
                        break;
                    case "Sequencial":
                        Sequecial = el.Value;
                        break;
                    case "IP":
                        IP = el.Value;
                        break;
                    case "Porta":
                        Porta = el.Value;
                        break;
                    case "Etiqueta":
                        Etiqueta = el.Value;
                        break;
                    case "Delay":
                        Delay = el.Value;
                        break;
                }
            }
        }
    }   
}

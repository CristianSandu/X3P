using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.Runtime.Serialization;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO.Compression;

namespace myx3p
{
    class ExtractXML

    {
        /*
        string zipPath = "1-euro-star.x3p";
        string extractPath = "C:\\Users\\CristianSandu\\Desktop\\X3P\\MyX3P\\myx3p\\myx3p\\bin\\Debug\\" + "1-euro-star.xml";
        ZipArchive archive = ZipFile.OpenRead(zipPath);
            foreach (ZipArchiveEntry entry in archive.Entries)
            {
                if (entry.FullName.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
                {
                    entry.ExtractToFile(extractPath, true);
                    XmlDocument doc = new XmlDocument();
        doc.Load(extractPath );
                    String s = System.IO.File.ReadAllText(extractPath);
        XmlElement root = doc.DocumentElement;

        XmlReader rdr = XmlReader.Create(new System.IO.StringReader(s));
                    while (rdr.Read())
                    {
                        if (rdr.NodeType == XmlNodeType.Element)
                        {
                            Console.WriteLine(rdr.LocalName);
                        }

                    // extractDataIntoObject(doc);
                }
         
            }
            //Console.WriteLine(archive.Entries);
            Console.Read();
    }
    
        private static void extractDataIntoObject(XmlDocument doc)
        {
            string xpath = "sog";
            var nodes = doc.SelectNodes(xpath);


            /*
            foreach (XmlNode node in doc.DocumentElement) {
                String name = node.Attributes["Name"].Value;
                Console.WriteLine(name);
                foreach (XmlNode child in node.ChildNodes) {
                    Console.WriteLine("\t\t" + child.Value);
                }
            }
            */


    


         
}

    }

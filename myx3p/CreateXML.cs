using System;
using System.IO;
using System.Xml.Serialization;

namespace myx3p
{
    class CreateXML
    {
        private ISO5436_2Type iso5436_2; //The only global element: The root node
        private XmlSerializer serializer;
        private StreamWriter stream;
        private HdrFields fields;
        private String destinationFile = "test.xml";



        public CreateXML(HdrFields fields)
        {
            this.fields = fields;
           
            this.iso5436_2 = new ISO5436_2Type { Record1 = new Record1(fields).getRecord(), Record2 = new Record2(fields).getRecord(), Record3 = new Record3().getRecord(), Record4 = new Record4().getRecord(), VendorSpecificID = new VendorSpecificID().getid() };
            this.serializer = new XmlSerializer(typeof(ISO5436_2Type));
            this.stream = new StreamWriter(destinationFile);
            serializer.Serialize(stream, iso5436_2);
            stream.Close();
            
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myx3p
{
    /* This is an extension hook for vendor specific data formats derived from ISO5436_2_XML
     This tag contains a vendor specific ID which is the URL of the vendor.It does not need to be valid
     but it must be worldwide unique!Example: http://www.example-inc.com/myformat
     */
    class VendorSpecificID
    {
        private String id = "http://www.di.univr.it/?ent=iniziativa&id=7289";

        public VendorSpecificID()
        {
          
        }

        public String getid()
        {
            return id;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myx3p
{
    /*
                            An URI pointing to an external ascii file
                            containting an MD5 digest with a 32 byte
                            hexadecimal MD5Checksum of the whole XML-file
                            and its filename as produced by the unix command
							"md5sum". The checksum can be calculated by the
                            unix command "md5sum main.xml &gt;md5checksum.hex"
							and checked by the command "md5sum -c
							md5checksum.hex". Default name of the checksum
							file is "md5checksum.hex".
     */
    class Record4
    {
        private String checksumFilePath = "md5checksum.hex";
        private Record4Type record;

        public Record4()
        {
            this.record = new Record4Type { ChecksumFile = checksumFilePath };
        }

        public Record4Type getRecord()
        {
            return this.record;
        }
    }
}

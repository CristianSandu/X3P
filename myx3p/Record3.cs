using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace myx3p
{
    //Record 3 contains the measured data.
    //The data list can be organised as an unordered list or as a 1,2 or 3D matrix

    //Use Matrix to define the matrix organisation of the data list.A matrix does also specify
    //the topography of datapoints.That means point that are neighbours in the matrix are
    //also neighbours in space.See <xsd:List></xsd:List>for unordered data sets.

    //A list does specify an unordered data set like a point cloud which does not contain
    //topologic information.
    class Record3
    {

        private Record3Type record;

        // D for DataList, M for Matrix 
        private String choice = "D";
       /////////////////////////////////////   List /////////////////////////////////////////
        // ListDimension
        private ulong listDimension = (ulong) 1500;

        // Datum for ListDataType 
        String[] Datum = {"0.1", "0.1", "0.1",
                         "0.1", "0.1", "0.1",
                         "0.1", "0.1", "0.1" };
        //////////////////////////////////  Matrix  /////////////////////////////////////////////
        //Matrix Dimensions x, y, z
        private ulong sizeX = (ulong)780;
        private ulong sizeY = (ulong)780;
        private ulong sizeZ = (ulong)1;

        // path relativo del file binario
        private string binaryFilePath = "C:\\Users\\CristianSandu\\Desktop\\Test_h_firma";
        // path dei punti validi della matrice se esso esiste altrimenti tutti sono validi
        private string validPointsLink = "";





        // costruttore
        public Record3() {
            record = new Record3Type { Item = setItem(choice), Item1 = setItem1(choice) };
        }
        // getter dell'oggetto
        public Record3Type getRecord()
        {
            return this.record;
        }

        // Se è una lista ritorna la sua dimensione se è una matrice setta le dimensioni della matrice 
        public Object setItem(String choice)
        {
            if (choice.Equals("D")) return listDimension;
            // Defines the size of the 3 dimensions of the data matrix.
            else return new MatrixDimensionType { SizeX = sizeX, SizeY = sizeY, SizeZ = sizeZ };
        }


        /* DataListType =  Data list is ordered like specified in
            DataOrder: Z-Index is empty(only one sample
            per pixel) X is fastest index, Y is slower,
            Z is slowest:
            (x1, y1),(x2, y1),(x3, y1),(x4, y1),(x1, y2)...
            */
        //DataLinkType = Link specification to an external binary data file.
        public Object setItem1(String choice)
        {
            if (choice.Equals("D")) return new DataListType { Datum = Datum };
            //Defines a Link to a binary data file and a binary file containing the information about valid points.
            else return new DataLinkType { MD5ChecksumPointData = setMD5ChecksumPointData(), MD5ChecksumValidPoints = setMD5ChecksumValidPoints(), PointDataLink = setPointDataLink() , ValidPointsLink = setValidPointsLink() };
        }


        /*
                            Relative filename in unix notation to a binary
							file that contains a packed array of bools. Each
							element that is true corresponds to a valid data
							point in the binary point data file.

							If this tag does not exist, all points are valid
							except for floating point numbers of the special
							value "NaN" (Not a Number). 
         */
        public string setValidPointsLink()
        {
            return validPointsLink;
        }


        //Relative filename in unix notation to a binary file with point data.Data can be specified
        //directly in the xml file or with a link be stored in an external binary file.The Binary
        //file has the same organisation as the DataList and has the datatypes specified in the axis description.
        private string setPointDataLink()
        {
            return binaryFilePath;
        }
        /*
                             An MD5Checksum of the valid points file like
                            calculated by the unix command "md5sum". It
                            consists of 32 hexadecimal digits.The binary
                            representation is a 128 bit number.
         */
        private byte[] setMD5ChecksumValidPoints()
        {
            if (validPointsLink.Equals(""))
                return new byte[16];
            else {
                // calculate MD5 checksum
                String checksum = CalculateMD5(validPointsLink);
                byte[] key = new byte[16];
                for (int i = 0; i < 16; i += 2)
                {
                    byte[] unicodeBytes = BitConverter.GetBytes(checksum[i % checksum.Length]);
                    Array.Copy(unicodeBytes, 0, key, i, 2);
                }
                return key;
            }
        }
        /*
                            An MD5Checksum of the point data file like
                             calculated by the unix command "md5sum". It
                            consists of 32 hexadecimal digits.The binary
                            representation is a 128 bit number.
         */
        public byte[] setMD5ChecksumPointData()
        {
            // calculate MD5 checksum
            String checksum = CalculateMD5(binaryFilePath);
            byte[] key = new byte[16];
            for (int i = 0; i < 16; i += 2)
            {
                byte[] unicodeBytes = BitConverter.GetBytes(checksum[i % checksum.Length]);
                Array.Copy(unicodeBytes, 0, key, i, 2);
            }
            return key;
        }

        // calcola l'hash del file XML
        private static string CalculateMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }
    }
}

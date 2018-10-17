using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;

namespace myx3p
{
    class Program
    {
        static void Main(string[] args)
        {
            // Inserisci path
            Console.Write("Inserisci path della cartella target.>");
            String path = Console.ReadLine();//"C:\\Users\\CristianSandu\\Desktop\\Test_h_firma";

            // path del file .dist
            String distfilepath = "";
            // path del file .hdr
            String hdrfilepath = "";
            //oggetto contenente campi provenienti dal file hdr
            HdrFields allfields = new HdrFields();
            // oggetto che mi crea l'XML
            CreateXML XMLScheme;

            String destinationXMLFile = "test.xml";
            String checkSumFile = "md5checksum.hex";
            String zipFile = "";
            
           //foreach che estrae i due file che mi servono .dist e .hdr 
           foreach(string file in Directory.EnumerateFiles(path, "*.*"))
            {

                if (Path.GetExtension(file).Equals(".dist"))
                {
                    distfilepath = file;
                }
                else if (Path.GetExtension(file).Equals(".hdr")){
                    hdrfilepath = file;
                    // creo un oggetto che estrapola e contiene i campi necessari dal file .hdr
                    allfields = new HdrFields(hdrfilepath);
                    allfields.extractFields();
                }
            }

            // prendi i campi dagli in pasto al createXML
            XMLScheme = new CreateXML(allfields);

            // calculate MD5 checksum
            String checksum = CalculateMD5(destinationXMLFile);
            StreamWriter checksumWriter = new StreamWriter(checkSumFile);
            checksumWriter.WriteLine(checksum); // write checksum on file
            checksumWriter.Close();

            // ZIP archive
            zipFile = hdrfilepath.Substring(0, hdrfilepath.Length - 4) + ".x3p";
            IEnumerable<String> list = new List<String> { checkSumFile, destinationXMLFile, distfilepath };
            CreateZipFile(zipFile, list);

            Console.WriteLine("Job finished: Press any key to exit.");
            Console.ReadLine();
        }

        // Crea il file ZIP contenente i 3 file del X3P
        public static void CreateZipFile(string fileName, IEnumerable<string> files)
        {
            // Create and open a new ZIP file
            var zip = ZipFile.Open(fileName, ZipArchiveMode.Create);
            foreach (var file in files)
            {
                // Add the entry for each file
                zip.CreateEntryFromFile(file, Path.GetFileName(file), CompressionLevel.Optimal);
            }
            // Dispose of the object when we are done
            zip.Dispose();
        }

        // calcola l'hash del file XML
        public static string CalculateMD5(string filename)
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

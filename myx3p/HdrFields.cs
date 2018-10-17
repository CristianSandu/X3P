using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myx3p
{
    class HdrFields
    {
        // contenuto di tutto l'header file
        private String contenuto;

        // informazioni dell'header file
        public string OBJECT_NAME;
        public string LOCATION_NAME;
        public string OPERATOR_ID;
        public string OPERATOR_NAME;
        public string JOB_ID;
        public string JOB_TIME;
        public string JOB_X_ORIGIN_mm;
        public string JOB_Y_ORIGIN_mm;
        public string JOB_RESOLUTION_mm;
        public string RANGE_X_mm;
        public string RANGE_Y_mm;
        public string RANGE_X_pt;
        public string RANGE_Y_pt;
        public string OFFSET_mm;
        public string PROBE_SERIALNUMBER;
        public string PROBE_TYPE;
        public string PROBE_DIRECTION;
        public string PROBE_FREQUENCY_hz;
        public string PROBE_POWER;
        public string PROBE_FINEPOWER;
        public string PROBE_COURSEPOWER;
        public string LENS_ID;
        public string LENS_MINd;
        public string LENS_MAXd;
        public string xAXIS_SPEED_mm_s;
        public string yAXIS_SPEED_mm_s;

        public HdrFields()
        {

        }



        //costruttore
        public HdrFields(String hdrfilepath)
        {
            this.contenuto = File.ReadAllText(hdrfilepath);
        }

        

        public void extractFields()
        {
            //Console.WriteLine(contenuto);
            char[] delimiterChars = { ' ',',', '\t', '\n' };
            string[] words = contenuto.Split(delimiterChars);
           
              OBJECT_NAME = words[1];
              LOCATION_NAME= words[3];
              OPERATOR_ID= words[5];
              OPERATOR_NAME= words[7];
              JOB_ID= words[9];
              JOB_TIME= words[11] + words[12];
              JOB_X_ORIGIN_mm= words[14];
              JOB_Y_ORIGIN_mm= words[16];
              JOB_RESOLUTION_mm= words[18];
              RANGE_X_mm= words[20];
              RANGE_Y_mm= words[22];
              RANGE_X_pt= words[24];
              RANGE_Y_pt= words[26];
              OFFSET_mm= words[28];
              PROBE_SERIALNUMBER= words[30];
              PROBE_TYPE= words[32];
              PROBE_DIRECTION= words[34];
              PROBE_FREQUENCY_hz= words[36];
              PROBE_POWER= words[38];
              PROBE_FINEPOWER= words[40];
              PROBE_COURSEPOWER= words[42];
              LENS_ID= words[44];
              LENS_MINd= words[46];
              LENS_MAXd= words[48];
              xAXIS_SPEED_mm_s= words[50];
              yAXIS_SPEED_mm_s= words[52];
    }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myx3p
{
    //Record2 is optional and contains the metadata of the data set.
    class Record2
    {
        private Record2Type record;
        private HdrFields hdr;

        ///////////////////////  Campi da inizializzare ////////////////////////////////////

        // Date and time of file creation = Date of currently used calibration
        private DateTime dateFileCreation = new DateTime(2018, 10, 16, 10, 15, 33 );
        //User comment to this data set
        private string comment = "L'acquisizione è avvenuta su banco ottico.";
        //Optional name of the creator of the file: Name  of the measuring person.
        private string creator = "Dott. Sandu Cristian OPDATECH Lab";
        //Name of the equipment manufacturer
        private string manufacturerName = "Conopoint.srl";
        //Name of the machine model used for the measurement
        private string machineModel = "HD";
        //Serial number of the machine.
        private string serialNumber = "11320456";
        //Software and hardware version strings used to create this file.
        private string hwandswversion = "HW = Custom made, SW = v1.0";
        // ( Contacting, Non Contacting, Software)
        ProbingSystemTypeType pstt = ProbingSystemTypeType.NonContacting;
        //Vendor specific identification of probe tip, lens, etc...
        private string identification = "Lens. 50 mm";


        /////////////////////////////////////////////////////////////////////////////////////

        public Record2(HdrFields hdr)
        {
            this.hdr = hdr;
            this.record = new Record2Type { CalibrationDate = setCalibrationDate(), Comment = setComment(), Creator = setCreator(), Date = setDate(), Instrument = setInstrument(), ProbingSystem = setProbingSystem() };
        }
        
        public Record2Type getRecord()
        {
            return this.record;
        }


        private DateTime setCalibrationDate()
        {
            return dateFileCreation;
        }

        private string setComment()
        {
            return comment;
        }

        private string setCreator()
        {
            return creator;
        }

        private DateTime setDate()
        {
            return dateFileCreation;
        }


        private InstrumentType setInstrument()
        {
            return new InstrumentType { Manufacturer = setManufacturer(), Model = setModel(), Serial = setSerial(), Version = setVerion() };
        }
        //Type of probing system: This can be contacting, non contacting or software
        private ProbingSystemType setProbingSystem()
        {
            return new ProbingSystemType { Identification = setIdentification(), Type = setType() };
        }

        //Vendor specific identification of probe tip, lens, etc...
        private ProbingSystemTypeType setType()
        {
            return pstt;

        }

        private string setIdentification()
        {
            return identification;
        }

        private string setVerion()
        {
            return hwandswversion;
        }

        private string setSerial()
        {
            return serialNumber;
        }
        //Name of the machine model used for the measurement
        private string setModel()
        {
            return machineModel;
        }

        //Name of the equipment manufacturer
        private string setManufacturer()
        {
            return manufacturerName;
        }












    }
}

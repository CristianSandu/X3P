using System;


namespace myx3p
{    //Record1 contains the axis description
    class Record1
    {

        private Record1Type record;
        private HdrFields fields;


        ///////////////////////////////  Campi da inizializzare //////////////////////////////////
        // SUR for surface, PRF for profile, PCL for unordered cloud points
        private Record1TypeFeatureType typefeature = Record1TypeFeatureType.SUR;
        //The optional transformation contains a 3D rotation matrix R with 3 by 3 elements that is used to rotate the
        //data points in its final orientation
        private RotationType rotationMatrix = new RotationType { r11 = 1.0, r12 = 0.0, r13 = 0.0, r21 = 0.0, r22 = 1.0, r23 = 0.0, r31 = 0.0, r32 = 0.0, r33 = 1.0 };


        ///////////////////////////////////////////////////////////////////////////////////////////


        // costruttore
        public Record1(HdrFields fields)
        {
            this.fields = fields;
            this.record = new Record1Type { Axes = setAxes(), FeatureType = setFeatureType(), Revision = setRevision() };
        }

        public Record1Type getRecord()
        {
            return this.record;
        }

        //Revision of file format.Currently: ISO5436 -2000
        public string setRevision()
        {
            return "ISO5436 - 2000";
        }
        /*
         "SUR" for surface type feature, "PRF" for
		profile type feature or "PCL" for unordered point clouds. Profile features are
		allways defined as a matrix of size (N,1,M) with
		beeing the number of points in the profile and
		M the number of layers in z-direction.
		Point clouds have to be stored as list type. 
         */
        public Record1TypeFeatureType setFeatureType()
        {
            return typefeature;
        }

        //Axis description
        public AxesType setAxes()
        {
            return new AxesType { CX = setCX(), CY = setCY(), CZ = setCZ(), Rotation = setRotation() };
        }
        //Description of X-Axis
        public AxisDescriptionType setCX()
        {
            return new AxisDescriptionType { AxisType = setAxisType("X"), DataType = setDataType("X"), DataTypeSpecified = false, Increment = setIncrement("X", 0.0), IncrementSpecified = false, Offset = setOffset("X", Convert.ToDouble(fields.JOB_X_ORIGIN_mm)), OffsetSpecified = true };
        }


        //The offset of axis in meter.
        public double setOffset(String type, double offset)
        {
            if (type.Equals("X")) return offset;
            else if (type.Equals("Y")) return offset;
            else if (type.Equals("Z")) return offset;
            else return offset;
        }


        /*
         Needed for incremental axis and integer data
		types: Increment is the multiplyer of the
		integer coordinate for the computation of the
		real coordinate: Xreal = Xoffset +
		Xinteger*XIncrement. The unit of increment and
		offset is metre.*/
        public double setIncrement(String type, double increment)
        {
            if (type.Equals("X")) return increment;
            else if (type.Equals("Y")) return increment;
            else if (type.Equals("Z")) return increment;
            else return increment;
        }


        /*
          Data type for absolute axis: 
         * "I" for int16, 
         * "L" for int32,
         * "F"for float32, 
         * "D" for float64.
           Incremental axes do not have/need a data type
         */
        public AxisDescriptionTypeDataType setDataType(string type)
        {
            if (type.Equals("X")) return AxisDescriptionTypeDataType.F;
            else if (type.Equals("Y")) return AxisDescriptionTypeDataType.F;
            else if (type.Equals("Z")) return AxisDescriptionTypeDataType.F;
            else return AxisDescriptionTypeDataType.F;
        }

        /*Type of axis can be "I" for Incremental, "A" for
		Absolute.The z-axis must be absolute!
        */
        public AxisDescriptionTypeAxisType setAxisType(string type)
        {
            if (type.Equals("X")) return AxisDescriptionTypeAxisType.I;
            else if (type.Equals("Y")) return AxisDescriptionTypeAxisType.I;
            else if (type.Equals("Z")) return AxisDescriptionTypeAxisType.A;
            else return AxisDescriptionTypeAxisType.A;

        }
        //Description of Y-Axis
        public AxisDescriptionType setCY()
        {
            return new AxisDescriptionType { AxisType = setAxisType("Y"), DataType = setDataType("Y"), DataTypeSpecified = false, Increment = setIncrement("Y", 0.0), IncrementSpecified = false, Offset = setOffset("Y", Convert.ToDouble(fields.JOB_Y_ORIGIN_mm)), OffsetSpecified = true };
        }
        //Description of Z-Axis
        public AxisDescriptionType setCZ()
        {
            return new AxisDescriptionType { AxisType = setAxisType("Z"), DataType = setDataType("Z"), DataTypeSpecified = false, Increment = setIncrement("Z", 0.0), IncrementSpecified = false, Offset = setOffset("Z", Convert.ToDouble(fields.JOB_Y_ORIGIN_mm)), OffsetSpecified = true };
        }


        /*
         An optional rotation of the data points. If this
		 element is missing a unit transformation is
		 assumed.
         */
        public RotationType setRotation()
        {
            /*
                    The optional transformation contains a 3D rotation
					matrix R with 3 by 3 elements that is used to rotate the
					data points in its final orientation. The full
					transformation consists of a rotation and a following
					translation that is taken from the
					AxisDescriptionType.Offset elements: Q = R*P + T With Q
					beeing the final point, P the coordinate as specified in
					Record3, R the 3 by 3 rotation matrix and T the
					3-element offset vector. The * denotes a matrix product.
					The formula for the x coordinate is: Qx =
					r11*Px+r12*Py+r13*Pz + Tx. The formula for the y
					coordinate is: Qy = r21*Px+r22*Py+r23*Pz + Ty. The
					formula for the x coordinate is: Qz =
					r31*Px+r32*Py+r33*Pz + Tz.s
             */
            // r is an element of a pure rotation matrix is limited to a value range of[-1..1].
            return rotationMatrix;

        }


    }
}


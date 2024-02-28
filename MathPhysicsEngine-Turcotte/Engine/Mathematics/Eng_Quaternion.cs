using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Mathematics
{
    public class Eng_Quaternion
    {
        //1.a - Properties.
        
        //2.a - Empty Constructor.
        public Eng_Quaternion()
        {
			
	}//eom
		
        //2.b - Create from input of 4 values (make sure the magnitude = 1).
        public Eng_Quaternion(double w, double x, double y, double z)
        {
			
	}//eom
		
        //2.c - Create from roll, pitch, and yaw angles (all in degrees).
        public Eng_Quaternion(double rollDeg, double pitchDeg, double yawDeg)
        {
			
	}//eom
        #region Class Methods
        //3.a - Create Matrix from Quaternion.
        public Eng_Matrix4x4 ConvertToMatrix()
        {
			
	}//end of ConvertToMatrix
		
        //3.b - Create rotation angles (in degrees) from Quaternion.
        public Tuple<double, double, double> ConvertToEuler()
        {
			
	}//end of ConvertToEuler
        #endregion

        #region Overload Operators
        #region Complier Warning Fix
        // the following two methods are to remove the CS0660 and CS0661 compiler warnings
        #pragma warning restore CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
        public override bool Equals(object obj)
        {
            return true;
        }//eom
	#pragma warning restore CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
        public override int GetHashCode()
        {
            return 0;
        }//eom
        #endregion

        //4.a - Equality of two Quaternions.
      
        //4.b - Inequality of two Quaternions.
        
        #endregion
    }//eoc
}//eon

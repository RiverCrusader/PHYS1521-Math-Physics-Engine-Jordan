using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Mathematics
{
    public class Eng_Matrix4x4
    {
        //1.a - Properties.
        
        //1.b - Empty Constructor.
        public Eng_Matrix4x4()
        {
			
		}//eom
		
		//1.c - Non-empty Constructor.
		public Eng_Matrix4x4(
            double m11, double m12, double m13, double m14,
            double m21, double m22, double m23, double m24,
            double m31, double m32, double m33, double m34,
            double m41, double m42, double m43, double m44)
        {
			
		}//eom
		
        #region Additional Constructors
        //2.a - Create an Identity matrix.
        public void Identity()
        {
			
		}//end of Identity
		
        //2.b - Create from Transformation (Scale and Shift).
        public Eng_Matrix4x4 Create3DTransformationMatrix(double shiftX, double shiftY, double shiftZ, double scaleX, double scaleY, double scaleZ)
        {
			
		}//end of Create3DTransformationMatrix
		
        //2.c - Create a Roll rotation matrix from an angle in degrees.
        public Eng_Matrix4x4 CreateRollRotationMatrix(double angle)
        {
			
		}//end of CreateRollRotationMatrix
		
        //2.d - Create a Pitch rotation matrix from an angle in degrees.
        public Eng_Matrix4x4 CreatePitchRotationMatrix(double angle)
        {
			
		}//end of CreatePitchRotationMatrix
		
        //2.e - Create a Yaw rotation matrix from an angle in degrees.
        public Eng_Matrix4x4 CreateYawRotationMatrix(double angle).
        {
			
		}//end of CreateYawRotationMatrix
        #endregion

        #region Class Methods
        //3.a - Transpose a matrix.
        public Eng_Matrix4x4 Transpose()
        {
			
		}//end of Transpose
		
        //3.b - Calculate the determinant of a matrix.
        //      HINT: Call the determinant of the Eng_Matrix3x3 class as required.
        public double Determinant()
        {
			
		}//end of Determinant
		
        //3.c - Calculate the inverse of a matrix.
        public Eng_Matrix4x4 Inverse()
        {
			
		}//end of Inverse
        #endregion
 
        #region Overload Operators
        #region Complier Warning Fix
        // the following two methods are to remove the CS0660 and CS0661 compiler warnings
        public override bool Equals(object obj)
        {
            return true;
        }//eom
		
        public override int GetHashCode()
        {
            return 0;
        }//eom
        #endregion

        //4.a - Equality of two 4x4 matrices.
       
        //4.b - Inequality of two 4x4 matrices.
        
        //4.c - Scale a 4x4 matrix.
        
        //4.d - Multiply two 4x4 matrices.
        
        #endregion
    }//eoc
}//eon

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Mathematics
{
	public class Eng_Matrix3x3
    {
        //1.a - Properties.
        public double M11 { get; set; }
        public double M12 { get; set; }
        public double M13 { get; set; }
        public double M21 { get; set; }
        public double M22 { get; set; }
        public double M23 { get; set; }
        public double M31 { get; set; }
        public double M32 { get; set; }
        public double M33 { get; set; }

        //1.b - Emplty Constructor.
        public Eng_Matrix3x3()
        {
            M11 = 0;
            M12 = 0;
            M13 = 0;

            M21 = 0;
            M22 = 0;
            M23 = 0;

            M31 = 0;
            M32 = 0;
            M33 = 0;
        }//eom
		
		//1.c - Non-empty Constructor.
		public Eng_Matrix3x3(double m11,double m12,double m13, double m21, double m22, double m23, double m31, double m32, double m33)
        {
            M11 = m11;
            M12 = m12;
            M13 = m13;

            M21 = m21;
            M22 = m22;
            M23 = m23;

            M31 = m31;
            M32 = m32;
            M33 = m33;
        }//eom
       
        #region Additional Constructors
        //2.a - Create an Identity matrix.
        public void Identity()
        {
            Eng_Matrix3x3 Identity = new Eng_Matrix3x3(1, 0, 0, 0, 1, 0, 0, 0, 1); 

			//m11=1; m12=0; m13=0; 
            //m21=0; m22=1; m23=0;
            //m31=0; m32=0; m33=1;

		}//end of Identity
		
        //2.b - Create a 2D rotation matrix from a given angle in degrees.
        public Eng_Matrix3x3 Create2DRotationMatrix(double angle)
        {
			
		}//end of Create2DRotationMatrix
		
        //2.c - Create from Transformation (Scale and Shift).
        public Eng_Matrix3x3 Create2DTransformationMatrix (double shiftX, double shiftY, double scaleX, double scaleY)
        {
			
		}//end of Cre.
        #endregion

        #region Class Methods
        //3.a - Transpose a matrix.
        public Eng_Matrix3x3 Transpose()
        {
			
		}//end of Transpose
		
        //3.b - Calculate the determinant of a matrix.
        public double Determinant()
        {
			
		}//end of Determinant
		
        //3.c - Calculate the inverse of a matrix.
        public Eng_Matrix3x3 Inverse()
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

        //4.a - Equality of two 3x3 matrices.
       
        //4.b - Inequality of two 3x3 matrices.
        
        //4.c - Scale a matrix.
        
        //4.d - Multiply two 3x3 matrices.
        
        #endregion
    }//eoc
}//eon

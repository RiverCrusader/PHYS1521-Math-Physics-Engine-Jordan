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
        public double M11 { get; set; }
        public double M12 { get; set; }
        public double M13 { get; set; }
        public double M14 { get; set; }
        public double M21 { get; set; }
        public double M22 { get; set; }
        public double M23 { get; set; }
        public double M24 { get; set; }
        public double M31 { get; set; }
        public double M32 { get; set; }
        public double M33 { get; set; }
        public double M34 { get; set; }
        public double M41 { get; set; }
        public double M42 { get; set; }
        public double M43 { get; set; }
        public double M44 { get; set; }
        //1.b - Empty Constructor.
        public Eng_Matrix4x4()
        {
            M11 = 0;
            M12 = 0;
            M13 = 0;
            M14 = 0;

            M21 = 0;
            M22 = 0;
            M23 = 0;
            M24 = 0;

            M31 = 0;
            M32 = 0;
            M33 = 0;
            M34 = 0;

            M41 = 0;
            M42 = 0;
            M43 = 0;
            M44 = 0;
        }//eom
		
		//1.c - Non-empty Constructor.
		public Eng_Matrix4x4(
            double m11, double m12, double m13, double m14,
            double m21, double m22, double m23, double m24,
            double m31, double m32, double m33, double m34,
            double m41, double m42, double m43, double m44)
        {
            M11 = m11;
            M12 = m12;
            M13 = m13;
            M14 = m14;

            M21 = m21;
            M22 = m22;
            M23 = m23;
            M24 = m24;

            M31 = m31;
            M32 = m32;
            M33 = m33;
            M34 = m34;

            M41 = m41;
            M42 = m42;
            M43 = m43;
            M44 = m44;
        }//eom

        //Roll = Z, Pitch = X, Yaw = Y

        #region Additional Constructors
        //2.a - Create an Identity matrix.
        public void Identity()
        {
			Eng_Matrix4x4 Identity = new Eng_Matrix4x4(1,0,0,0,0,1,0,0,0,0,1,0,0,0,0,1);

            //m11=1; m12=0; m13=0; m14=0; 
            //m21=0; m22=1; m23=0; m24=0;
            //m31=0; m32=0; m33=1; m34=0;
            //m41=0; m42=0; m43=0; m44=0;
        }//end of Identity

        //2.b - Create from Transformation (Scale and Shift).
        public Eng_Matrix4x4 Create3DTransformationMatrix(double shiftX, double shiftY, double shiftZ, double scaleX, double scaleY, double scaleZ)
        {
			return new Eng_Matrix4x4(scaleX,0,0,shiftX,0,scaleY,0,shiftY,0,0,scaleZ,shiftZ,0,0,0,1);
		}//end of Create3DTransformationMatrix

        //2.c - Create a Roll rotation matrix from an angle in degrees.
        public Eng_Matrix4x4 CreateRollRotationMatrix(double angle)
        {
            angle = Functions.DegreesToRadians(angle);

            return new Eng_Matrix4x4(Math.Cos(angle), -Math.Sin(angle), 0, 0, Math.Sin(angle), Math.Cos(angle), 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
        }//end of CreateRollRotationMatrix
		
        //2.d - Create a Pitch rotation matrix from an angle in degrees.
        public Eng_Matrix4x4 CreatePitchRotationMatrix(double angle)
        {
            angle = Functions.DegreesToRadians(angle);

            return new Eng_Matrix4x4(1, 0, 0, 0, 0, Math.Cos(angle), -Math.Sin(angle), 0, 0, Math.Sin(angle), Math.Cos(angle), 0, 0, 0, 0, 1);
        }//end of CreatePitchRotationMatrix
		
        //2.e - Create a Yaw rotation matrix from an angle in degrees.
        public Eng_Matrix4x4 CreateYawRotationMatrix(double angle)
        {
            angle = Functions.DegreesToRadians(angle);

            return new Eng_Matrix4x4(Math.Cos(angle), 0, Math.Sin(angle), 0, 0, 1, 0, 0, -Math.Sin(angle), 0, Math.Cos(angle), 0, 0, 0, 0, 1);
        }//end of CreateYawRotationMatrix
        #endregion

        #region Class Methods
        //3.a - Transpose a matrix.
        public Eng_Matrix4x4 Transpose()
        {
            Eng_Matrix4x4 t = new Eng_Matrix4x4();

            t.M11 = M11;
            t.M12 = M21;
            t.M13 = M31;
            t.M14 = M41;

            t.M21 = M12;
            t.M22 = M22;
            t.M23 = M32;
            t.M24 = M42;

            t.M31 = M13;
            t.M32 = M23;
            t.M33 = M33;
            t.M34 = M43;

            t.M41 = M14;
            t.M42 = M24;
            t.M43 = M34;
            t.M44 = M44;

            return t;
        }//end of Transpose
		
        //3.b - Calculate the determinant of a matrix.
        //      HINT: Call the determinant of the Eng_Matrix3x3 class as required.
        public double Determinant()
        {
            //man this sucks ...
            //hope this works so i dont have to look at it again

            return M11 * ((M22 * M33 * M44) - (M22 * M34 * M43) - (M23 * M32 * M44) + (M23 * M34 * M42) + (M24 * M32 * M43) - (M24 * M33 * M42))
                 - M12 * ((M21 * M33 * M44) - (M21 * M34 * M43) - (M23 * M31 * M44) + (M23 * M34 * M41) + (M24 * M31 * M43) - (M24 * M33 * M41))
                 + M13 * ((M21 * M32 * M44) - (M21 * M34 * M42) - (M22 * M31 * M44) + (M22 * M34 * M41) + (M24 * M31 * M42) - (M24 * M32 * M41))
                 - M14 * ((M21 * M32 * M43) - (M21 * M33 * M42) - (M22 * M31 * M43) + (M22 * M33 * M41) + (M23 * M31 * M42) - (M23 * M32 * M41));

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

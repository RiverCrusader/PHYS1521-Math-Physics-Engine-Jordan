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
        public Eng_Matrix3x3(double m11, double m12, double m13, double m21, double m22, double m23, double m31, double m32, double m33)
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
            M11 = 1; M12 = 0; M13 = 0;
            M21 = 0; M22 = 1; M23 = 0;
            M31 = 0; M32 = 0; M33 = 1;
        }//end of Identity

        //2.b - Create a 2D rotation matrix from a given angle in degrees.
        public Eng_Matrix3x3 Create2DRotationMatrix(double angle)
        {
            angle = Functions.DegreesToRadians(angle);

            return new Eng_Matrix3x3(Math.Cos(angle), -Math.Sin(angle), 0, Math.Sin(angle), Math.Cos(angle), 0, 0, 0, 1);
        }//end of Create2DRotationMatrix

        //2.c - Create from Transformation (Scale and Shift).
        public Eng_Matrix3x3 Create2DTransformationMatrix(double shiftX, double shiftY, double scaleX, double scaleY)
        {
            return new Eng_Matrix3x3(scaleX, 0, shiftX, 0, scaleY, shiftY, 0, 0, 1);

        }//end of Cre.
        #endregion

        #region Class Methods
        //3.a - Transpose a matrix.
        public Eng_Matrix3x3 Transpose()
        {
            Eng_Matrix3x3 t = new Eng_Matrix3x3();

            t.M11 = M11;
            t.M12 = M21;
            t.M13 = M31;

            t.M21 = M12;
            t.M22 = M22;
            t.M23 = M32;

            t.M31 = M13;
            t.M32 = M23;
            t.M33 = M33;

            return t;
        }//end of Transpose

        //3.b - Calculate the determinant of a matrix.
        public double Determinant()
        {
            return M11 * (M22 * M33 - M23 * M32) - M12 * (M21 * M33 - M23 * M31) + M13 * (M21 * M32 - M22 * M31);
        }//end of Determinant

        //3.c - Calculate the inverse of a matrix.
        public Eng_Matrix3x3 Inverse()
        {
            //aw man this is gonna take a hot momment actually didnt take that long
            Eng_Matrix3x3 m = new Eng_Matrix3x3(M11,M12,M13,
                                                M21,M22,M23,
                                                M31,M32,M33);
            double det = m.Determinant();

            Eng_Matrix3x3 c = new Eng_Matrix3x3();

            c.M11 = ((M22 * M33) - (M23 * M32)) / det;
            c.M12 = (-((M21 * M33) - (M23 * M31)) / det);
            c.M13 = ((M21 * M32) - (M22 * M31)) / det;

            c.M21 = (-((M12 * M33) - (M13 * M32))) / det;
            c.M22 = ((M11 * M33) - (M13 * M31)) / det;
            c.M23 = (-((M11 * M32) - (M12 * M31))) / det;

            c.M31 = ((M12 * M23) - (M13 * M22)) / det;
            c.M32 = (-((M11 * M23) - (M13 * M21)) / det);
            c.M33 = ((M11 * M22) - (M12 * M21)) / det;

            return c;
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
        public static bool operator ==(Eng_Matrix3x3 a, Eng_Matrix3x3 b)
        {
            return
            a.M11 == b.M11 &&
            a.M12 == b.M12 &&
            a.M13 == b.M13 &&

            a.M21 == b.M21 &&
            a.M22 == b.M22 &&
            a.M23 == b.M23 &&

            a.M31 == b.M31 &&
            a.M32 == b.M32 &&
            a.M33 == b.M33;
        }
        //4.b - Inequality of two 3x3 matrices.
        public static bool operator !=(Eng_Matrix3x3 a, Eng_Matrix3x3 b)
        {
            return
            a.M11 != b.M11 ||
            a.M12 != b.M12 ||
            a.M13 != b.M13 ||

            a.M21 != b.M21 ||
            a.M22 != b.M22 ||
            a.M23 != b.M23 ||

            a.M31 != b.M31 ||
            a.M32 != b.M32 ||
            a.M33 != b.M33;
        }
        //4.c - Scale a matrix.
        public static Eng_Matrix3x3 operator *(Eng_Matrix3x3 a, double scalar)
        {
            //multiply each number by scalar
            return new Eng_Matrix3x3(a.M11 * scalar, a.M12 * scalar, a.M13 * scalar, a.M21 * scalar, a.M22 * scalar, a.M23 * scalar, a.M31 * scalar, a.M32 * scalar, a.M33 * scalar);
        }
        //4.d - Multiply two 3x3 matrices.
        public static Eng_Matrix3x3 operator *(Eng_Matrix3x3 a, Eng_Matrix3x3 b)
        {
            //way more readable

            Eng_Matrix3x3 ab = new Eng_Matrix3x3();

            ab.M11 = (a.M11 * b.M11) + (a.M12 * b.M21) + (a.M13 * b.M31);
            ab.M12 = (a.M11 * b.M12) + (a.M12 * b.M22) + (a.M13 * b.M32);
            ab.M13 = (a.M11 * b.M13) + (a.M12 * b.M23) + (a.M13 * b.M33);

            ab.M21 = (a.M21 * b.M11) + (a.M22 * b.M21) + (a.M23 * b.M31);
            ab.M22 = (a.M21 * b.M12) + (a.M22 * b.M22) + (a.M23 * b.M32);
            ab.M23 = (a.M21 * b.M13) + (a.M22 * b.M23) + (a.M23 * b.M33);

            ab.M31 = (a.M31 * b.M11) + (a.M32 * b.M21) + (a.M33 * b.M31);
            ab.M32 = (a.M31 * b.M12) + (a.M32 * b.M22) + (a.M33 * b.M32);
            ab.M33 = (a.M31 * b.M13) + (a.M32 * b.M23) + (a.M33 * b.M33);

            return ab;
        }
        #endregion
    }//eoc
}//eon

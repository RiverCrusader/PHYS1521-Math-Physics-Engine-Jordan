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
            M11 = 1; M12 = 0; M13 = 0; M14 = 0;
            M21 = 0; M22 = 1; M23 = 0; M24 = 0;
            M31 = 0; M32 = 0; M33 = 1; M34 = 0;
            M41 = 0; M42 = 0; M43 = 0; M44 = 1;
        }//end of Identity

        //2.b - Create from Transformation (Scale and Shift).
        public Eng_Matrix4x4 Create3DTransformationMatrix(double shiftX, double shiftY, double shiftZ, double scaleX, double scaleY, double scaleZ)
        {
            return new Eng_Matrix4x4(scaleX, 0, 0, shiftX, 0, scaleY, 0, shiftY, 0, 0, scaleZ, shiftZ, 0, 0, 0, 1);
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
            Eng_Matrix3x3 v11 = new Eng_Matrix3x3(M22, M23, M24, M32, M33, M34, M42, M43, M44);
            Eng_Matrix3x3 v12 = new Eng_Matrix3x3(M21, M23, M24, M31, M33, M34, M41, M43, M44);
            Eng_Matrix3x3 v13 = new Eng_Matrix3x3(M21, M22, M24, M31, M32, M34, M41, M42, M44);
            Eng_Matrix3x3 v14 = new Eng_Matrix3x3(M21, M22, M23, M31, M32, M33, M41, M42, M43);

            return (M11 * v11.Determinant())
                 - (M12 * v12.Determinant())
                 + (M13 * v13.Determinant())
                 - (M14 * v14.Determinant());

        }//end of Determinant

        //3.c - Calculate the inverse of a matrix.
        public Eng_Matrix4x4 Inverse()
        {
            //almost certainly an easier way but alas this should work
            Eng_Matrix4x4 m = new Eng_Matrix4x4(M11, M12, M13, M14,
                                                M21, M22, M23, M24,
                                                M31, M32, M33, M34,
                                                M41, M42, M43, M44);
            Eng_Matrix4x4 c = new Eng_Matrix4x4();
            double det = m.Determinant();

            Eng_Matrix3x3 v11 = new Eng_Matrix3x3(M22, M23, M24, M32, M33, M34, M42, M43, M44);
            Eng_Matrix3x3 v12 = new Eng_Matrix3x3(M12, M13, M14, M32, M33, M34, M42, M43, M44);
            Eng_Matrix3x3 v13 = new Eng_Matrix3x3(M12, M13, M14, M22, M23, M24, M42, M43, M44);
            Eng_Matrix3x3 v14 = new Eng_Matrix3x3(M12, M13, M14, M22, M23, M24, M32, M33, M34);

            c.M11 = v11.Determinant() / det;
            c.M12 = -(v12.Determinant()) / det;
            c.M13 = v13.Determinant() / det;
            c.M14 = -(v14.Determinant()) / det;

            Eng_Matrix3x3 v21 = new Eng_Matrix3x3(M21, M23, M24, M31, M33, M34, M41, M43, M44);
            Eng_Matrix3x3 v22 = new Eng_Matrix3x3(M11, M13, M14, M31, M33, M34, M41, M43, M44);
            Eng_Matrix3x3 v23 = new Eng_Matrix3x3(M11, M13, M14, M21, M23, M24, M41, M43, M44);
            Eng_Matrix3x3 v24 = new Eng_Matrix3x3(M11, M13, M14, M21, M23, M24, M31, M33, M34);

            c.M21 = -(v21.Determinant()) / det;
            c.M22 = v22.Determinant() / det;
            c.M23 = -(v23.Determinant()) / det;
            c.M24 = v24.Determinant() / det;

            Eng_Matrix3x3 v31 = new Eng_Matrix3x3(M21, M22, M24, M31, M32, M34, M41, M42, M44);
            Eng_Matrix3x3 v32 = new Eng_Matrix3x3(M11, M12, M14, M31, M32, M34, M41, M42, M44);
            Eng_Matrix3x3 v33 = new Eng_Matrix3x3(M11, M12, M14, M21, M22, M24, M41, M42, M44);
            Eng_Matrix3x3 v34 = new Eng_Matrix3x3(M11, M12, M14, M21, M22, M24, M31, M32, M34);

            c.M31 = v31.Determinant() / det;
            c.M32 = -(v32.Determinant()) / det;
            c.M33 = v33.Determinant() / det;
            c.M34 = -(v34.Determinant()) / det;

            Eng_Matrix3x3 v41 = new Eng_Matrix3x3(M21, M22, M23, M31, M32, M33, M41, M42, M43);
            Eng_Matrix3x3 v42 = new Eng_Matrix3x3(M11, M12, M13, M31, M32, M33, M41, M42, M43);
            Eng_Matrix3x3 v43 = new Eng_Matrix3x3(M11, M12, M13, M21, M22, M23, M41, M42, M43);
            Eng_Matrix3x3 v44 = new Eng_Matrix3x3(M11, M12, M13, M21, M22, M23, M31, M32, M33);

            c.M41 = -(v41.Determinant()) / det;
            c.M42 = v42.Determinant() / det;
            c.M43 = -(v43.Determinant()) / det;
            c.M44 = v44.Determinant() / det;

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

        //4.a - Equality of two 4x4 matrices.
        public static bool operator ==(Eng_Matrix4x4 a, Eng_Matrix4x4 b)
        {
            return
            a.M11 == b.M11 &&
            a.M12 == b.M12 &&
            a.M13 == b.M13 &&
            a.M14 == b.M14 &&

            a.M21 == b.M21 &&
            a.M22 == b.M22 &&
            a.M23 == b.M23 &&
            a.M24 == b.M24 &&

            a.M31 == b.M31 &&
            a.M32 == b.M32 &&
            a.M33 == b.M33 &&
            a.M34 == b.M34 &&

            a.M41 == b.M41 &&
            a.M42 == b.M42 &&
            a.M43 == b.M43 &&
            a.M44 == b.M44;
        }


        //4.b - Inequality of two 4x4 matrices.
        public static bool operator !=(Eng_Matrix4x4 a, Eng_Matrix4x4 b)
        {
            return
            a.M11 != b.M11 ||
            a.M12 != b.M12 ||
            a.M13 != b.M13 ||
            a.M14 != b.M14 ||

            a.M21 != b.M21 ||
            a.M22 != b.M22 ||
            a.M23 != b.M23 ||
            a.M24 != b.M24 ||

            a.M31 != b.M31 ||
            a.M32 != b.M32 ||
            a.M33 != b.M33 ||
            a.M34 != b.M34 ||

            a.M41 != b.M41 ||
            a.M42 != b.M42 ||
            a.M43 != b.M43 ||
            a.M44 != b.M44;
        }
        //4.c - Scale a 4x4 matrix.
        public static Eng_Matrix4x4 operator *(Eng_Matrix4x4 a, double scalar)
        {
            //multiply each number by scalar
            return new Eng_Matrix4x4(a.M11 * scalar, a.M12 * scalar, a.M13 * scalar, a.M14 * scalar,
                                     a.M21 * scalar, a.M22 * scalar, a.M23 * scalar, a.M24 * scalar,
                                     a.M31 * scalar, a.M32 * scalar, a.M33 * scalar, a.M34 * scalar,
                                     a.M41 * scalar, a.M42 * scalar, a.M43 * scalar, a.M44 * scalar);
        }
        //4.d - Multiply two 4x4 matrices.
        public static Eng_Matrix4x4 operator *(Eng_Matrix4x4 a, Eng_Matrix4x4 b)
        {
            Eng_Matrix4x4 ab = new Eng_Matrix4x4();

            ab.M11 = (a.M11 * b.M11) + (a.M12 * b.M21) + (a.M13 * b.M31) + (a.M14 * b.M41);
            ab.M12 = (a.M11 * b.M12) + (a.M12 * b.M22) + (a.M13 * b.M32) + (a.M14 * b.M42);
            ab.M13 = (a.M11 * b.M13) + (a.M12 * b.M23) + (a.M13 * b.M33) + (a.M14 * b.M43);
            ab.M14 = (a.M11 * b.M14) + (a.M12 * b.M24) + (a.M13 * b.M34) + (a.M14 * b.M44);

            ab.M21 = (a.M21 * b.M11) + (a.M22 * b.M21) + (a.M23 * b.M31) + (a.M24 * b.M41);
            ab.M22 = (a.M21 * b.M12) + (a.M22 * b.M22) + (a.M23 * b.M32) + (a.M24 * b.M42);
            ab.M23 = (a.M21 * b.M13) + (a.M22 * b.M23) + (a.M23 * b.M33) + (a.M24 * b.M43);
            ab.M24 = (a.M21 * b.M14) + (a.M22 * b.M24) + (a.M23 * b.M34) + (a.M24 * b.M44);

            ab.M31 = (a.M31 * b.M11) + (a.M32 * b.M21) + (a.M33 * b.M31) + (a.M34 * b.M41);
            ab.M32 = (a.M31 * b.M12) + (a.M32 * b.M22) + (a.M33 * b.M32) + (a.M34 * b.M42);
            ab.M33 = (a.M31 * b.M13) + (a.M32 * b.M23) + (a.M33 * b.M33) + (a.M34 * b.M43);
            ab.M34 = (a.M31 * b.M14) + (a.M32 * b.M24) + (a.M33 * b.M34) + (a.M34 * b.M44);

            ab.M41 = (a.M41 * b.M11) + (a.M42 * b.M21) + (a.M43 * b.M41) + (a.M44 * b.M41);
            ab.M42 = (a.M41 * b.M12) + (a.M42 * b.M22) + (a.M43 * b.M32) + (a.M44 * b.M42);
            ab.M43 = (a.M41 * b.M13) + (a.M42 * b.M23) + (a.M43 * b.M33) + (a.M44 * b.M43);
            ab.M44 = (a.M41 * b.M14) + (a.M42 * b.M24) + (a.M43 * b.M34) + (a.M44 * b.M44);

            return ab;
        }
        #endregion
    }//eoc
}//eon

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using NUnit.Framework;
using Engine.Mathematics;
using System.Security.Policy;
using System.Configuration;

#endregion

namespace Engine.Tests.Lab2
{
    [TestFixture]
    public class Lab2Tester
    {
        #region Part 1 - Matrix Transformation in 2D
        //7.a - Test 2.a - Create an Identity matrix.
        [Test,
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(1, 0)
        ]
        public void TestCreateIdentityMatrix3(double one, double zero)
        {
            // Create objects for the test [create a matrix using empty constructor]
            Eng_Matrix3x3 actual = new Eng_Matrix3x3();
            // Perform the test [create the Identity()]
            actual.Identity();
            // Assert
            Assert.AreEqual(one, actual.M11);
            Assert.AreEqual(zero, actual.M12);
            Assert.AreEqual(zero, actual.M13);

            Assert.AreEqual(zero, actual.M21);
            Assert.AreEqual(one, actual.M22);
            Assert.AreEqual(zero, actual.M23);

            Assert.AreEqual(zero, actual.M31);
            Assert.AreEqual(zero, actual.M32);
            Assert.AreEqual(one, actual.M33);
        }//end of TestCreateIdentityMatrix3

        //7.b - Test 2.b - Create a 2D rotation matrix from a given angle in degrees.
        [Test,
            // 1st = rotation angle in degrees
            // Remainder = expected rotation matrix
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(25, 0.9063, -0.4226, 0, 0.4226, 0.9063, 0, 0, 0, 1),
            // Student Data - MUST CHANGE
            TestCase(38, 0.7880, -0.6157, 0, 0.6157, 0.7880, 0, 0, 0, 1)
        ]

        public void TestCreate2DRotationMatrix(
            double degrees,
            double m11Exp, double m12Exp, double m13Exp,
            double m21Exp, double m22Exp, double m23Exp,
            double m31Exp, double m32Exp, double m33Exp)
        {
            // Create the objects for the test
            Eng_Matrix3x3 actual = new Eng_Matrix3x3();
            // Perform the test
            actual = actual.Create2DRotationMatrix(degrees);
            // Assert
            Assert.AreEqual(m11Exp, Math.Round(actual.M11, 4));
            Assert.AreEqual(m12Exp, Math.Round(actual.M12, 4));
            Assert.AreEqual(m13Exp, Math.Round(actual.M13, 4));

            Assert.AreEqual(m21Exp, Math.Round(actual.M21, 4));
            Assert.AreEqual(m22Exp, Math.Round(actual.M22, 4));
            Assert.AreEqual(m23Exp, Math.Round(actual.M23, 4));

            Assert.AreEqual(m31Exp, Math.Round(actual.M31, 4));
            Assert.AreEqual(m32Exp, Math.Round(actual.M32, 4));
            Assert.AreEqual(m33Exp, Math.Round(actual.M33, 4));
        }//end of TestCreate2DRotationMatrix

        //7.c - Test 2.c - Create from Transformation (Scale and Shift).
        [Test,
            // 1st = scale in x
            // 2nd = scale in y
            // 3rd = shift in x
            // 4th = shift in y
            // Remainder = expected transformation matrix
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(2, 3, -4, -2, 2, 0, -4, 0, 3, -2, 0, 0, 1),
            // Student Data - MUST CHANGE
            TestCase(12, 8, -3, 7, 12, 0, -3, 0, 8, 7, 0, 0, 1)
        ]

        public void TestCreate2DTransformationMatrix(
            double scaleX, double scaleY, double shiftX, double shiftY,
            double m11Exp, double m12Exp, double m13Exp,
            double m21Exp, double m22Exp, double m23Exp,
            double m31Exp, double m32Exp, double m33Exp)
        {
            // Create the objects for the test
            Eng_Matrix3x3 actual = new Eng_Matrix3x3();
            // Perform the test
            actual = actual.Create2DTransformationMatrix(shiftX, shiftY, scaleX, scaleY);
            // Assert
            Assert.AreEqual(m11Exp, Math.Round(actual.M11, 4));
            Assert.AreEqual(m12Exp, Math.Round(actual.M12, 4));
            Assert.AreEqual(m13Exp, Math.Round(actual.M13, 4));

            Assert.AreEqual(m21Exp, Math.Round(actual.M21, 4));
            Assert.AreEqual(m22Exp, Math.Round(actual.M22, 4));
            Assert.AreEqual(m23Exp, Math.Round(actual.M23, 4));

            Assert.AreEqual(m31Exp, Math.Round(actual.M31, 4));
            Assert.AreEqual(m32Exp, Math.Round(actual.M32, 4));
            Assert.AreEqual(m33Exp, Math.Round(actual.M33, 4));
        }//end of TestCreate2DTransformationMatrix

        //7.d - Test 3.a - Transpose a matrix.
        public static IEnumerable<Object[]> Matrix3TransposeData()
        {
            // Instructor Data - MUST NOT DELETE OR MODIFY
            yield return new Object[]
            {
                new Eng_Matrix3x3(2, 0, 4, 0, 3, -2, 0, 0, 1),	// matrix
                new Eng_Matrix3x3(2, 0, 0, 0, 3, 0, 4, -2, 1)	// expected transpose of the matrix
            };
            // Student Data - YOU NEED TO ADD YOUR DATA BELOW
            yield return new Object[]
            {
                new Eng_Matrix3x3(5, 1, 7, 2, -3, 5, 1, 2, 8),	// matrix
                new Eng_Matrix3x3(5, 2, 1, 1, -3, 2, 7, 5, 8)	// expected transpose of the matrix
            };
        }//end of Matrix3TransposeData

        [Test, TestCaseSource(nameof(Matrix3TransposeData))]
        public void TestMatrix3Transpose(Eng_Matrix3x3 m, Eng_Matrix3x3 expected)
        {
            // Perform the test
            m.Transpose();
            //Assert
            Assert.AreEqual(expected, m);
        }//end of TestMatrix3Transpose

        //7.e - Test 3.b - Calculate the determinant of a matrix.
        [Test,
            // 1st to 9th = matrix
            // Last = expected determinant
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(2, 0, 4, 0, 3, -2, 0, 0, 1, 6),
            // Student Data - MUST CHANGE
            TestCase(5, 7, -6, 1, 0, 1, 3, 4, 8, -79)
        ]

        public void TestMatrix3Determinant(
            double m11, double m12, double m13,
            double m21, double m22, double m23,
            double m31, double m32, double m33,
            double expected)
        {
            // Create objects for the test
            Eng_Matrix3x3 matrix = new Eng_Matrix3x3(m11, m12, m13, m21, m22, m23, m31, m32, m33);
            double actual;
            // Perform the test
            actual = matrix.Determinant();
            // Assert
            Assert.AreEqual(expected, actual);
        }//end of TestMatrix3Determinant

        //7.f - Test 3.c - Calculate the inverse of a matrix.
        public static IEnumerable<Object[]> Matrix3InverseData()
        {
            // Instructor Data - MUST NOT DELETE OR MODIFY
            yield return new Object[]
            {
                new Eng_Matrix3x3(2, 0, 4, 0, 8, -2, 0, 0, 1),				// matrix
                new Eng_Matrix3x3(0.5, 0, 0, 0, 0.125, 0,-2, 0.25, 1)	// expected inverse
            };
            // Student Data - YOU NEED TO ADD YOUR DATA BELOW
            yield return new Object[]
            {
                new Eng_Matrix3x3(5, 1, 0, 1, 4, -1, 2, 5, 1),				// matrix
                new Eng_Matrix3x3(0.2143, -0.0714, -0.0714, -0.0238, 0.1190, -0.5476, -0.0238, 0.1190, 0.4524)	// expected inverse
            };
        }//end of Matrix3InverseData

        [Test, TestCaseSource(nameof(Matrix3InverseData))]
        public void TestMatrix3Inverse(Eng_Matrix3x3 m, Eng_Matrix3x3 expected)
        {
            // Perform the test
            Eng_Matrix3x3 i = m.Inverse();
            //Assert
            Assert.AreEqual(expected.M11, Math.Round(i.M11, 4));
            Assert.AreEqual(expected.M12, Math.Round(i.M12, 4));
            Assert.AreEqual(expected.M13, Math.Round(i.M13, 4));

            Assert.AreEqual(expected.M21, Math.Round(i.M21, 4));
            Assert.AreEqual(expected.M22, Math.Round(i.M22, 4));
            Assert.AreEqual(expected.M23, Math.Round(i.M23, 4));

            Assert.AreEqual(expected.M31, Math.Round(i.M31, 4));
            Assert.AreEqual(expected.M32, Math.Round(i.M32, 4));
            Assert.AreEqual(expected.M33, Math.Round(i.M33, 4));
        }//end of TestMatrix3Inverse

        //7.g - Test 4.a - Equality of two 3x3 matrices.
        //    - Test 4.b - Inequality of two 3x3 matrices.
        [Test,
            // 1st to 9th = matrix a
            // 10th to 18th = matrix b
            // 19th to 27th = matrix c
            // Last = expected boolean for both == and !=
            // Instructor Data - MUST NOT DELETEcccccccccccccccccccccc
            TestCase(2, 0, 4, 0, 8, -2, 0, 0, 1, 2.0, 0.0, 4.0, 0.0, 8.0, -2.0, 0.0, 0.0, 1.0, 2.0, 0.0, 4.0, 0.0, 8.0, 2.0, 0.0, 0.0, 1.0, true),
            // Student Data - MUST CHANGE
            TestCase(1, 3, 9, 1, 4, 1, 5, 25, 10, 1, 3, 9, 1, 4, 1, 5, 25, 10, 1, 3, 9, -1, 4, 1, 5, 25, 10, true),
            TestCase(1, 3, 9, -1, 4, 1, 5, 25, 10, 1, 3, 9, 1, 4, 1, 5, 25, 10, 1, 3, 9, -1, 4, 1, 5, 25, 10, false)
        ]
        public void TestMatrix3Equality(
            double am11, double am12, double am13,
            double am21, double am22, double am23,
            double am31, double am32, double am33,
            double bm11, double bm12, double bm13,
            double bm21, double bm22, double bm23,
            double bm31, double bm32, double bm33,
            double cm11, double cm12, double cm13,
            double cm21, double cm22, double cm23,
            double cm31, double cm32, double cm33,
            bool expected)
        {
            // Create Objects for the test
            Eng_Matrix3x3 a = new Eng_Matrix3x3(am11, am12, am13, am21, am22, am23, am31, am32, am33);
            Eng_Matrix3x3 b = new Eng_Matrix3x3(bm11, bm12, bm13, bm21, bm22, bm23, bm31, bm32, bm33);
            Eng_Matrix3x3 c = new Eng_Matrix3x3(cm11, cm12, cm13, cm21, cm22, cm23, cm31, cm32, cm33);
            // Perform the test
            bool testEngineab = a == b;
            bool testEngineac = a != c;
            // Assert
            Assert.AreEqual(expected, testEngineab);
            Assert.AreEqual(expected, testEngineac);
        }//end of TestMatrix3Equality

        //7.h - Test 4.c - Scale a matrix.
        [Test,
            // 1st to 9th = matrix
            // 10th = scale factor
            // Remainder = expected scaled matrix
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(2, 0, 4, 0, 8, -2, 0, 0, 1, 3, 6, 0, 12, 0, 24, -6, 0, 0, 3),
            // Student Data - MUST CHANGE
            TestCase(5, 1, 2, 1, 6, -8, 4, 1, 0, 5, 25, 5, 10, 5, 30, -40, 20, 5, 0)
        ]
        public void TestScaleMatrix3(
            double m11, double m12, double m13,
            double m21, double m22, double m23,
            double m31, double m32, double m33,
            double s,
            double em11, double em12, double em13,
            double em21, double em22, double em23,
            double em31, double em32, double em33)
        {
            // Create Objects for the test
            Eng_Matrix3x3 m = new Eng_Matrix3x3(m11, m12, m13, m21, m22, m23, m31, m32, m33);
            Eng_Matrix3x3 expected = new Eng_Matrix3x3(em11, em12, em13, em21, em22, em23, em31, em32, em33);
            // Perform the test

            Eng_Matrix3x3 actual = m * s;
            //Assert
            Assert.AreEqual(expected, actual);
        }//end of TestScaleMatrix3

        //7.i - Test 4.d - Mulitply two 3x3 matrices.
        public static IEnumerable<Object[]> Matrix3MultData()
        {
            // Instructor Data - MUST NOT DELETE OR MODIFY
            yield return new Object[]
            {
                new Eng_Matrix3x3(2, 0, 4, 0, 8, -2, 0, 0, 1),	// matrix a
                new Eng_Matrix3x3(3, 0, -1, 0, 2, 2, 0, 0, 1),	// matrix b
                new Eng_Matrix3x3(6, 0, 2, 0, 16, 14, 0, 0, 1)	// expected a x b
            };
            // Student Data - YOU NEED TO ADD YOUR DATA BELOW
            yield return new Object[]
            {
                new Eng_Matrix3x3(1, 5, 2, 4, 3, -5, 1, -2, 7),	// matrix a
                new Eng_Matrix3x3(3, 1, 0, -4, 6, 0, -2, 1, 2),	// matrix b
                new Eng_Matrix3x3(-21, 33, 4, 10, 17, -10, -3, -4, 14)	// expected a x b
            };
        }//end of Matrix3MultData

        [Test, TestCaseSource(nameof(Matrix3MultData))]
        public void TestMatrix3Multiply(Eng_Matrix3x3 a, Eng_Matrix3x3 b, Eng_Matrix3x3 expected)
        {
            // Perform the test

            Eng_Matrix3x3 actual = a * b;
            // Assert
            Assert.AreEqual(expected, actual);
        }//end of TestMatrix3Multiply

        //7.j - Test 6.c - Multiplying a 4D vector by a 4x4 matrix.
        public static IEnumerable<Object[]> MultiplyVector3ByMatrix3Data()
        {
            // Instructor Data - MUST NOT DELETE OR MODIFY
            yield return new Object[]
            {
                new Eng_Matrix3x3(3, 0, -4, 0, 2, 3, 0, 0, 1),	// matrix m
                new Eng_Vector3D(2, 3, 1),						// vector v
                new Eng_Vector3D(2, 9, 1)						// expected m x v
            };
            // Student Data - YOU NEED TO ADD YOUR DATA BELOW
            yield return new Object[]
            {
                new Eng_Matrix3x3(5, 2, -1, 1, 0, 5, 1, 0, 0),	// matrix m
                new Eng_Vector3D(5, 2, 7),						// vector v
                new Eng_Vector3D(22, 40, 5)						// expected m x v
            };
        }//end of MultiplyVector3ByMatrix3Data

        [Test, TestCaseSource(nameof(MultiplyVector3ByMatrix3Data))]
        public void TestMultiplyVector3ByMatrix3(Eng_Matrix3x3 m, Eng_Vector3D v, Eng_Vector3D expected)
        {
            // Perform the test
            Eng_Vector3D actual = m * v;
            // Assert
            Assert.AreEqual(expected, actual);
        }//end of TestMultiplyVector3ByMatrix3
        #endregion 

        #region Part 2 - Matrix Transformation in 3D
        //7.a - Test 2.a - Create an Identity matrix.
        [Test,
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(1, 0)
        ]
        public void TestCreateIdentityMatrix4(double one, double zero)
        {
            // Create objects for the test [create a matrix using empty constructor]
            Eng_Matrix4x4 actual = new Eng_Matrix4x4();
            // Perform the test [create the Identity()]
            actual.Identity();
            // Assert
            Assert.AreEqual(one, actual.M11);
            Assert.AreEqual(zero, actual.M12);
            Assert.AreEqual(zero, actual.M13);
            Assert.AreEqual(zero, actual.M14);

            Assert.AreEqual(zero, actual.M21);
            Assert.AreEqual(one, actual.M22);
            Assert.AreEqual(zero, actual.M23);
            Assert.AreEqual(zero, actual.M24);

            Assert.AreEqual(zero, actual.M31);
            Assert.AreEqual(zero, actual.M32);
            Assert.AreEqual(one, actual.M33);
            Assert.AreEqual(zero, actual.M34);

            Assert.AreEqual(zero, actual.M41);
            Assert.AreEqual(zero, actual.M42);
            Assert.AreEqual(zero, actual.M43);
            Assert.AreEqual(one, actual.M44);
        }//end of TestCreateIdentityMatrix4

        //7.b - Test 2.b - Create from Transformation (Scale and Shift).
        [Test,
            // 1st to 3rd = scale in x, y, z
            // 4th to 6th = shift in x, y, z
            // Remainder = expected transformation matrix
            // Instructor Data -MUST NOT DELETE OR MODIFY
            TestCase(2, 3, 4, -4, -2, 3, 2, 0, 0, -4, 0, 3, 0, -2, 0, 0, 4, 3, 0, 0, 0, 1),
            // Student Data - MUST CHANGE
            TestCase(3, 9, 5, -3, 1, 4, 3, 0, 0, -3, 0, 9, 0, 1, 0, 0, 5, 4, 0, 0, 0, 1)
        ]
        public void TestCreate3DTransformationMatrix(
            double scaleX, double scaleY, double scaleZ,
            double shiftX, double shiftY, double shiftZ,
            double m11Exp, double m12Exp, double m13Exp, double m14Exp,
            double m21Exp, double m22Exp, double m23Exp, double m24Exp,
            double m31Exp, double m32Exp, double m33Exp, double m34Exp,
            double m41Exp, double m42Exp, double m43Exp, double m44Exp)
        {
            // Create the objects for the test
            Eng_Matrix4x4 actual = new Eng_Matrix4x4();
            // Perform the test
            actual = actual.Create3DTransformationMatrix(shiftX, shiftY, shiftZ, scaleX, scaleY, scaleZ);
            // Assert
            Assert.AreEqual(m11Exp, Math.Round(actual.M11, 4));
            Assert.AreEqual(m12Exp, Math.Round(actual.M12, 4));
            Assert.AreEqual(m13Exp, Math.Round(actual.M13, 4));
            Assert.AreEqual(m14Exp, Math.Round(actual.M14, 4));

            Assert.AreEqual(m21Exp, Math.Round(actual.M21, 4));
            Assert.AreEqual(m22Exp, Math.Round(actual.M22, 4));
            Assert.AreEqual(m23Exp, Math.Round(actual.M23, 4));
            Assert.AreEqual(m24Exp, Math.Round(actual.M24, 4));

            Assert.AreEqual(m31Exp, Math.Round(actual.M31, 4));
            Assert.AreEqual(m32Exp, Math.Round(actual.M32, 4));
            Assert.AreEqual(m33Exp, Math.Round(actual.M33, 4));
            Assert.AreEqual(m34Exp, Math.Round(actual.M34, 4));

            Assert.AreEqual(m41Exp, Math.Round(actual.M41, 4));
            Assert.AreEqual(m42Exp, Math.Round(actual.M42, 4));
            Assert.AreEqual(m43Exp, Math.Round(actual.M43, 4));
            Assert.AreEqual(m44Exp, Math.Round(actual.M44, 4));
        }//end of TestCreate3DTransformationMatrix

        //7.c - Test 2.c - Create a Roll rotation matrix from an angle in degrees.
        [Test,
            // Instructor Data - MUST NOT DELETE OR MODIFY
            // 1st = roll in degrees (about z-axis)
            // Remainder = expected roll matrix
            TestCase(5, 0.9962, -0.0872, 0, 0, 0.0872, 0.9962, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1),
            // Student Data - MUST CHANGE
            TestCase(27, 0.8910, -0.4540, 0, 0, 0.4540, 0.8910, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1)
        ]
        public void TestCreateRollMatrix(
            double degrees,
            double m11Exp, double m12Exp, double m13Exp, double m14Exp,
            double m21Exp, double m22Exp, double m23Exp, double m24Exp,
            double m31Exp, double m32Exp, double m33Exp, double m34Exp,
            double m41Exp, double m42Exp, double m43Exp, double m44Exp)
        {
            // Create the objects for the test
            Eng_Matrix4x4 actual = new Eng_Matrix4x4();
            // Perform the test
            actual = actual.CreateRollRotationMatrix(degrees);
            // Assert
            Assert.AreEqual(m11Exp, Math.Round(actual.M11, 4));
            Assert.AreEqual(m12Exp, Math.Round(actual.M12, 4));
            Assert.AreEqual(m13Exp, Math.Round(actual.M13, 4));
            Assert.AreEqual(m14Exp, Math.Round(actual.M14, 4));

            Assert.AreEqual(m21Exp, Math.Round(actual.M21, 4));
            Assert.AreEqual(m22Exp, Math.Round(actual.M22, 4));
            Assert.AreEqual(m23Exp, Math.Round(actual.M23, 4));
            Assert.AreEqual(m24Exp, Math.Round(actual.M24, 4));

            Assert.AreEqual(m31Exp, Math.Round(actual.M31, 4));
            Assert.AreEqual(m32Exp, Math.Round(actual.M32, 4));
            Assert.AreEqual(m33Exp, Math.Round(actual.M33, 4));
            Assert.AreEqual(m34Exp, Math.Round(actual.M34, 4));

            Assert.AreEqual(m41Exp, Math.Round(actual.M41, 4));
            Assert.AreEqual(m42Exp, Math.Round(actual.M42, 4));
            Assert.AreEqual(m43Exp, Math.Round(actual.M43, 4));
            Assert.AreEqual(m44Exp, Math.Round(actual.M44, 4));
        }//end of TestCreateRollMatrix

        //7.d - Test 2.d - Create a Pitch rotation matrix from an angle in degrees.
        [Test,
            // 1st = pitch degrees (about x-axis)
            // Remainder = expected pitch matrix
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(5, 1, 0, 0, 0, 0, 0.9962, -0.0872, 0, 0, 0.0872, 0.9962, 0, 0, 0, 0, 1),
            // Student Data - MUST CHANGE
            TestCase(59, 1, 0, 0, 0, 0, 0.5150, -0.8572, 0, 0, 0.8572, 0.5150, 0, 0, 0, 0, 1)
        ]
        public void TestCreatePitchMatrix(
            double degrees,
            double m11Exp, double m12Exp, double m13Exp, double m14Exp,
            double m21Exp, double m22Exp, double m23Exp, double m24Exp,
            double m31Exp, double m32Exp, double m33Exp, double m34Exp,
            double m41Exp, double m42Exp, double m43Exp, double m44Exp)
        {
            // Create the objects for the test
            Eng_Matrix4x4 actual = new Eng_Matrix4x4();
            // Perform the test
            actual = actual.CreatePitchRotationMatrix(degrees);
            // Assert
            Assert.AreEqual(m11Exp, Math.Round(actual.M11, 4));
            Assert.AreEqual(m12Exp, Math.Round(actual.M12, 4));
            Assert.AreEqual(m13Exp, Math.Round(actual.M13, 4));
            Assert.AreEqual(m14Exp, Math.Round(actual.M14, 4));

            Assert.AreEqual(m21Exp, Math.Round(actual.M21, 4));
            Assert.AreEqual(m22Exp, Math.Round(actual.M22, 4));
            Assert.AreEqual(m23Exp, Math.Round(actual.M23, 4));
            Assert.AreEqual(m24Exp, Math.Round(actual.M24, 4));

            Assert.AreEqual(m31Exp, Math.Round(actual.M31, 4));
            Assert.AreEqual(m32Exp, Math.Round(actual.M32, 4));
            Assert.AreEqual(m33Exp, Math.Round(actual.M33, 4));
            Assert.AreEqual(m34Exp, Math.Round(actual.M34, 4));

            Assert.AreEqual(m41Exp, Math.Round(actual.M41, 4));
            Assert.AreEqual(m42Exp, Math.Round(actual.M42, 4));
            Assert.AreEqual(m43Exp, Math.Round(actual.M43, 4));
            Assert.AreEqual(m44Exp, Math.Round(actual.M44, 4));
        }//end of TestCreatePitchMatrix

        //7.e - Test 2.e - Create a Yaw rotation matrix from an angle in degrees.
        [Test,
            // 1st = yaw degrees (about y-axis)
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(5, 0.9962, 0, 0.0872, 0, 0, 1, 0, 0, -0.0872, 0, 0.9962, 0, 0, 0, 0, 1),
            // Student Data - MUST CHANGE
            TestCase(13, 0.9744, 0, 0.2250, 0, 0, 1, 0, 0, -0.2250, 0, 0.9744, 0, 0, 0, 0, 1)
        ]
        public void TestCreateYawMatrix(
            double degrees,
            double m11Exp, double m12Exp, double m13Exp, double m14Exp,
            double m21Exp, double m22Exp, double m23Exp, double m24Exp,
            double m31Exp, double m32Exp, double m33Exp, double m34Exp,
            double m41Exp, double m42Exp, double m43Exp, double m44Exp)
        {
            // Create the objects for the test
            Eng_Matrix4x4 actual = new Eng_Matrix4x4();
            // Perform the test
            actual = actual.CreateYawRotationMatrix(degrees);
            // Assert
            Assert.AreEqual(m11Exp, Math.Round(actual.M11, 4));
            Assert.AreEqual(m12Exp, Math.Round(actual.M12, 4));
            Assert.AreEqual(m13Exp, Math.Round(actual.M13, 4));
            Assert.AreEqual(m14Exp, Math.Round(actual.M14, 4));

            Assert.AreEqual(m21Exp, Math.Round(actual.M21, 4));
            Assert.AreEqual(m22Exp, Math.Round(actual.M22, 4));
            Assert.AreEqual(m23Exp, Math.Round(actual.M23, 4));
            Assert.AreEqual(m24Exp, Math.Round(actual.M24, 4));

            Assert.AreEqual(m31Exp, Math.Round(actual.M31, 4));
            Assert.AreEqual(m32Exp, Math.Round(actual.M32, 4));
            Assert.AreEqual(m33Exp, Math.Round(actual.M33, 4));
            Assert.AreEqual(m34Exp, Math.Round(actual.M34, 4));

            Assert.AreEqual(m41Exp, Math.Round(actual.M41, 4));
            Assert.AreEqual(m42Exp, Math.Round(actual.M42, 4));
            Assert.AreEqual(m43Exp, Math.Round(actual.M43, 4));
            Assert.AreEqual(m44Exp, Math.Round(actual.M44, 4));
        }//end of TestCreateYawMatrix

        //7.f - Test 3.a - Transpose a matrix.
        public static IEnumerable<Object[]> Matrix4TransposeData()
        {
            // Instructor Data - MUST NOT DELETE OR MODIFY
            yield return new Object[]
            {
                new Eng_Matrix4x4(2, 0, 0, -4, 0, 3, 0, -2, 0, 0, 4, 5, 0, 0, 0, 1),	// matrix
                new Eng_Matrix4x4(2, 0, 0, 0, 0, 3, 0, 0, 0, 0, 4, 0, -4, -2, 5, 1)		// expected transpose
            };
            // Student Data - YOU NEED TO ADD YOUR DATA BELOW
            yield return new Object[]
            {
                new Eng_Matrix4x4(5, 1, 6, 8, -1, 5, 4, 3, -7, 6, 7, 6, -2, 4, 6, 7),	// matrix
                new Eng_Matrix4x4(0, 0, 0, 0, 0, 0, 0, 0, -0.5, -1, 0.5, -1, 0, 0, 0, 0)		// expected transpose
            };
        }//end of Matrix4TransposeData

        [Test, TestCaseSource(nameof(Matrix4TransposeData))]
        public void TestMatrix4Transpose(Eng_Matrix4x4 m, Eng_Matrix4x4 expected)
        {
            // Perform the test
            m.Transpose();
            //Assert
            Assert.AreEqual(expected, m);
        }//end of TestMatrix4Transpose

        //7.g - Test 3.b - Calculate the determinant of a matrix.
        //                 HINT: Call the determinant of the Eng_Matrix3x3 class as required.
        [Test,
            // 1st to 16th = matrix
            // Last = expected determinant
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(2, 0, 0, -4, 0, 3, 0, -2, 0, 0, 4, 5, 0, 0, 0, 1, 24),
            // Student Data - MUST CHANGE
            TestCase(5, 1, -4, -6, 1, 9, 3, -7, 5, 6, 9, 6, 4, 5, 2, 0, 1331),
        ]
        public void TestMatrix4Determinant(
            double m11, double m12, double m13, double m14,
            double m21, double m22, double m23, double m24,
            double m31, double m32, double m33, double m34,
            double m41, double m42, double m43, double m44,
            double expected)
        {
            // Create objects for the test
            Eng_Matrix4x4 matrix = new Eng_Matrix4x4(m11, m12, m13, m14, m21, m22, m23, m24, m31, m32, m33, m34, m41, m42, m43, m44);
            double actual;
            // Perform the test
            actual = matrix.Determinant();
            // Assert
            Assert.AreEqual(expected, actual);
        }//end of TestMatrix4Determinant

        //7.h - Test 3.c - Calculate the inverse of a matrix.
        public static IEnumerable<Object[]> Matrix4InverseData()
        {
            // Instructor Data - MUST NOT DELETE OR MODIFY
            yield return new Object[]
            {
                new Eng_Matrix4x4(2, 0, 0, -4, 0, 3, 0, -2, 0, 0, 4, 5, 0, 0, 0, 1),					// matrix
                new Eng_Matrix4x4(0.5, 0, 0, 2, 0, 0.3333, 0, 0.6667, 0, 0, 0.25, -1.25, 0, 0, 0, 1)	// expected inverse
            };
            // Student Data - YOU NEED TO ADD YOUR DATA BELOW
            yield return new Object[]
            {
                new Eng_Matrix4x4(5, 4, 2, -3, 4, 9, 1, 0, 2, 5, 0, 0, 4, 2, 0, 2),					// matrix
                new Eng_Matrix4x4(0.1351, -0.2703, 0.2973, 0.2027, -0.0541, 0.1081, 0.0811, -0.0811, -0.0541, 1.1081, -1.9189, -0.0811, -0.2162, 0.4324, -0.6757, 0.1757)	// expected inverse
            };
        }//end of Matrix4InverseData

        [Test, TestCaseSource(nameof(Matrix4InverseData))]
        public void TestMatrix4Inverse(Eng_Matrix4x4 m, Eng_Matrix4x4 expected)
        {
            // Perform the test
            Eng_Matrix4x4 actual = m.Inverse();
            //Assert
            Assert.AreEqual(expected.M11, Math.Round(actual.M11, 4));
            Assert.AreEqual(expected.M12, Math.Round(actual.M12, 4));
            Assert.AreEqual(expected.M13, Math.Round(actual.M13, 4));
            Assert.AreEqual(expected.M14, Math.Round(actual.M14, 4));

            Assert.AreEqual(expected.M21, Math.Round(actual.M21, 4));
            Assert.AreEqual(expected.M22, Math.Round(actual.M22, 4));
            Assert.AreEqual(expected.M23, Math.Round(actual.M23, 4));
            Assert.AreEqual(expected.M24, Math.Round(actual.M24, 4));

            Assert.AreEqual(expected.M31, Math.Round(actual.M31, 4));
            Assert.AreEqual(expected.M32, Math.Round(actual.M32, 4));
            Assert.AreEqual(expected.M33, Math.Round(actual.M33, 4));
            Assert.AreEqual(expected.M34, Math.Round(actual.M34, 4));

            Assert.AreEqual(expected.M41, Math.Round(actual.M41, 4));
            Assert.AreEqual(expected.M42, Math.Round(actual.M42, 4));
            Assert.AreEqual(expected.M43, Math.Round(actual.M43, 4));
            Assert.AreEqual(expected.M44, Math.Round(actual.M44, 4));

        }//end of TestMatrix4Inverse

        //7.i - Test 4.a - Equality of two 4x4 matrices.
        //    - Test 4.b - Inequality of two 4x4 matrices.
        [Test,
            // 1st to 16th = matrix a
            // 17th to 32nd = matrix b
            // 18th to 48th = matrix c
            // Last = expected boolean for both == and !=
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(
            2, 0, 0, 4, 0, 8, 0, -2, 0, 0, -3, 0, 0, 0, 0, 1,
            2.0, 0.0, 0.0, 4.0, 0.0, 8.0, 0.0, -2.0, 0.0, 0.0, -3.0, 0.0, 0.0, 0.0, 0.0, 1.0,
            2.0, 0.0, 0.0, 4.0, 0.0, 8.0, 0.0, 2.0, 0.0, 0.0, -3.0, 0.0, 0.0, 0.0, 0.0, 1.0,
            true),
            // Student Data - MUST CHANGE
            TestCase(
            1, 5, 26, -7, 2, 0, -6, 4, 1, 7, 6, 1, 6, -5, 1, 6,
            1, 5, 26, -7, 2, 0, -6, 4, 1, 7, 6, 1, 6, -5, 1, 6,
            1, 5, 26, 7, 2, 0, -6, 4, 1, 7, 6, 6, 6, -5, 1, 6,
            true),
            TestCase(
            1, 5, 26, -7, 2, 0, -6, 4, 1, 7, 6, 1, 6, -5, 1, 6,
            1, 5, 26, 7, 2, 0, -6, 4, 1, 7, 6, 1, 6, -5, 1, 6,
            1, 5, 26, -7, 2, 0, -6, 4, 1, 7, 6, 1, 6, -5, 1, 6,
            false)
        ]
        public void TestMatrix4Equality(
            double am11, double am12, double am13, double am14,
            double am21, double am22, double am23, double am24,
            double am31, double am32, double am33, double am34,
            double am41, double am42, double am43, double am44,
            double bm11, double bm12, double bm13, double bm14,
            double bm21, double bm22, double bm23, double bm24,
            double bm31, double bm32, double bm33, double bm34,
            double bm41, double bm42, double bm43, double bm44,
            double cm11, double cm12, double cm13, double cm14,
            double cm21, double cm22, double cm23, double cm24,
            double cm31, double cm32, double cm33, double cm34,
            double cm41, double cm42, double cm43, double cm44,
            bool expected)
        {
            // Create Objects for the test
            Eng_Matrix4x4 a = new Eng_Matrix4x4(am11, am12, am13, am14, am21, am22, am23, am24, am31, am32, am33, am34, am41, am42, am43, am44);
            Eng_Matrix4x4 b = new Eng_Matrix4x4(bm11, bm12, bm13, bm14, bm21, bm22, bm23, bm24, bm31, bm32, bm33, bm34, bm41, bm42, bm43, bm44);
            Eng_Matrix4x4 c = new Eng_Matrix4x4(cm11, cm12, cm13, cm14, cm21, cm22, cm23, cm24, cm31, cm32, cm33, cm34, cm41, cm42, cm43, cm44);
            // Perform the test
            bool testEngineab = a == b;
            bool testEngineac = a != c;
            // Assert
            Assert.AreEqual(expected, testEngineab);
            Assert.AreEqual(expected, testEngineac);
        }//end of TestMatrix4Equality

        //7.j - Test 4.c - Scale a 4x4 matrix.
        [Test,
            // 1st to 16th = matrix
            // 17th = scale factor
            // Remainder = expected scaled matrix
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(2, 0, 0, 4, 0, 8, 0, -2, 0, 0, -3, 0, 0, 0, 0, 1, 3, 6, 0, 0, 12, 0, 24, 0, -6, 0, 0, -9, 0, 0, 0, 0, 3),
            // Student Data - MUST CHANGE
            TestCase(5, 4, 3, 1, -2, 5, 2, 4, -9, 4, -6, 7, 4, 2, 6, 8, 4, 20, 16, 12, 4, -8, 20, 8, 16, -36, 16, -24, 28, 16, 8, 24, 32)
        ]
        public void TestScaleMatrix4(
            double m11, double m12, double m13, double m14,
            double m21, double m22, double m23, double m24,
            double m31, double m32, double m33, double m34,
            double m41, double m42, double m43, double m44,
            double s,
            double m11Exp, double m12Exp, double m13Exp, double m14Exp,
            double m21Exp, double m22Exp, double m23Exp, double m24Exp,
            double m31Exp, double m32Exp, double m33Exp, double m34Exp,
            double m41Exp, double m42Exp, double m43Exp, double m44Exp)
        {
            // Create Objects for the test
            Eng_Matrix4x4 m = new Eng_Matrix4x4(m11, m12, m13, m14, m21, m22, m23, m24, m31, m32, m33, m34, m41, m42, m43, m44);
            // Perform the Test
            Eng_Matrix4x4 actual = m * s;
            // Assert
            Assert.AreEqual(m11Exp, Math.Round(actual.M11, 4));
            Assert.AreEqual(m12Exp, Math.Round(actual.M12, 4));
            Assert.AreEqual(m13Exp, Math.Round(actual.M13, 4));
            Assert.AreEqual(m14Exp, Math.Round(actual.M14, 4));

            Assert.AreEqual(m21Exp, Math.Round(actual.M21, 4));
            Assert.AreEqual(m22Exp, Math.Round(actual.M22, 4));
            Assert.AreEqual(m23Exp, Math.Round(actual.M23, 4));
            Assert.AreEqual(m24Exp, Math.Round(actual.M24, 4));

            Assert.AreEqual(m31Exp, Math.Round(actual.M31, 4));
            Assert.AreEqual(m32Exp, Math.Round(actual.M32, 4));
            Assert.AreEqual(m33Exp, Math.Round(actual.M33, 4));
            Assert.AreEqual(m34Exp, Math.Round(actual.M34, 4));

            Assert.AreEqual(m41Exp, Math.Round(actual.M41, 4));
            Assert.AreEqual(m42Exp, Math.Round(actual.M42, 4));
            Assert.AreEqual(m43Exp, Math.Round(actual.M43, 4));
            Assert.AreEqual(m44Exp, Math.Round(actual.M44, 4));
        }//end of TestScaleMatrix4

        //7.k - Test 4.d - Multiply two 4x4 matrices.
        public static IEnumerable<Object[]> MultuiplyMatrix4Data()
        {
            // Instructor Data - MUST NOT DELETE OR MODIFY
            yield return new Object[]
            {
                new Eng_Matrix4x4(2, 0, 0, 4, 0, 8, 0, -2, 0, 0, -3, 0, 0, 0, 0, 1),		// matrix a
                new Eng_Matrix4x4(6, 0, 0, 12, 0, 24, 0, -6, 0, 0, -9, 0, 0, 0, 0, 1),		// matrix b
                new Eng_Matrix4x4(12, 0, 0, 28, 0, 192, 0, -50, 0, 0, 27, 0, 0, 0, 0, 1)	// expected a x b
            };
            // Student Data - YOU NEED TO ADD YOUR DATA BELOW
            yield return new Object[]
            {
                new Eng_Matrix4x4(5, 6, 4, 8, 1, 0, 3, -5, 0, 4, 0, -5, 1, 4, 0, 6),		// matrix a
                new Eng_Matrix4x4(10, 6, 8, 0, 3, -6, -1, 7, 2, 3, 0, 4, 1, 0, 6, 0),		// matrix b
                new Eng_Matrix4x4(84, 6, 82, 58, 11, 15, -22, 12, 7, -24, -34, 28, 28, -18, 40, 28)	// expected a x b
            };
        }//end of MultuiplyMatrix4Data

        [Test, TestCaseSource(nameof(MultuiplyMatrix4Data))]
        public void TestMultiplyMatrix4(Eng_Matrix4x4 a, Eng_Matrix4x4 b, Eng_Matrix4x4 expected)
        {
            // Perform the test
            Eng_Matrix4x4 actual = a * b;
            // Assert
            Assert.AreEqual(expected, actual);
        }//end of TestMultiplyMatrix4

        //7.l - Test 5.e - Create a 4D vector from a 3D vector.
        public static IEnumerable<Object[]> Vector4FromVector3Data()
        {
            // Instructor Data - MUST NOT DELETE OR MODIFY
            yield return new Object[]
            {
                new Eng_Vector3D(2, 3, 4),		// vector 3D
                new Eng_Vector4D(2, 3, 4, 1)	// expected vector 4D
            };
            // Student Data - YOU NEED TO ADD YOUR DATA BELOW
            yield return new Object[]
            {
                new Eng_Vector3D(7, 24, -2),		// vector 3D
                new Eng_Vector4D(7, 24, -2, 1)	// expected vector 4D
            };
        }//end of Vector4FromVector3Data

        [Test, TestCaseSource(nameof(Vector4FromVector3Data))]
        public void TestCreateVector4FromVector3(Eng_Vector3D v, Eng_Vector4D expected)
        {
            // Perform the test
            Eng_Vector4D actual = new Eng_Vector4D(v);
            // Assert
            Assert.AreEqual(expected, actual);
        }//end of TestCreateVector4FromVector3

        //7.m - Test 6.a - Equality of two 4D vectors.
        //    - Test 6.b - Inequality of two 4D vectors.
        [Test,
            // 1st to 4th = vector a
            // 5th to 8th = vector b
            // Last = expected boolean for both == and !=
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(2, 3, 4, 1, 2.0, 3.0, 4.0, 1.0, 2, -3, 4, 1, true),
            // Student Data - MUST CHANGE
            TestCase(5, 4, 6, 8, 5, 4, 6, 8, -5, 4, 6, 8, true),
            TestCase(5, 4, 6, 8, -5, 4, 6, 8, 5, 4, 6, 8, false)
        ]
        public void TestVector4Equality(double ax, double ay, double az, double aw, double bx, double by, double bz, double bw, double cx, double cy, double cz, double cw, bool expected)
        {
            // Create objects for the test
            Eng_Vector4D testEngineA = new Eng_Vector4D(ax, ay, az, aw);
            Eng_Vector4D testEngineB = new Eng_Vector4D(bx, by, bz, bw);
            Eng_Vector4D testEngineC = new Eng_Vector4D(cx, cy, cz, cw);
            // Perform test
            bool testEngineAB = testEngineA == testEngineB;
            bool testEngineAC = testEngineA != testEngineC;
            // Assert
            Assert.AreEqual(expected, testEngineAB);
            Assert.AreEqual(expected, testEngineAC);
        }//end of TestVector4Equality

        //7.n - Test 6.c - Multiply 4D vector by Eng_Matrix4x4.
        public static IEnumerable<Object[]> MultiplyVector4ByMatrix4Data()
        {
            // Instructor Data - MUST NOT DELETE OR MODIFY
            yield return new Object[]
            {
                new Eng_Vector4D(2, 3, 4, 1),										// vector v
                new Eng_Matrix4x4(2, 0, 0, -2, 0, 8, 0, 3, 0, 0, 3, 4, 0, 0, 0, 1),	// matrix m
                new Eng_Vector4D(2, 27, 16, 1)										// expected m x v
            };
            // Student Data - YOU NEED TO ADD YOUR DATA BELOW
            yield return new Object[]
            {
                new Eng_Vector4D(5, -2, 3, 7),										// vector v
                new Eng_Matrix4x4(4, 3, 0, 6, -7, 0, 2, 0, -4, 3, 5, 4, -1, 5, 0, 0),	// matrix m
                new Eng_Vector4D(56, -29, 17, -15)										// expected m x v
            };
        }//end of MultiplyVector4ByMatrix4Data

        [Test, TestCaseSource(nameof(MultiplyVector4ByMatrix4Data))]
        public void TestMultiplyVector4ByMatrix4(Eng_Vector4D v, Eng_Matrix4x4 m, Eng_Vector4D expected)
        {
            // Perform the test
            Eng_Vector4D actual = v * m;
            // Assert
            Assert.AreEqual(expected, actual);
        }//end of TestMultiplyVector4ByMatrix4

        #endregion
        
        #region Part 3 - Quaternions
        //6.a - Test 2.c - Create from roll, pitch, and yaw angles (all in degrees).
        [Test,
            // 1st to 3rd = roll, pitch, yaw in degrees
            // Remainder = expected quaternion
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(15, 10, 5, 0.98722829, 0.09199968, 0.03171637, 0.12613659),
            // Student Data - MUST CHANGE
            TestCase(26, 41, 7, 0.91577241, 0.35345838, -0.02291569, 0.18948070)
        ]

        public void TestQuaternion(
            double roll, double pitch, double yaw,
            double expectedQw, double expectedQx, double expectedQy, double expectedQz)
        {
            // Create Objects for the test
            Eng_Quaternion actual = new Eng_Quaternion(roll, pitch, yaw);
            // Perform the test

            // Assert (round to 8 decimal places)
            Assert.AreEqual(expectedQw, Math.Round(actual.W, 8));
            Assert.AreEqual(expectedQx, Math.Round(actual.X, 8));
            Assert.AreEqual(expectedQy, Math.Round(actual.Y, 8));
            Assert.AreEqual(expectedQz, Math.Round(actual.Z, 8));
        }//end of TestQuaternion

        //6.b - Test 3.a - Create Matrix from Quaternion.
        public static IEnumerable<Object[]> QuaternionToMatrixData()
        {
            // Instructor Data - MUST NOT DELETE OR MODIFY
            yield return new Object[]
            {
                new Eng_Quaternion(15, 10, 5), 	// create a Quaternion from angles to avoid having to use rounded values
                new Eng_Matrix4x4(
                    0.9662, -0.2432, 0.0858, 0,
                    0.2549, 0.9513, -0.1736, 0,
                    -0.0394, 0.1897, 0.9811, 0,
                    0, 0, 0, 1)					// expected matrix
            };
            // Student Data - YOU NEED TO ADD YOUR DATA BELOW
            yield return new Object[]
           {
                new Eng_Quaternion(26, 41, 7), 	// create a Quaternion from angles to avoid having to use rounded values
                new Eng_Matrix4x4(
                    0.9271, -0.3632, 0.0920, 0,
                    0.3308, 0.6783, -0.6561, 0,
                    0.1759, 0.6387, 0.7491, 0,
                    0, 0, 0, 1)                 // expected matrix
           };
        }//end of QuaternionToMatrixData

        [Test, TestCaseSource(nameof(QuaternionToMatrixData))]
        public void TestQuaternionToMatrix(Eng_Quaternion q, Eng_Matrix4x4 expected)
        {
            // Perform the test
            Eng_Matrix4x4 actual = q.ConvertToMatrix();
            // Assert
            Assert.AreEqual(expected.M11, Math.Round(actual.M11, 4));
            Assert.AreEqual(expected.M12, Math.Round(actual.M12, 4));
            Assert.AreEqual(expected.M13, Math.Round(actual.M13, 4));
            Assert.AreEqual(expected.M14, Math.Round(actual.M14, 4));

            Assert.AreEqual(expected.M21, Math.Round(actual.M21, 4));
            Assert.AreEqual(expected.M22, Math.Round(actual.M22, 4));
            Assert.AreEqual(expected.M23, Math.Round(actual.M23, 4));
            Assert.AreEqual(expected.M24, Math.Round(actual.M24, 4));

            Assert.AreEqual(expected.M31, Math.Round(actual.M31, 4));
            Assert.AreEqual(expected.M32, Math.Round(actual.M32, 4));
            Assert.AreEqual(expected.M33, Math.Round(actual.M33, 4));
            Assert.AreEqual(expected.M34, Math.Round(actual.M34, 4));

            Assert.AreEqual(expected.M41, Math.Round(actual.M41, 4));
            Assert.AreEqual(expected.M42, Math.Round(actual.M42, 4));
            Assert.AreEqual(expected.M43, Math.Round(actual.M43, 4));
            Assert.AreEqual(expected.M44, Math.Round(actual.M44, 4));
        }//end of TestQuaternionToMatrix

        //6.c - Test 3.b - Create rotation angles (in degrees) from Quaternion.
        [Test,
            // 1st to 4th = quaternion
            // 5th to 7th = expected angles (roll, pitch, yaw) in degrees
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(0.98722829, 0.09199968, 0.03171637, 0.12613659, 15, 10, 5),
            // Student Data - MUST CHANGE
            TestCase(0.91577241, 0.35345838, -0.02291569, 0.18948070, 26, 41, 7),
        ]
        public void TestQuaterionToEuler(
            double qW, double qX, double qY, double qZ,
            double expectedRoll, double expectedPitch, double expectedYaw)
        {
            // Create Objects for the test
            Eng_Quaternion q = new Eng_Quaternion(qW, qX, qY, qZ);
            // Perform the test
            Tuple<double, double, double> actual = q.ConvertToEuler();
            
            // Assert
            Assert.AreEqual(expectedRoll, Math.Round(actual.Item1,0));
            Assert.AreEqual(expectedPitch, Math.Round(actual.Item2,0));
            Assert.AreEqual(expectedYaw, Math.Round(actual.Item3, 0));
        }//end of TestQuaterionToEuler

        //6.d - Test 4.a - Equality of two Quaternions.
        //    - Test 4.b - Inequality of two Quaternions.
        [Test,
            // 1st to 3rd = angles (in degrees) to create a quaternion
            // 4th to 7th = quaternion
            // Last = expected boolean for both == and !=
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(15, 10, 5, 0.98722829, 0.09199968, 0.03171637, 0.12613659, 0.98722829, 0.09199968, -0.03171637, 0.12613659, true),
            // Student Data - MUST CHANGE
            TestCase(26, 41, 7, 0.91577241, 0.35345838, -0.02291569, 0.18948070, 0.91577241, 0.35345838, 0.02291569, 0.18948070, true),
            TestCase(26, 41, 7, 0.91577241, 0.35345838, 0.02291569, 0.18948070, 0.91577241, 0.35345838, -0.02291569, 0.18948070, false)
        ]
        public void TestQuaternionEquality(double aRoll, double aPitch, double aYaw, double bqw, double bqx, double bqy, double bqz, double cqw, double cqx, double cqy, double cqz, bool expected)
        {
            // Create Objects for the test
            Eng_Quaternion a = new Eng_Quaternion(aRoll, aPitch, aYaw);
            Eng_Quaternion b = new Eng_Quaternion(bqw, bqx, bqy, bqz);
            Eng_Quaternion c = new Eng_Quaternion(cqw, cqx, cqy, cqz);
            // Perform the test (round all values to 8 decimal places before testing) man i missed this f**k
            a.W = Math.Round(a.W, 8);
            a.X = Math.Round(a.X, 8);
            a.Y = Math.Round(a.Y, 8);
            a.Z = Math.Round(a.Z, 8);
            bool testQuaternionAB = a == b;
            bool testQuaternionAC = a != c;
            // Assert
            Assert.AreEqual(expected, testQuaternionAB);
            Assert.AreEqual(expected, testQuaternionAC);
        }//end of TestQuaternionEquality

        //6.e - Test 5.a - Multiplying a 4D vector by a Quaternion.
        //                 HINT: Create a 4D vector from a 3D vector.
        public static IEnumerable<Object[]> MultiplyVector4ByQuaternionData()
        {
            // Instructor Data - MUST NOT DELETE OR MODIFY
            yield return new Object[]
            {
                new Eng_Vector4D(2, -3, 4, 1),					// vector v
                new Eng_Quaternion(5,-10, 15),                  // Quaternion q
                new Eng_Vector4D(3.3231, -2.0769, 3.6937, 1)    // expected q * v
            };
            // Student Data - YOU NEED TO ADD YOUR DATA BELOW
            yield return new Object[]
            {
                new Eng_Vector4D(5, -7, 2, 1),					// vector v
                new Eng_Quaternion(26,41, 7),                  // Quaternion q
                new Eng_Vector4D(3.3231, -2.0769, 3.6937, 1)    // expected q * v
            };
        }//end of MultiplyVector4ByQuaternionData

        [Test, TestCaseSource(nameof(MultiplyVector4ByQuaternionData))]
        public void TestMultilyVector4ByQuaternion(Eng_Vector4D v, Eng_Quaternion q, Eng_Vector4D expected)
        {
            // Perform the test
            Eng_Vector4D actual = v * q;
            // Assert
            Assert.AreEqual(expected, actual);
        }//end of TestMultilyVector4ByQuaternion

        #endregion
    }//eoc
}//eon

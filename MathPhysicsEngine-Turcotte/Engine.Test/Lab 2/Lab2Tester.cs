﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using NUnit.Framework;
using Engine.Mathematics;
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
            TestCase(25, 0.9063, -0.4226, 0, 0.4226, 0.9063, 0, 0, 0, 1)
        ]

        public void TestCreate2DRotationMatrix(
            double degrees,
            double m11Exp, double m12Exp, double m13Exp,
            double m21Exp, double m22Exp, double m23Exp,
            double m31Exp, double m32Exp, double m33Exp)
        {
            // Create the objects for the test
            
            // Perform the test
            
            // Assert
            
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
            TestCase(2, 3, -4, -2, 2, 0, -4, 0, 3, -2, 0, 0, 1)
        ]

        public void TestCreate2DTransformationMatrix(
            double scaleX, double scaleY, double shiftX, double shiftY,
            double m11Exp, double m12Exp, double m13Exp,
            double m21Exp, double m22Exp, double m23Exp,
            double m31Exp, double m32Exp, double m33Exp)
        {
            // Create the objects for the test
            
            // Perform the test
           
            // Assert
            
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

        }//end of Matrix3TransposeData

        [Test, TestCaseSource(nameof(Matrix3TransposeData))]
        public void TestMatrix3Transpose(Eng_Matrix3x3 m, Eng_Matrix3x3 expected)
        {
            // Perform the test
            
            //Assert
            
        }//end of TestMatrix3Transpose

        //7.e - Test 3.b - Calculate the determinant of a matrix.
        [Test,
            // 1st to 9th = matrix
            // Last = expected determinant
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(2, 0, 4, 0, 3, -2, 0, 0, 1, 6),
            // Student Data - MUST CHANGE
            TestCase(2, 0, 4, 0, 3, -2, 0, 0, 1, 6)
        ]

        public void TestMatrix3Determinant(
            double m11, double m12, double m13, 
            double m21, double m22, double m23, 
            double m31, double m32, double m33, 
            double expected)
        {
            // Create objects for the test
            
            // Perform the test
           
            // Assert
            
        }//end of TestMatrix3Determinant

        //7.f - Test 3.c - Calculate the inverse of a matrix.
        public static IEnumerable<Object[]> Matrix3InverseData()
        {
            // Instructor Data - MUST NOT DELETE OR MODIFY
            yield return new Object[]
            {
                new Eng_Matrix3x3(2, 0, 4, 0, 8, -2, 0, 0, 1),				// matrix
                new Eng_Matrix3x3(0.5, 0, -2, 0, 0.125, 0.25, 0, 0, 1)	// expected inverse
            };
            // Student Data - YOU NEED TO ADD YOUR DATA BELOW

        }//end of Matrix3InverseData

        [Test, TestCaseSource(nameof(Matrix3InverseData))]
        public void TestMatrix3Inverse(Eng_Matrix3x3 m, Eng_Matrix3x3 expected)
        {
            // Perform the test
            
            //Assert
            
        }//end of TestMatrix3Inverse

        //7.g - Test 4.a - Equality of two 3x3 matrices.
		//    - Test 4.b - Inequality of two 3x3 matrices.
        [Test,
            // 1st to 9th = matrix a
            // 10th to 18th = matrix b
			// 19th to 27th = matrix c
            // Last = expected boolean for both == and !=
            // Instructor Data - MUST NOT DELETEcccccccccccccccccccccc
            TestCase(2, 0, 4, 0, 8, -2, 0, 0, 1, 2.0, 0.0, 4.0, 0.0, 8.0, -2.0, 0.0, 0.0, 1.0,2.0, 0.0, 4.0, 0.0, 8.0, 2.0, 0.0, 0.0, 1.0, true),
            // Student Data - MUST CHANGE
            TestCase(2, 0, 4, 0, 8, -2, 0, 0, 1, 2.0, 0.0, 4.0, 0.0, 8.0, -2.0, 0.0, 0.0, 1.0, true)
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
            
            // Perform the test
            
            // Assert
           
        }//end of TestMatrix3Equality

        //7.h - Test 4.c - Scale a matrix.
        [Test,
            // 1st to 9th = matrix
            // 10th = scale factor
            // Remainder = expected scaled matrix
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(2, 0, 4, 0, 8, -2, 0, 0, 1, 3, 6, 0, 12, 0, 24, -6, 0, 0, 3),
            // Student Data - MUST CHANGE
            TestCase(2, 0, 4, 0, 8, -2, 0, 0, 1, 3, 6, 0, 12, 0, 24, -6, 0, 0, 3)
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
           
            // Perform the test
            
            //Assert
            
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

        }//end of Matrix3MultData

        [Test, TestCaseSource(nameof(Matrix3MultData))]
        public void TestMatrix3Multiply(Eng_Matrix3x3 a, Eng_Matrix3x3 b, Eng_Matrix3x3 expected)
        {
            // Perform the test
           
            // Assert
            
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

        }//end of MultiplyVector3ByMatrix3Data
		
        [Test, TestCaseSource(nameof(MultiplyVector3ByMatrix3Data))]
        public void TestMultiplyVector3ByMatrix3(Eng_Matrix3x3 m, Eng_Vector3D v, Eng_Vector3D expected)
        {
            // Perform the test
            
            // Assert
            
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
            
            // Perform the test [create the Identity()]
            
            // Assert
           
        }//end of TestCreateIdentityMatrix4

        //7.b - Test 2.b - Create from Transformation (Scale and Shift).
        [Test,
            // 1st to 3rd = scale in x, y, z
            // 4th to 6th = shift in x, y, z
            // Remainder = expected transformation matrix
            // Instructor Data -MUST NOT DELETE OR MODIFY
            TestCase(2, 3, 4, -4, -2, 3, 2, 0, 0, -4, 0, 3, 0, -2, 0, 0, 4, 3, 0, 0, 0, 1),
            // Student Data - MUST CHANGE
            TestCase(2, 3, 4, -4, -2, 3, 2, 0, 0, -4, 0, 3, 0, -2, 0, 0, 4, 3, 0, 0, 0, 1)
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
            
            // Perform the test
            
            // Assert
            
        }//end of TestCreate3DTransformationMatrix

        //7.c - Test 2.c - Create a Roll rotation matrix from an angle in degrees.
        [Test,
            // Instructor Data - MUST NOT DELETE OR MODIFY
            // 1st = roll in degrees (about z-axis)
            // Remainder = expected roll matrix
            TestCase(5, 0.9962, -0.0872, 0, 0, 0.0872, 0.9962, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1),
            // Student Data - MUST CHANGE
            TestCase(5, 0.9962, -0.0872, 0, 0, 0.0872, 0.9962, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1)
        ]
        public void TestCreateRollMatrix(
            double degrees,
            double m11Exp, double m12Exp, double m13Exp, double m14Exp,
            double m21Exp, double m22Exp, double m23Exp, double m24Exp,
            double m31Exp, double m32Exp, double m33Exp, double m34Exp,
            double m41Exp, double m42Exp, double m43Exp, double m44Exp)
        {
            // Create the objects for the test
            
            // Perform the test
            
            // Assert
            
        }//end of TestCreateRollMatrix

        //7.d - Test 2.d - Create a Pitch rotation matrix from an angle in degrees.
        [Test,
            // 1st = pitch degrees (about x-axis)
            // Remainder = expected pitch matrix
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(5, 1, 0, 0, 0, 0, 0.9962, -0.0872, 0, 0, 0.0872, 0.9962, 0, 0, 0, 0, 1),
            // Student Data - MUST CHANGE
            TestCase(5, 1, 0, 0, 0, 0, 0.9962, -0.0872, 0, 0, 0.0872, 0.9962, 0, 0, 0, 0, 1)
        ]
        public void TestCreatePitchMatrix(
            double degrees,
            double m11Exp, double m12Exp, double m13Exp, double m14Exp,
            double m21Exp, double m22Exp, double m23Exp, double m24Exp,
            double m31Exp, double m32Exp, double m33Exp, double m34Exp,
            double m41Exp, double m42Exp, double m43Exp, double m44Exp)
        {
            // Create the objects for the test
            
            // Perform the test
           
            // Assert
           
        }//end of TestCreatePitchMatrix

        //7.e - Test 2.e - Create a Yaw rotation matrix from an angle in degrees.
        [Test,
            // 1st = yaw degrees (about y-axis)
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(5, 0.9962, 0, 0.0872, 0, 0, 1, 0, 0, -0.0872, 0, 0.9962, 0, 0, 0, 0, 1),
            // Student Data - MUST CHANGE
            TestCase(5, 0.9962, 0, 0.0872, 0, 0, 1, 0, 0, -0.0872, 0, 0.9962, 0, 0, 0, 0, 1)
        ]
        public void TestCreateYawMatrix(
            double degrees,
            double m11Exp, double m12Exp, double m13Exp, double m14Exp,
            double m21Exp, double m22Exp, double m23Exp, double m24Exp,
            double m31Exp, double m32Exp, double m33Exp, double m34Exp,
            double m41Exp, double m42Exp, double m43Exp, double m44Exp)
        {
            // Create the objects for the test
            
            // Perform the test
            
            // Assert
            
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

        }//end of Matrix4TransposeData
		
        [Test, TestCaseSource(nameof(Matrix4TransposeData))]
        public void TestMatrix4Transpose(Eng_Matrix4x4 m, Eng_Matrix4x4 expected)
        {
            // Perform the test
           
            //Assert
            
        }//end of TestMatrix4Transpose

        //7.g - Test 3.b - Calculate the determinant of a matrix.
		//                 HINT: Call the determinant of the Eng_Matrix3x3 class as required.
        [Test,
            // 1st to 16th = matrix
            // Last = expected determinant
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(2, 0, 0, -4, 0, 3, 0, -2, 0, 0, 4, 5, 0, 0, 0, 1, 24),
            // Student Data - MUST CHANGE
            TestCase(2, 0, 0, -4, 0, 3, 0, -2, 0, 0, 4, 5, 0, 0, 0, 1, 24)
        ]
        public void TestMatrix4Determinant(
            double m11, double m12, double m13, double m14,
            double m21, double m22, double m23, double m24,
            double m31, double m32, double m33, double m34,
            double m41, double m42, double m43, double m44,
            double expected)
        {
            // Create objects for the test
            
            // Perform the test
           
            // Assert
            
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

        }//end of Matrix4InverseData
		
        [Test, TestCaseSource(nameof(Matrix4InverseData))]
        public void TestMatrix4Inverse(Eng_Matrix4x4 m, Eng_Matrix4x4 expected)
        {
            // Perform the test
            
            //Assert
            
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
            2, 0, 0, 4, 0, 8, 0, -2, 0, 0, -3, 0, 0, 0, 0, 1,
            2.0, 0.0, 0.0, 4.0, 0.0, 8.0, 0.0, -2.0, 0.0, 0.0, -3.0, 0.0, 0.0, 0.0, 0.0, 1.0,
            2.0, 0.0, 0.0, 4.0, 0.0, 8.0, 0.0, 2.0, 0.0, 0.0, -3.0, 0.0, 0.0, 0.0, 0.0, 1.0,
            true),
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
            
            // Perform the test
            
            // Assert
            
        }//end of TestMatrix4Equality

        //7.j - Test 4.c - Scale a 4x4 matrix.
        [Test,
            // 1st to 16th = matrix
            // 17th = scale factor
            // Remainder = expected scaled matrix
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(2, 0, 0, 4, 0, 8, 0, -2, 0, 0, -3, 0, 0, 0, 0, 1, 3, 6, 0, 0, 12, 0, 24, 0, -6, 0, 0, -9, 0, 0, 0, 0, 3),
            // Student Data - MUST CHANGE
            TestCase(2, 0, 0, 4, 0, 8, 0, -2, 0, 0, -3, 0, 0, 0, 0, 1, 3, 6, 0, 0, 12, 0, 24, 0, -6, 0, 0, -9, 0, 0, 0, 0, 3)
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
           
            // Perform the Test
            
            // Assert
            
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

        }//end of MultuiplyMatrix4Data
		
        [Test, TestCaseSource(nameof(MultuiplyMatrix4Data))]
        public void TestMultiplyMatrix4(Eng_Matrix4x4 a, Eng_Matrix4x4 b, Eng_Matrix4x4 expected)
        {
            // Perform the test
           
            // Assert
            
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

        }//end of Vector4FromVector3Data
		
        [Test, TestCaseSource(nameof(Vector4FromVector3Data))]
        public void TestCreateVector4FromVector3(Eng_Vector3D v, Eng_Vector4D expected)
        {
            // Perform the test
           
            // Assert
            
        }//end of TestCreateVector4FromVector3

        //7.m - Test 6.a - Equality of two 4D vectors.
		//    - Test 6.b - Inequality of two 4D vectors.
        [Test,
            // 1st to 4th = vector a
            // 5th to 8th = vector b
            // Last = expected boolean for both == and !=
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(2, 3, 4, 1, 2.0, 3.0, 4.0, 1.0, true),
            // Student Data - MUST CHANGE
            TestCase(2, 3, 4, 1, 2.0, 3.0, 4.0, 1.0, true)
        ]
        public void TestVector4Equality(double ax, double ay, double az, double aw, double bx, double by, double bz, double bw, bool expected)
        {
            // Create objects for the test
            
            // Perform the test
           
            // Assert
            
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

        }//end of MultiplyVector4ByMatrix4Data
		
        [Test, TestCaseSource(nameof(MultiplyVector4ByMatrix4Data))]
        public void TestMultiplyVector4ByMatrix4(Eng_Vector4D v, Eng_Matrix4x4 m, Eng_Vector4D expected)
        {
            // Perform the test
            
            // Assert
            
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
            TestCase(15, 10, 5, 0.98722829, 0.09199968, 0.03171637, 0.12613659)
        ]

        public void TestQuaternion(
            double roll, double pitch, double yaw,
            double expectedQw, double expectedQx, double expectedQy, double expectedQz)
        {
            // Create Objects for the test
            
            // Perform the test
            
            // Assert (round to 8 decimal places)
            
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

        }//end of QuaternionToMatrixData
		
        [Test, TestCaseSource(nameof(QuaternionToMatrixData))]
        public void TestQuaternionToMatrix(Eng_Quaternion q, Eng_Matrix4x4 expected)
        {
            // Perform the test
           
            // Assert
            
        }//end of TestQuaternionToMatrix

        //6.c - Test 3.b - Create rotation angles (in degrees) from Quaternion.
        [Test,
            // 1st to 4th = quaternion
            // 5th to 7th = expected angles (roll, pitch, yaw) in degrees
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(0.98722829, 0.09199968, 0.03171637, 0.12613659, 15, 10, 5),
            // Student Data - MUST CHANGE
            TestCase(0.98722829, 0.09199968, 0.03171637, 0.12613659, 15, 10, 5)
        ]
        public void TestQuaterionToEuler(
            double qW, double qX, double qY, double qZ,
            double expectedRoll, double expectedPitch, double expectedYaw)
        {
            // Create Objects for the test
            
            // Perform the test
            
            // Assert
            
        }//end of TestQuaterionToEuler

        //6.d - Test 4.a - Equality of two Quaternions.
		//    - Test 4.b - Inequality of two Quaternions.
        [Test,
            // 1st to 3rd = angles (in degrees) to create a quaternion
            // 4th to 7th = quaternion
            // Last = expected boolean for both == and !=
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(15, 10, 5,  0.98722829, 0.09199968, 0.03171637, 0.12613659, true),
            // Student Data - MUST CHANGE
            TestCase(15, 10, 5, 0.98722829, 0.09199968, 0.03171637, 0.12613659, true)
        ]
        public void TestQuaternionEquality(double roll, double pitch, double yaw, double qw, double qx, double qy, double qz, bool expected)
        {
            // Create Objects for the test
            
            // Perform the test (round all values to 8 decimal places before testing)
           
            // Assert
            
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
			
        }//end of MultiplyVector4ByQuaternionData
		
		 [Test, TestCaseSource(nameof(MultiplyVector4ByQuaternionData))]
        public void TestMultilyVector4ByQuaternion(Eng_Vector4D v, Eng_Quaternion q, Eng_Vector4D expected)
        {
            // Perform the test
            
            // Assert
            
        }//end of TestMultilyVector4ByQuaternion

        #endregion
    }//eoc
}//eon
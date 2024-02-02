using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using NUnit.Framework;
using Engine.Mathematics;
using NUnit.Framework.Constraints;
#endregion

namespace Engine.Tests.Lab1
{
    [TestFixture]
    public class Lab1Tester
    {
        #region Part 1 - Trigonometry - Complete
        //2.a - Test 1.a - A method to convert degrees to radians.
        [Test,
            // 1st = degrees
            // 2nd = expected radians
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(30, 0.5236),
            // Student Data - MUST Change
            TestCase(45, 0.7854)
        ]

        public void TestToRadians(double degrees, double expected)
        {
            // Perform test
            double returnedValue;

            returnedValue = Functions.DegreesToRadians(degrees);
            // Assert
            Assert.AreEqual(expected, Math.Round(returnedValue,4));
            
        }//end of TestToRadians

        //2.b - Test 1.b - A method to convert radians to degrees.
        [Test,
            // 1st = radians
            // 2nd = expected degrees
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(0.6283, 35.9989),
            // Student Data - MUST CHANGE
            TestCase(0.3257,18.6612)
        ]

        public void TestToDegrees(double radians, double expected)
        {
            // Perform test
            double returnedValue;

            returnedValue = Functions.RadiansToDegrees(radians);
            // Assert
            Assert.AreEqual(expected, Math.Round(returnedValue, 4));

        }//end of TestToDegrees

        //2.c - Test 1.c - A method to solve a right triangle given an angle in degrees and the hypotenuse;
		//                 returns a Tuple<double, double> for the missing sides (adjacent, opposite).
        [Test,
            // 1st = theta in degrees
            // 2nd = hypotenuse
            // 3rd = expected adjacent
            // 4th = expected opposite
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(25, 6, 5.4378, 2.5357),
            // Student Data - MUST CHANGE
            TestCase(45, 3, 2.1213, 2.1213)
        ]

        public void TestCalculateAdjacentOpposite(double degrees, double hypotenuse, double adjacent, double opposite)
        {
            // Perform test
            Tuple<double, double> actual = Functions.FindAdjacentAndOpposite(degrees, hypotenuse);
            // Assert
            Assert.AreEqual(adjacent, Math.Round(actual.Item1, 4));
            Assert.AreEqual(opposite, Math.Round(actual.Item2, 4));

        }//end of TestCalculateAdjacentOpposite

        //2.d - Test 1.d - A method to solve a right triangle given an angle in degrees and the side opposite;
		//                 returns a Tuple<double, double> for the missing sides (adjacent, hypotenuse).
        [Test,
            // 1st = theta in degrees
            // 2nd = opposite
            // 3rd = expected adjacent
            // 4th = expected hypotenuse
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(25, 6, 12.867, 14.1972),
            // Student Data - MUST CHANGE
            TestCase(35, 3, 4.2844, 5.2303)
        ]

        public void TestCalculateAdjacentHypotenuse(double degrees, double opposite, double adjacent, double hypotenuse)
        {
            // Perform test
            Tuple<double, double> actual = Functions.FindAdjacentAndHypotenuse(degrees, opposite);
            // Assert
            Assert.AreEqual(adjacent, Math.Round(actual.Item1, 4));
            Assert.AreEqual(hypotenuse, Math.Round(actual.Item2, 4));
        }//end of TestCalculateAdjacentHypotenuse

        //2.e - Test 1.e - A method to solve a right triangle given an angle in degrees and the side adjacent;
		//                 returns a Tuple<double, double> for the missing sides (opposite, hypotenuse).
        [Test,
            // 1st = theta in degrees
            // 2nd = adjacent
            // 3rd = expected opposite
            // 4th = expected hypotenuse
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(25, 6, 2.7978, 6.6203),
            // Student Data - MUST CHANGE
            TestCase(75, 4, 14.9282, 15.4548)
        ]

        public void TestCalculateOppositeHypotenuse(double degrees, double adjacent, double opposite, double hypotenuse)
        {
            // Perform test
            Tuple<double, double> actual = Functions.FindOppositeAndHypotenuse(degrees, adjacent);
            // Assert
            Assert.AreEqual(opposite, Math.Round(actual.Item1, 4));
            Assert.AreEqual(hypotenuse, Math.Round(actual.Item2, 4));
        }//end of TestCalculateOppositeHypotenuse

        //2.f - Test 1.f - A method to solve a right triangle given side opposite and side adjacent;
		//                 returns a Tuple<double, double> for the missing side and the angle in degrees.
        [Test,
            // 1st = adjacent
            // 2nd = opposite
            // 3rd = expected hypotenuse
            // 4th = expected theta in degrees
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(3, 4, 5, 53.1301),
            // Student Data - MUST CHANGE
            TestCase(8, 2, 8.2462, 14.0362)
        ]

        public void TestCalculateHypotenuseTheta(double adjacent, double opposite, double hypotenuse, double degrees)
        {
            // Perform test
            Tuple<double, double> actual = Functions.FindHypotenuseAndDegree(opposite,adjacent);
            // Assert
            Assert.AreEqual(hypotenuse, Math.Round(actual.Item1, 4));
            double actualDegrees = Functions.RadiansToDegrees(actual.Item2);
            Assert.AreEqual(degrees, Math.Round(actualDegrees, 4));
        }//end of TestCalculateHypotenuseTheta

        //2.g - Test 1.g - A method to solve a right triangle given side opposite and hypotenuse;
		//                 returns a Tuple<double, double> for the missing side and the angle in degrees.
        [Test,
            // 1st = opposite
            // 2nd = hypotenuse
            // 3rd = expected adjacent
            // 4th = expected theta in degrees
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(3, 4, 2.6458, 48.5904),
            // Student Data - MUST CHANGE
            TestCase(5, 6, 3.3166, 56.4427)
        ]

        public void TestCalculateAdjacentTheta(double opposite, double hypotenuse, double adjacent, double degrees)
        {
            // Perform test
            Tuple<double, double> actual = Functions.FindAdjacentAndDegree(opposite, hypotenuse);
            // Assert
            Assert.AreEqual(adjacent, Math.Round(actual.Item1, 4));
            double actualDegrees = Functions.RadiansToDegrees(actual.Item2);
            Assert.AreEqual(degrees, Math.Round(actualDegrees, 4));
        }//end of TestCalculateAdjacentTheta

        //2.h - Test 1.h - A method to solve a right triangle given side adjacent and hypotenuse;
		//                 returns a Tuple<double, double> for the missing side and the angle in degrees.
        [Test,
            // 1st = adjacent
            // 2nd = hypotenuse
            // 3rd = expected opposite
            // 4th = expected theta in degrees
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(3, 4, 2.6458, 41.4096),
            // Student Data - MUST CHANGE
            TestCase(3, 9, 8.4853, 70.5288)
        ]

        public void TestCalculateOppositeTheta(double adjacent, double hypotenuse, double opposite, double degrees)
        {
            // Perform test
            Tuple<double, double> actual = Functions.FindOppositeAndDegree(adjacent, hypotenuse);
            // Assert
            Assert.AreEqual(opposite, Math.Round(actual.Item1, 4));
            double actualDegrees = Functions.RadiansToDegrees(actual.Item2);
            Assert.AreEqual(degrees, Math.Round(actualDegrees, 4));
        }//end of TestCalculateOppositeTheta
        #endregion

        #region Part 2 - 2D Vectors - Complete
        //4.a - Test 2.a - Magnitude of a 2D vector.
        [Test,
            // 1st = vector x component
            // 2nd = vector y component
            // 3rd = expected magnitude
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(3, 4, 5),
            // Student Data - MUST CHANGE
            TestCase(10, 5, 11.1803)
        ]

        public void TestMagnitudeVector2(double x, double y, double expected)
        {
            // Create Objects for the test
            Eng_Vector2D testEngine = new Eng_Vector2D(x, y);
            // Perform the test
            double actual = testEngine.Magnitude();
            // Assert
            Assert.AreEqual(expected, Math.Round(actual, 4));           

        }//end of TestMagnitudeVector2

        //4.b - Test 2.b - The Dot Product of two 2D vectors.
        [Test,
            // 1st - 2nd = vector a
            // 3rd - 4th = vector b
            // 5th = expected dot product
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(3, 4, 6, 9, 54),
            // Student Data - MUST CHANGE
            TestCase(5, 2, 4, 3, 26)
        ]

        public void TestDotProductVector2(double ax, double ay, double bx, double by, double expected)
        {
            // Create Objects for the test
            Eng_Vector2D testEngineA = new Eng_Vector2D(ax, ay);
            Eng_Vector2D testEngineB = new Eng_Vector2D(bx, by);
            // Perform the test
            double actual = testEngineA.DotProduct(testEngineB);
            // Assert
            Assert.AreEqual(expected, Math.Round(actual, 4));

        }//end of TestDotProductVector2

        //4.c - Test 2.c - The angle between two 2D vectors.
        [Test,
            // 1st - 2nd = vector a
            // 3rd - 4th = vector b
            // 5th = expected angle between a and b in degrees
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(3, 4, 6, 9, 3.1798),
            // Student Data - MUST CHANGE
            TestCase(6, 3, 4, 5, 24.7751)
        ]

        public void TestAngleBetweenVector2s(double ax, double ay, double bx, double by, double expected)
        {
            // Create Objects for the test
            Eng_Vector2D testEngineA = new Eng_Vector2D(ax, ay);
            Eng_Vector2D testEngineB = new Eng_Vector2D(bx, by);
            // Act - performing the action
            double actual = testEngineA.AngleBetweenVectors(testEngineB);
            // Assert - did we get back the correct answer
            Assert.AreEqual(expected, Math.Round(actual, 4));
        }//end of TestAngleBetweenVector2s

        //4.d - Test 2.d - To Normalize a 2D vector.
        public static IEnumerable<Object[]> NormalizeVector2DData()
        {
            // Instructor Data - MUST NOT DELETE OR MODIFY
            yield return new Object[]
            {
                new Eng_Vector2D(3, 4),			// vector a
                new Eng_Vector2D(0.6, 0.8)		// expected normalized a
            };
            // Student Data - YOU NEED TO ADD YOUR DATA BELOW
            yield return new Object[]
            {
                new Eng_Vector2D(5, 2),			 // vector a
                new Eng_Vector2D(0.9285, 0.3714) // expected normalized a
            };
        }//end of NormalizeVector2DData

        [Test, TestCaseSource(nameof(NormalizeVector2DData))]
        public void TestNormalizeVector2(Eng_Vector2D v, Eng_Vector2D expected)
        {
            // Perform the test
            v.Normalize();
            // Assert
            Assert.AreEqual(expected.X, Math.Round(v.X,4));
            Assert.AreEqual(expected.Y, Math.Round(v.Y, 4));
        }//end of TestNormalizeVector2

        //4.e - Test 3.a - Adding two 2D vectors.
		//    - Test 3.b - Subtracting two 2D vectors.
        public static IEnumerable<Object[]> AddSubtractVector2DData()
        {
            // Instructor Data - MUST NOT DELETE OR MODIFY
            yield return new Object[]
            {
               new Eng_Vector2D(3, 4),		// vector a
               new Eng_Vector2D(6, 9),		// vector b
               new Eng_Vector2D(9, 13),	    // expected a + b	
               new Eng_Vector2D(-3, -5)	    // expected a - b
            };
            // Student Data - YOU NEED TO ADD YOUR DATA BELOW
            yield return new Object[]
            {
               new Eng_Vector2D(5, 8),		// vector a
               new Eng_Vector2D(6, 2),		// vector b
               new Eng_Vector2D(11, 10),	// expected a + b	
               new Eng_Vector2D(-1, 6)	    // expected a - b
            };
        }//end of AddSubtractVector2DData

        [Test, TestCaseSource(nameof(AddSubtractVector2DData))]
        public void TestAddSubtractVector2D(Eng_Vector2D a, Eng_Vector2D b, Eng_Vector2D expectedAdd, Eng_Vector2D expectedSub)
        {
            // Perform the test
            Eng_Vector2D actualAdd = a + b;
            Eng_Vector2D actualsubtract = a - b;
            // Assert
            Assert.AreEqual(expectedAdd, actualAdd);
            Assert.AreEqual(expectedSub, actualsubtract);
        }//end of TestAddSubtractVector2D

        //4.f - Test 3.c - Multiplying a 2D vector by a scalar.
        [Test,
            // 1st - 2nd = vector
            // 3rd = scale factor
            // 4th - 5th = expected scaled vector
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(3, 4, 2, 6, 8),
            // Student Data - MUST CHANGE
            TestCase(4, 7, 3, 12, 21)
        ]

        public void TestScaleVector2(double x, double y, double s, double expectedX, double expectedY)
        {
            // Create Objects for the test
            Eng_Vector2D testVector = new Eng_Vector2D(x,y);
            // Perform the test
            Eng_Vector2D actual = testVector * s;
            // Assert
            Assert.AreEqual(expectedX, Math.Round(actual.X,4));
            Assert.AreEqual(expectedY, Math.Round(actual.Y, 4));
        }//end of TestScaleVector2

        //4.g - Test 3.d - Equality of two 2D vectors.
		//    - Test 3.e - Inequality of two 2D vectors.
        [Test,
            // 1st - 2nd = vector a
            // 3rd - 4th = vector b
            // 5th - 6th = vector c
            // last = expected for both == and !=
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(3, 7, 3, 7, -3, 7, true),
            // Student Data - MUST CHANGE
            TestCase(6, 5, 6, 5, -6, 5, true),
            TestCase(8, 2, -8, 2, 8, 2, false)
        ]

        public void TestEqualityVector2D(double ax, double ay, double bx, double by, double cx, double cy, bool expected)
        {
            // Create Objects for the test
            Eng_Vector2D testEngineA = new Eng_Vector2D(ax, ay);
            Eng_Vector2D testEngineB = new Eng_Vector2D(bx, by);
            Eng_Vector2D testEngineC = new Eng_Vector2D(cx, cy);
            // Perform test
            bool testEngineAB = testEngineA == testEngineB;
            bool testEngineAC = testEngineA != testEngineC;
            // Assert
            Assert.AreEqual(expected, testEngineAB);
            Assert.AreEqual(expected, testEngineAC);
        }//end of TestEqualityVector2D
        #endregion

        #region Part 3 - 3D Vectors
        //4.a - Test 2.a - Magnitude of a 3D vector.
        [Test,
            // 1st - 3rd = vector
            // 4th = expected magnitude
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(3, 4, 5, 7.0711),
            // Student Data - MUST CHANGE
            TestCase(5, 7, 2, 8.8318)
        ]

        public void TestMagnitudeVector3(double x, double y, double z, double expected)
        {
            // Create Objects for the test
            Eng_Vector3D testEngine = new Eng_Vector3D(x, y, z);
            // Perform the test
            double actual = testEngine.Magnitude();
            // Assert
            Assert.AreEqual(expected, Math.Round(actual, 4));
        }//end of TestMagnitudeVector3

        //4.b - Test 2.b - Calculate the Dot Product of two 3D vectors.
        [Test,
            // 1st - 3rd = vector a
            // 4th - 6th = vector b
            // 7th = expected dot product
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(3, 4, 5, -2, -3, 4, 2),
             // Student Data - MUST CHANGE
             TestCase(4, 6, -4, 5, -6, 2, -24)
        ]

        public void TestDotProductVector3(double ax, double ay, double az, double bx, double by, double bz, double expected)
        {
            // Create Objects for the test
            Eng_Vector3D testEngineA = new Eng_Vector3D(ax, ay, az);
            Eng_Vector3D testEngineB = new Eng_Vector3D(bx, by, bz);
            // Perform the test
            double actual = testEngineA.DotProduct(testEngineB);
            // Assert
            Assert.AreEqual(expected, Math.Round(actual, 4));
        }//end of TestDotProductVector3

        //4.c - Test 2.c - Calculate the angle between two 3D vectors.
        [Test,
            // 1st - 3rd = vector a
            // 4th - 6th = vector b
            // 7th = expected angle between in degrees
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(3, 4, 5, -2, -3, 4, 86.9893),
            // Student Data - MUST CHANGE
            TestCase(2, -5, 3, -6, -8, 4, 52.9526)
        ]

        public void TestAngleBetweenVector3s(double ax, double ay, double az, double bx, double by, double bz, double expected)
        {
            // Create Objects for the test
            Eng_Vector3D testEngineA = new Eng_Vector3D(ax, ay, az);
            Eng_Vector3D testEngineB = new Eng_Vector3D(bx, by, bz);
            // Act - performing the action
            double actual = testEngineA.AngleBetweenVectors(testEngineB);
            // Assert - did we get back the correct answer
            Assert.AreEqual(expected, Math.Round(actual, 4));
        }//end of TestAngleBetweenVector3s

        //4.d - Test 2.d - Normalize a 3D vector.
        public static IEnumerable<Object[]> NormalizeVector3DData()
        {
            // Instructor Data - MUST NOT DELETE OR MODIFY
            yield return new Object[]
            {
                new Eng_Vector3D(3, 4, 5),					// vector
                new Eng_Vector3D(0.4243, 0.5657, 0.7071)	// normalized
            };
            // Student Data - YOU NEED TO ADD YOUR DATA BELOW
            yield return new Object[]
            {
                new Eng_Vector3D(8, 2, 6),					// vector
                new Eng_Vector3D(0.7845, 0.1961, 0.5883)	// normalized
            };
        }//end of NormalizeVector3DData
		
        [Test, TestCaseSource(nameof(NormalizeVector3DData))]
        public void TestNormalizeVector3(Eng_Vector3D v, Eng_Vector3D expected)
        {
            // Perform the test
            v.Normalize();
            // Assert
            Assert.AreEqual(expected.X, Math.Round(v.X, 4));
            Assert.AreEqual(expected.Y, Math.Round(v.Y, 4));
            Assert.AreEqual(expected.Z, Math.Round(v.Z, 4));
        }//end of TestNormalizeVector3

        //4.e - Test 3.a - Adding two 3D vectors.
		//    - Test 3.b - Subtracting two 3D vectors.
        public static IEnumerable<Object[]> AddSubtractVector3DData()
        {
            // Instructor Data - MUST NOT DELETE OR MODIFY
            yield return new Object[]
            {
                new Eng_Vector3D(3, 4, 6),		// vector a
                new Eng_Vector3D(6, 9, 4),		// vector b
                new Eng_Vector3D(9, 13, 10),	// expected a + b
                new Eng_Vector3D(-3, -5, 2)		// expected a - b
            };
            // Student Data - YOU NEED TO ADD YOUR DATA BELOW
            yield return new Object[]
            {
                new Eng_Vector3D(5, 4, 9),		// vector a
                new Eng_Vector3D(2, 8, 6),		// vector b
                new Eng_Vector3D(7, 12, 15),	// expected a + b
                new Eng_Vector3D(3, -4, 3)		// expected a - b
            };
        }//end of AddSubtractVector3DData

        [Test, TestCaseSource(nameof(AddSubtractVector3DData))]
        public void TestAddsubtractVector3(Eng_Vector3D a, Eng_Vector3D b, Eng_Vector3D expectedAdd, Eng_Vector3D expectedSub)
        {
            // Perform the test
            Eng_Vector3D actualAdd = a + b;
            Eng_Vector3D actualsubtract = a - b;
            // Assert
            Assert.AreEqual(expectedAdd, actualAdd);
            Assert.AreEqual(expectedSub, actualsubtract);
        }//end of TestAddsubtractVector3

        //4.f - Test 3.c - Multiplying a 3D vector by a scalar.
        [Test,
            // 1st - 3rd = vector a
            // 4th = scale factor
            // 5th - 7th = expected scaled vector
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(3, 4, 5, 2, 6, 8, 10),
            // Student Data - MUST CHANGE
            TestCase(7, 4, 3, 4, 28, 16, 12)
        ]

        public void TestScaleVector3(double x, double y, double z, double s, double expectedX, double expectedY, double expectedZ)
        {
            // Create Objects for the test
            Eng_Vector3D testVector = new Eng_Vector3D(x, y, z);
            // Perform the test
            Eng_Vector3D actual = testVector * s;
            // Assert
            Assert.AreEqual(expectedX, Math.Round(actual.X, 4));
            Assert.AreEqual(expectedY, Math.Round(actual.Y, 4));
            Assert.AreEqual(expectedZ, Math.Round(actual.Z, 4));
        }//end of TestScaleVector3

        //4.g - Test 3.d - Equality of two 3D vectors.
		//    - Test 3.e - Inequality of two 3D vectors.
        [Test,
            // 1st - 3rd = vector a
            // 4th - 6th = vector b
            // 7th - 9th = vector c
            // last = expected for both == and !=
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(3, -4, 5, 3, -4, 5, 3, 4, 5, true),
             // Student Data - MUST CHANGE
             TestCase(7, -6, 2, 7, -6, 2, -7, -6, 2, true),
            TestCase(7, -6, 2, -7, -6, 2, 7, -6, 2, false)
        ]

        public void TestEqualityVector3(double ax, double ay, double az, double bx, double by, double bz, double cx, double cy, double cz, bool expected)
        {
            // Create Objects for the test
            Eng_Vector3D testEngineA = new Eng_Vector3D(ax, ay, az);
            Eng_Vector3D testEngineB = new Eng_Vector3D(bx, by, bz);
            Eng_Vector3D testEngineC = new Eng_Vector3D(cx, cy, cz);
            // Perform test
            bool testEngineAB = testEngineA == testEngineB;
            bool testEngineAC = testEngineA != testEngineC;
            // Assert
            Assert.AreEqual(expected, testEngineAB);
            Assert.AreEqual(expected, testEngineAC);
        }//end of TestEqualityVector3

        //4.h - Test 3.f - Calculate the Cross Product of two 3D vectors.
        public static IEnumerable<Object[]> CrossProductData()
        {
            // Instructor Data - MUST NOT DELETE OR MODIFY
            yield return new Object[]
            {
                new Eng_Vector3D(3, 4, 5),		// vector a
                new Eng_Vector3D(-2, -3, 4),	// vector b
                new Eng_Vector3D(31, -22, -1)	// expected a x b
            };
            // Student Data - YOU NEED TO ADD YOUR DATA BELOW

        }//end of CrossProductData

        [Test, TestCaseSource(nameof(CrossProductData))]
        public void TestCrossProduct(Eng_Vector3D a, Eng_Vector3D b, Eng_Vector3D expected)
        {
            // Perform the test
            
            // Assert
            
        }//end of TestCrossProduct
        #endregion
    }//eoc
}//eon

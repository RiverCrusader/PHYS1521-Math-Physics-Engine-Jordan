using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using NUnit.Framework;
using Engine.Mathematics;
#endregion

namespace Engine.Tests.Lab4
{
    public class Lab4Tester
    {
        #region 2D Bezier Curves
        //1.a - Quadratic 2D
        public static IEnumerable<Object[]> QuadraticBezier2D_Data()
        {
            // Instructor Data - MUST NOT DELETE OR MODIFY
            yield return new Object[]
            {
                new Eng_Vector2D(50, 75),   // p0 - start point
                new Eng_Vector2D(250, 400), // p1 - control point
                new Eng_Vector2D(350, 250), // p2 - end point
                // expected data
                new Eng_Vector2D(50, 75),
                new Eng_Vector2D(89, 135.25),
                new Eng_Vector2D(126, 186),
                new Eng_Vector2D(161, 227.25),
                new Eng_Vector2D(194, 259),
                new Eng_Vector2D(225, 281.25),
                new Eng_Vector2D(254, 294),
                new Eng_Vector2D(281, 297.25),
                new Eng_Vector2D(306, 291),
                new Eng_Vector2D(329, 275.25),
                new Eng_Vector2D(350, 250)
            };
            // Student Data - YOU NEED TO ADD YOUR DATA BELOW

        }//end of QuadraticBezier2D_Data

        [Test, TestCaseSource(nameof(QuadraticBezier2D_Data))]
        public static void TestQuadraticBezier2D(
            Eng_Vector2D p0, Eng_Vector2D p1, Eng_Vector2D p2,
            Eng_Vector2D pp0, Eng_Vector2D pp1, Eng_Vector2D pp2, Eng_Vector2D pp3,
            Eng_Vector2D pp4, Eng_Vector2D pp5, Eng_Vector2D pp6, Eng_Vector2D pp7,
            Eng_Vector2D pp8, Eng_Vector2D pp9, Eng_Vector2D pp10)
        {
            // Perform the test
            
            // Assert
            
        }//end of TestQuadraticBezier2D

        //1.b - Cubic 2D
        public static IEnumerable<Object[]> CubicBezier2D_Data()
        {
            // Instructor Data - MUST NOT DELETE OR MODIFY
            yield return new Object[]
            {
                new Eng_Vector2D(50, 75),   // p0 - start point
                new Eng_Vector2D(250, 400), // p1 - 1st control point
                new Eng_Vector2D(350, 250), // p2 - 2nd control point
                new Eng_Vector2D(150, 500), // p3 - end point
                // expected data
                new Eng_Vector2D(50, 75),
                new Eng_Vector2D(106.8, 159.125),
                new Eng_Vector2D(156.4, 220),
                new Eng_Vector2D(197.6, 262.875),
                new Eng_Vector2D(229.2, 293),
                new Eng_Vector2D(250, 315.625),
                new Eng_Vector2D(258.8, 336),
                new Eng_Vector2D(254.4, 359.375),
                new Eng_Vector2D(235.6, 391),
                new Eng_Vector2D(201.2, 436.125),
                new Eng_Vector2D(150, 500)
            };
            // Student Data - YOU NEED TO ADD YOUR DATA BELOW

        }//end of CubicBezier2D_Data

        [Test, TestCaseSource(nameof(CubicBezier2D_Data))]
        public static void TestCubicBezier2D(
            Eng_Vector2D p0, Eng_Vector2D p1, Eng_Vector2D p2, Eng_Vector2D p3,
            Eng_Vector2D pp0, Eng_Vector2D pp1, Eng_Vector2D pp2, Eng_Vector2D pp3,
            Eng_Vector2D pp4, Eng_Vector2D pp5, Eng_Vector2D pp6, Eng_Vector2D pp7,
            Eng_Vector2D pp8, Eng_Vector2D pp9, Eng_Vector2D pp10)
        {
            // Perform the test
            
            // Assert
            
        }//end of TestCubicBezier2D

        //1.c - Quartic 2D
        public static IEnumerable<Object[]> QuarticBezier2D_Data()
        {
            // Instructor Data - MUST NOT DELETE OR MODIFY
            yield return new Object[]
            {
                new Eng_Vector2D(50, 75),   // p0 - start point
                new Eng_Vector2D(250, 400), // p1 - 1st control point
                new Eng_Vector2D(350, 250), // p2 - 2nd control point
                new Eng_Vector2D(150, 500), // p3 - 3rd control point
                new Eng_Vector2D(800, 200), // p4 - end point
                // expected data
                new Eng_Vector2D(50, 75),
                new Eng_Vector2D(123.335, 179.8175),
                new Eng_Vector2D(181.76, 246.08),
                new Eng_Vector2D(225.335, 288.2175),
                new Eng_Vector2D(257.36, 316.28),
                new Eng_Vector2D(284.375, 335.9375),
                new Eng_Vector2D(316.16, 348.48),
                new Eng_Vector2D(365.735, 350.8175),
                new Eng_Vector2D(449.36, 335.48),
                new Eng_Vector2D(586.535, 290.6175),
                new Eng_Vector2D(800, 200)
            };
            // Student Data - YOU NEED TO ADD YOUR DATA BELOW

        }//end of QuarticBezier2D_Data

        [Test, TestCaseSource(nameof(QuarticBezier2D_Data))]
        public static void TestQuarticicBezier2D(
            Eng_Vector2D p0, Eng_Vector2D p1, Eng_Vector2D p2, Eng_Vector2D p3, Eng_Vector2D p4,
            Eng_Vector2D pp0, Eng_Vector2D pp1, Eng_Vector2D pp2, Eng_Vector2D pp3,
            Eng_Vector2D pp4, Eng_Vector2D pp5, Eng_Vector2D pp6, Eng_Vector2D pp7,
            Eng_Vector2D pp8, Eng_Vector2D pp9, Eng_Vector2D pp10)
        {
            // Perform the test
            
            // Assert
            
        }//end of TestQuarticicBezier2D
        #endregion

        #region 3D Bezier Curves
        //1.d - Quadratic 3D
        public static IEnumerable<Object[]> QuadraticBezier3D_Data()
        {
            // Instructor Data - MUST NOT DELETE OR MODIFY
            yield return new Object[]
            {
                new Eng_Vector3D(25, 100, 60),      // p0 - start point
                new Eng_Vector3D(300, 200, 120),    // p1 - control point
                new Eng_Vector3D(400, 50, 200),     // p2 - end point
                // expected data
                new Eng_Vector3D(25, 100, 60),
                new Eng_Vector3D(78.25, 117.5, 72.2),
                new Eng_Vector3D(128, 130, 84.8),
                new Eng_Vector3D(174.25, 137.5, 97.8),
                new Eng_Vector3D(217, 140, 111.2),
                new Eng_Vector3D(256.25, 137.5, 125),
                new Eng_Vector3D(292, 130, 139.2),
                new Eng_Vector3D(324.25, 117.5, 153.8),
                new Eng_Vector3D(353, 100, 168.8),
                new Eng_Vector3D(378.25, 77.5, 184.2),
                new Eng_Vector3D(400, 50, 200)
            };
            // Student Data - YOU NEED TO ADD YOUR DATA BELOW

        }//end of QuadraticBezier3D_Data

        [Test, TestCaseSource(nameof(QuadraticBezier3D_Data))]
        public static void TestQuadraticBezier3D(
            Eng_Vector3D p0, Eng_Vector3D p1, Eng_Vector3D p2,
            Eng_Vector3D pp0, Eng_Vector3D pp1, Eng_Vector3D pp2, Eng_Vector3D pp3,
            Eng_Vector3D pp4, Eng_Vector3D pp5, Eng_Vector3D pp6, Eng_Vector3D pp7,
            Eng_Vector3D pp8, Eng_Vector3D pp9, Eng_Vector3D pp10)
        {
            // Perform the test
            
            // Assert
            
        }//end of TestQuadraticBezier3D

        //1.e - Cubic 3D
        public static IEnumerable<Object[]> CubicBezier3D_Data()
        {
            // Instructor Data - MUST NOT DELETE OR MODIFY
            yield return new Object[]
            {
                new Eng_Vector3D(25, 100, 60),      // p0 - start point
                new Eng_Vector3D(300, 200, 120),    // p1 - 1st control point
                new Eng_Vector3D(400, 50, 200),     // p2 - 2nd control point
                new Eng_Vector3D(500, 300, 500),    // p3 - end point
                // expected data
                new Eng_Vector3D(25, 100, 60),
                new Eng_Vector3D(102.425, 123.15, 78.8),
                new Eng_Vector3D(170.4, 135.2, 100),
                new Eng_Vector3D(229.975, 140.05, 124.8),
                new Eng_Vector3D(282.2, 141.6, 154.4),
                new Eng_Vector3D(328.125, 143.75, 190),
                new Eng_Vector3D(368.8, 150.4, 232.8),
                new Eng_Vector3D(405.275, 165.45, 284),
                new Eng_Vector3D(438.6, 192.8, 344.8),
                new Eng_Vector3D(469.825, 236.35, 416.4),
                new Eng_Vector3D(500, 300, 500)
            };
            // Student Data - YOU NEED TO ADD YOUR DATA BELOW

        }//end of CubicBezier3D_Data

        [Test, TestCaseSource(nameof(CubicBezier3D_Data))]
        public static void TestCubicBezier3D(
            Eng_Vector3D p0, Eng_Vector3D p1, Eng_Vector3D p2, Eng_Vector3D p3,
            Eng_Vector3D pp0, Eng_Vector3D pp1, Eng_Vector3D pp2, Eng_Vector3D pp3,
            Eng_Vector3D pp4, Eng_Vector3D pp5, Eng_Vector3D pp6, Eng_Vector3D pp7,
            Eng_Vector3D pp8, Eng_Vector3D pp9, Eng_Vector3D pp10)
        {
            // Perform the test
            
            // Assert
            
        }//end of TestCubicBezier3D

        //1.f - Quartic 3D
        public static IEnumerable<Object[]> QuarticBezier3D_Data()
        {
            // Instructor Data - MUST NOT DELETE OR MODIFY
            yield return new Object[]
            {
                new Eng_Vector3D(25, 100, 60),      // p0 - start point
                new Eng_Vector3D(300, 200, 120),    // p1 - 1st control point
                new Eng_Vector3D(400, 50, 200),     // p2 - 2nd control point
                new Eng_Vector3D(500, 300, 500),    // p3 - 3rd control point
                new Eng_Vector3D(100, 500, 50),     // p4 - end point
                // expected data
                new Eng_Vector3D(25, 100, 60),
                new Eng_Vector3D(125.1325, 127.49, 85.883),
                new Eng_Vector3D(207.52, 139.04, 117.328),
                new Eng_Vector3D(273.9325, 146.29, 154.923),
                new Eng_Vector3D(324.52, 158.24, 196.448),
                new Eng_Vector3D(357.8125, 181.25, 236.875),
                new Eng_Vector3D(370.72, 219.04, 268.368),
                new Eng_Vector3D(358.5325, 272.69, 280.283),
                new Eng_Vector3D(314.92, 340.64, 259.168),
                new Eng_Vector3D(231.9325, 418.69, 188.763),
                new Eng_Vector3D(100, 500, 50)
            };
            // Student Data - YOU NEED TO ADD YOUR DATA BELOW

        }//end of QuarticBezier3D_Data

        [Test, TestCaseSource(nameof(QuarticBezier3D_Data))]
        public static void TestQuarticBezier3D(
            Eng_Vector3D p0, Eng_Vector3D p1, Eng_Vector3D p2, Eng_Vector3D p3, Eng_Vector3D p4,
            Eng_Vector3D pp0, Eng_Vector3D pp1, Eng_Vector3D pp2, Eng_Vector3D pp3,
            Eng_Vector3D pp4, Eng_Vector3D pp5, Eng_Vector3D pp6, Eng_Vector3D pp7,
            Eng_Vector3D pp8, Eng_Vector3D pp9, Eng_Vector3D pp10)
        {
            // Perform the test
            
            // Assert
            
        }//end of TestQuarticBezier3D
        #endregion

        #region Catmul-Rom Splines
        //1.a - 2D
        public static IEnumerable<Object[]> CatmullRom2D_Data()
        {
            // Instructor Data - MUST NOT DELETE OR MODIFY
            yield return new Object[]
            {
                new Eng_Vector2D(50, 75),   // p0 - 1st control point
                new Eng_Vector2D(250, 400), // p1 - start point
                new Eng_Vector2D(350, 250), // p2 - end point
                new Eng_Vector2D(150, 500), // p3 - 2nd control point
                // expected data
                new Eng_Vector2D(250, 400),
                new Eng_Vector2D(265.4, 402.4375),
                new Eng_Vector2D(281.2, 394),
                new Eng_Vector2D(296.8, 377.3125),
                new Eng_Vector2D(311.6, 355),
                new Eng_Vector2D(325, 329.6875),
                new Eng_Vector2D(336.4, 304),
                new Eng_Vector2D(345.2, 280.5625),
                new Eng_Vector2D(350.8, 262),
                new Eng_Vector2D(352.6, 250.9375),
                new Eng_Vector2D(350, 250)
            };
            // Student Data - YOU NEED TO ADD YOUR DATA BELOW

        }//end of CatmullRom2D_Data

        [Test, TestCaseSource(nameof(CatmullRom2D_Data))]
        public static void TestCatmullRom2D(
            Eng_Vector2D p0, Eng_Vector2D p1, Eng_Vector2D p2, Eng_Vector2D p3,
            Eng_Vector2D pp0, Eng_Vector2D pp1, Eng_Vector2D pp2, Eng_Vector2D pp3,
            Eng_Vector2D pp4, Eng_Vector2D pp5, Eng_Vector2D pp6, Eng_Vector2D pp7,
            Eng_Vector2D pp8, Eng_Vector2D pp9, Eng_Vector2D pp10)
        {
            // Perform the test
            
            // Assert
            
        }//end of TestCatmullRom2D

        //1.b - 3D
        public static IEnumerable<Object[]> CatmullRom3D_Data()
        {
            // Instructor Data - MUST NOT DELETE OR MODIFY
            yield return new Object[]
            {
                new Eng_Vector3D(25, 100, 60),      // p0 - 1st control point
                new Eng_Vector3D(300, 200, 120),    // p1 - start point
                new Eng_Vector3D(400, 50, 200),     // p2 - end point
                new Eng_Vector3D(500, 300, 500),    // p3 - 2nd control point
                // expected data
                new Eng_Vector3D(300, 200, 120),
                new Eng_Vector3D(317.0875, 193.325, 126.2),
                new Eng_Vector3D(331.2, 179.6, 131.2),
                new Eng_Vector3D(342.8625, 160.775, 135.6),
                new Eng_Vector3D(352.6, 138.8, 140),
                new Eng_Vector3D(360.9375, 115.625, 145),
                new Eng_Vector3D(368.4, 93.2, 151.2),
                new Eng_Vector3D(375.5125, 73.475, 159.2),
                new Eng_Vector3D(382.8, 58.4, 169.6),
                new Eng_Vector3D(390.7875, 49.925, 183),
                new Eng_Vector3D(400, 50, 200)
            };
            // Student Data - YOU NEED TO ADD YOUR DATA BELOW

        }//end of CatmullRom3D_Data

        [Test, TestCaseSource(nameof(CatmullRom3D_Data))]
        public static void TestCatmullRom3D(
            Eng_Vector3D p0, Eng_Vector3D p1, Eng_Vector3D p2, Eng_Vector3D p3,
            Eng_Vector3D pp0, Eng_Vector3D pp1, Eng_Vector3D pp2, Eng_Vector3D pp3,
            Eng_Vector3D pp4, Eng_Vector3D pp5, Eng_Vector3D pp6, Eng_Vector3D pp7,
            Eng_Vector3D pp8, Eng_Vector3D pp9, Eng_Vector3D pp10)
        {

            // Performing the test
            
            // Assert
           
        }//end of TestCatmullRom3D
        #endregion
    }//eoc
}//eon

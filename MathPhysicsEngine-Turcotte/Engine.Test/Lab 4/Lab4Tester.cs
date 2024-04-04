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
            yield return new Object[]
           {
                new Eng_Vector2D(38, 112),   // p0 - start point
                new Eng_Vector2D(482, 245), // p1 - control point
                new Eng_Vector2D(253, 259), // p2 - end point
                // expected data
                new Eng_Vector2D(38, 112),
                new Eng_Vector2D(120.07, 137.41),
                new Eng_Vector2D(188.68,160.44 ),
                new Eng_Vector2D(243.83,181.09),
                new Eng_Vector2D(285.52,199.36),
                new Eng_Vector2D(313.75,215.25),
                new Eng_Vector2D(328.52, 228.76),
                new Eng_Vector2D(329.83, 239.89),
                new Eng_Vector2D(317.68, 248.64),
                new Eng_Vector2D(292.07, 255.01),
                new Eng_Vector2D(253, 259)
           };
        }//end of QuadraticBezier2D_Data

        [Test, TestCaseSource(nameof(QuadraticBezier2D_Data))]
        public static void TestQuadraticBezier2D(
            Eng_Vector2D p0, Eng_Vector2D p1, Eng_Vector2D p2,
            Eng_Vector2D pp0, Eng_Vector2D pp1, Eng_Vector2D pp2, Eng_Vector2D pp3,
            Eng_Vector2D pp4, Eng_Vector2D pp5, Eng_Vector2D pp6, Eng_Vector2D pp7,
            Eng_Vector2D pp8, Eng_Vector2D pp9, Eng_Vector2D pp10)
        {
            // Perform the test
            double time = 0;
            Eng_Vector2D tempActual;

            List<Eng_Vector2D> actuals = new List<Eng_Vector2D>();
            List<Eng_Vector2D> expecteds = new List<Eng_Vector2D>() { pp0, pp1, pp2, pp3, pp4, pp5, pp6, pp7, pp8, pp9, pp10 };
            for (int i = 0; i < 11; i++)
            {
                tempActual = Functions.QuadraticBezier(time, p0, p1, p2);
                time += 0.1;

                actuals.Add(tempActual);
            }
            // Assert
            for (int i = 0; i < expecteds.Count; i++)
            {
                Assert.AreEqual(expecteds[i].X, Math.Round(actuals[i].X,4));
                Assert.AreEqual(expecteds[i].Y, Math.Round(actuals[i].Y,4));
            }
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
            yield return new Object[]
            {
                new Eng_Vector2D(85, 7),   // p0 - start point
                new Eng_Vector2D(462, 256), // p1 - 1st control point
                new Eng_Vector2D(149, 367), // p2 - 2nd control point
                new Eng_Vector2D(168, 235), // p3 - end point
                // expected data
                new Eng_Vector2D(85, 7),
                new Eng_Vector2D(178.422, 77.455),
                new Eng_Vector2D(236.576, 139.00),
                new Eng_Vector2D(265.594, 191.005),
                new Eng_Vector2D(271.608, 232.84),
                new Eng_Vector2D(260.75, 263.875),
                new Eng_Vector2D(239.152, 283.48),
                new Eng_Vector2D(212.946, 291.025),
                new Eng_Vector2D(188.264, 285.88),
                new Eng_Vector2D(171.238, 267.415),
                new Eng_Vector2D(168, 235)
            };
        }//end of CubicBezier2D_Data

        [Test, TestCaseSource(nameof(CubicBezier2D_Data))]
        public static void TestCubicBezier2D(
            Eng_Vector2D p0, Eng_Vector2D p1, Eng_Vector2D p2, Eng_Vector2D p3,
            Eng_Vector2D pp0, Eng_Vector2D pp1, Eng_Vector2D pp2, Eng_Vector2D pp3,
            Eng_Vector2D pp4, Eng_Vector2D pp5, Eng_Vector2D pp6, Eng_Vector2D pp7,
            Eng_Vector2D pp8, Eng_Vector2D pp9, Eng_Vector2D pp10)
        {
            // Perform the test
            double time = 0;
            Eng_Vector2D tempActual;

            List<Eng_Vector2D> actuals = new List<Eng_Vector2D>();
            List<Eng_Vector2D> expecteds = new List<Eng_Vector2D>() { pp0, pp1, pp2, pp3, pp4, pp5, pp6, pp7, pp8, pp9, pp10 };
            for (int i = 0; i < 11; i++)
            {
                tempActual = Functions.CubicBezier(time, p0, p1, p2, p3);
                time += 0.1;

                actuals.Add(tempActual);
            }
            // Assert
            for (int i = 0; i < expecteds.Count; i++)
            {
                Assert.AreEqual(expecteds[i].X, Math.Round(actuals[i].X, 4));
                Assert.AreEqual(expecteds[i].Y, Math.Round(actuals[i].Y, 4));
            }

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
            yield return new Object[]
            {
                new Eng_Vector2D(123, 2),   // p0 - start point
                new Eng_Vector2D(452, 84), // p1 - 1st control point
                new Eng_Vector2D(265, 354), // p2 - 2nd control point
                new Eng_Vector2D(213, 4), // p3 - 3rd control point
                new Eng_Vector2D(534, 754), // p4 - end point
                // expected data
                new Eng_Vector2D(123, 2),
                new Eng_Vector2D(226.2027, 43.1008),
                new Eng_Vector2D(282.5312, 90.9088),
                new Eng_Vector2D(306.1227, 135.1328),
                new Eng_Vector2D(310.1232, 171.5488),
                new Eng_Vector2D(306.6875, 202),
                new Eng_Vector2D(306.9792, 234.3968),
                new Eng_Vector2D(321.1707, 282.7168),
                new Eng_Vector2D(358.4432, 367.0048),
                new Eng_Vector2D(426.9867, 513.3728),
                new Eng_Vector2D(534, 754)
            };
        }//end of QuarticBezier2D_Data

        [Test, TestCaseSource(nameof(QuarticBezier2D_Data))]
        public static void TestQuarticicBezier2D(
            Eng_Vector2D p0, Eng_Vector2D p1, Eng_Vector2D p2, Eng_Vector2D p3, Eng_Vector2D p4,
            Eng_Vector2D pp0, Eng_Vector2D pp1, Eng_Vector2D pp2, Eng_Vector2D pp3,
            Eng_Vector2D pp4, Eng_Vector2D pp5, Eng_Vector2D pp6, Eng_Vector2D pp7,
            Eng_Vector2D pp8, Eng_Vector2D pp9, Eng_Vector2D pp10)
        {
            // Perform the test
            double time = 0;
            Eng_Vector2D tempActual;

            List<Eng_Vector2D> actuals = new List<Eng_Vector2D>();
            List<Eng_Vector2D> expecteds = new List<Eng_Vector2D>() { pp0, pp1, pp2, pp3, pp4, pp5, pp6, pp7, pp8, pp9, pp10 };
            for (int i = 0; i < 11; i++)
            {
                tempActual = Functions.QuarticBezier(time, p0, p1, p2, p3, p4);
                time += 0.1;

                actuals.Add(tempActual);
            }
            // Assert
            for (int i = 0; i < expecteds.Count; i++)
            {
                Assert.AreEqual(expecteds[i].X, Math.Round(actuals[i].X, 4));
                Assert.AreEqual(expecteds[i].Y, Math.Round(actuals[i].Y, 4));
            }

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
            yield return new Object[]
            {
                new Eng_Vector3D(3, 53, 256),      // p0 - start point
                new Eng_Vector3D(700, 356, 2),    // p1 - control point
                new Eng_Vector3D(8, 23, 600),     // p2 - end point
                // expected data
                new Eng_Vector3D(3, 53, 256),
                new Eng_Vector3D(128.51, 107.24, 213.72),
                new Eng_Vector3D(226.24, 148.76, 188.48),
                new Eng_Vector3D(296.19, 177.56, 180.28),
                new Eng_Vector3D(338.36, 193.64, 189.12),
                new Eng_Vector3D(352.75, 197, 215),
                new Eng_Vector3D(339.36, 187.64, 257.92),
                new Eng_Vector3D(298.19, 165.56, 317.88),
                new Eng_Vector3D(229.24, 130.76, 394.88),
                new Eng_Vector3D(132.51, 83.24, 488.92),
                new Eng_Vector3D(8, 23, 600)
            };
        }//end of QuadraticBezier3D_Data

        [Test, TestCaseSource(nameof(QuadraticBezier3D_Data))]
        public static void TestQuadraticBezier3D(
            Eng_Vector3D p0, Eng_Vector3D p1, Eng_Vector3D p2,
            Eng_Vector3D pp0, Eng_Vector3D pp1, Eng_Vector3D pp2, Eng_Vector3D pp3,
            Eng_Vector3D pp4, Eng_Vector3D pp5, Eng_Vector3D pp6, Eng_Vector3D pp7,
            Eng_Vector3D pp8, Eng_Vector3D pp9, Eng_Vector3D pp10)
        {
            // Perform the test
            double time = 0;
            Eng_Vector3D tempActual;

            List<Eng_Vector3D> actuals = new List<Eng_Vector3D>();
            List<Eng_Vector3D> expecteds = new List<Eng_Vector3D>() { pp0, pp1, pp2, pp3, pp4, pp5, pp6, pp7, pp8, pp9, pp10 };
            for (int i = 0; i < 11; i++)
            {
                tempActual = Functions.QuadraticBezier(time, p0, p1, p2);
                time += 0.1;

                actuals.Add(tempActual);
            }
            // Assert
            for (int i = 0; i < expecteds.Count; i++)
            {
                Assert.AreEqual(expecteds[i].X, Math.Round(actuals[i].X, 4));
                Assert.AreEqual(expecteds[i].Y, Math.Round(actuals[i].Y, 4));
                Assert.AreEqual(expecteds[i].Z, Math.Round(actuals[i].Z, 4));
            }

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
            yield return new Object[]
            {
                new Eng_Vector3D(23, 8, 6),      // p0 - start point
                new Eng_Vector3D(15, 26, 4),    // p1 - 1st control point
                new Eng_Vector3D(954, 561, 845),     // p2 - 2nd control point
                new Eng_Vector3D(3, 9, 7),    // p3 - end point
                // expected data
                new Eng_Vector3D(23, 8, 6),
                new Eng_Vector3D(46.173, 27.306, 28.168),
                new Eng_Vector3D(109.144, 68.008, 85.784),
                new Eng_Vector3D(194.891, 120.482, 163.716),
                new Eng_Vector3D(286.392, 175.104, 246.832),
                new Eng_Vector3D(366.625, 222.25, 320),
                new Eng_Vector3D(418.568, 252.296, 368.088),
                new Eng_Vector3D(425.199, 255.618, 375.964),
                new Eng_Vector3D(369.496, 222.592, 328.496),
                new Eng_Vector3D(234.437, 143.594, 210.552),
                new Eng_Vector3D(3, 9, 7)
            };
        }//end of CubicBezier3D_Data

        [Test, TestCaseSource(nameof(CubicBezier3D_Data))]
        public static void TestCubicBezier3D(
            Eng_Vector3D p0, Eng_Vector3D p1, Eng_Vector3D p2, Eng_Vector3D p3,
            Eng_Vector3D pp0, Eng_Vector3D pp1, Eng_Vector3D pp2, Eng_Vector3D pp3,
            Eng_Vector3D pp4, Eng_Vector3D pp5, Eng_Vector3D pp6, Eng_Vector3D pp7,
            Eng_Vector3D pp8, Eng_Vector3D pp9, Eng_Vector3D pp10)
        {
            // Perform the test
            double time = 0;
            Eng_Vector3D tempActual;

            List<Eng_Vector3D> actuals = new List<Eng_Vector3D>();
            List<Eng_Vector3D> expecteds = new List<Eng_Vector3D>() { pp0, pp1, pp2, pp3, pp4, pp5, pp6, pp7, pp8, pp9, pp10 };
            for (int i = 0; i < 11; i++)
            {
                tempActual = Functions.CubicBezier(time, p0, p1, p2,p3);
                time += 0.1;

                actuals.Add(tempActual);
            }
            // Assert
            for (int i = 0; i < expecteds.Count; i++)
            {
                Assert.AreEqual(expecteds[i].X, Math.Round(actuals[i].X, 4));
                Assert.AreEqual(expecteds[i].Y, Math.Round(actuals[i].Y, 4));
                Assert.AreEqual(expecteds[i].Z, Math.Round(actuals[i].Z, 4));
            }

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
            yield return new Object[]
            {
                new Eng_Vector3D(742, 25, 1),      // p0 - start point
                new Eng_Vector3D(231, 2, 564),    // p1 - 1st control point
                new Eng_Vector3D(452, 504, 281),     // p2 - 2nd control point
                new Eng_Vector3D(651, 425, 742),    // p3 - 3rd control point
                new Eng_Vector3D(824, 456, 2),     // p4 - end point
                // expected data
                new Eng_Vector3D(742, 25, 1),
                new Eng_Vector3D(578.579, 43.0557, 181.4465),
                new Eng_Vector3D(485.952, 100.0832, 293.584),
                new Eng_Vector3D(448.723, 176.0077, 362.8465),
                new Eng_Vector3D(453.296, 255.0672, 406.184),
                new Eng_Vector3D(487.875, 325.8125, 432.0625),
                new Eng_Vector3D(542.464, 381.1072, 440.464),
                new Eng_Vector3D(608.867, 418.1277, 422.8865),
                new Eng_Vector3D(680.688, 438.3632, 362.344),
                new Eng_Vector3D(753.331, 447.6157, 233.3665),
                new Eng_Vector3D(824, 456, 2)
            };
        }//end of QuarticBezier3D_Data

        [Test, TestCaseSource(nameof(QuarticBezier3D_Data))]
        public static void TestQuarticBezier3D(
            Eng_Vector3D p0, Eng_Vector3D p1, Eng_Vector3D p2, Eng_Vector3D p3, Eng_Vector3D p4,
            Eng_Vector3D pp0, Eng_Vector3D pp1, Eng_Vector3D pp2, Eng_Vector3D pp3,
            Eng_Vector3D pp4, Eng_Vector3D pp5, Eng_Vector3D pp6, Eng_Vector3D pp7,
            Eng_Vector3D pp8, Eng_Vector3D pp9, Eng_Vector3D pp10)
        {
            // Perform the test
            double time = 0;
            Eng_Vector3D tempActual;

            List<Eng_Vector3D> actuals = new List<Eng_Vector3D>();
            List<Eng_Vector3D> expecteds = new List<Eng_Vector3D>() { pp0, pp1, pp2, pp3, pp4, pp5, pp6, pp7, pp8, pp9, pp10 };
            for (int i = 0; i < 11; i++)
            {
                tempActual = Functions.QuarticBezier(time, p0, p1, p2, p3, p4);
                time += 0.1;

                actuals.Add(tempActual);
            }
            // Assert
            for (int i = 0; i < expecteds.Count; i++)
            {
                Assert.AreEqual(expecteds[i].X, Math.Round(actuals[i].X, 4));
                Assert.AreEqual(expecteds[i].Y, Math.Round(actuals[i].Y, 4));
                Assert.AreEqual(expecteds[i].Z, Math.Round(actuals[i].Z, 4));
            }
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
            yield return new Object[]
            {
                new Eng_Vector2D(85, 2),   // p0 - 1st control point
                new Eng_Vector2D(184, 256), // p1 - start point
                new Eng_Vector2D(257, 321), // p2 - end point
                new Eng_Vector2D(234, 942), // p3 - 2nd control point
                // expected data
                new Eng_Vector2D(184, 256),
                new Eng_Vector2D(192.785, 267.6525),
                new Eng_Vector2D(201.8, 272.2),
                new Eng_Vector2D(210.835, 271.8775),
                new Eng_Vector2D(219.68, 268.92),
                new Eng_Vector2D(228.125, 265.5625),
                new Eng_Vector2D(235.96, 264.04),
                new Eng_Vector2D(242.975, 266.5875),
                new Eng_Vector2D(248.96, 275.44),
                new Eng_Vector2D(253.705, 292.8325),
                new Eng_Vector2D(257, 321)
            };
        }//end of CatmullRom2D_Data

        [Test, TestCaseSource(nameof(CatmullRom2D_Data))]
        public static void TestCatmullRom2D(
            Eng_Vector2D p0, Eng_Vector2D p1, Eng_Vector2D p2, Eng_Vector2D p3,
            Eng_Vector2D pp0, Eng_Vector2D pp1, Eng_Vector2D pp2, Eng_Vector2D pp3,
            Eng_Vector2D pp4, Eng_Vector2D pp5, Eng_Vector2D pp6, Eng_Vector2D pp7,
            Eng_Vector2D pp8, Eng_Vector2D pp9, Eng_Vector2D pp10)
        {
            // Perform the test
            double time = 0;
            Eng_Vector2D tempActual;

            List<Eng_Vector2D> actuals = new List<Eng_Vector2D>();
            List<Eng_Vector2D> expecteds = new List<Eng_Vector2D>() { pp0, pp1, pp2, pp3, pp4, pp5, pp6, pp7, pp8, pp9, pp10 };
            for (int i = 0; i < 11; i++)
            {
                tempActual = Functions.CatmullRomSpline(time, p0, p1, p2, p3);
                time += 0.1;

                actuals.Add(tempActual);
            }
            // Assert
            for (int i = 0; i < expecteds.Count; i++)
            {
                Assert.AreEqual(expecteds[i].X, Math.Round(actuals[i].X, 4));
                Assert.AreEqual(expecteds[i].Y, Math.Round(actuals[i].Y, 4));
            }
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
            yield return new Object[]
            {
                new Eng_Vector3D(452, 356, 74),      // p0 - 1st control point
                new Eng_Vector3D(965, 21, 284),    // p1 - start point
                new Eng_Vector3D(245, 341, 1),     // p2 - end point
                new Eng_Vector3D(128, 245, 564),    // p3 - 2nd control point
                // expected data
                new Eng_Vector3D(965, 21, 284),
                new Eng_Vector3D(940.223, 28.3445, 271.8595),
                new Eng_Vector3D(890.264, 49.736, 245.416),
                new Eng_Vector3D(820.631, 81.9615, 208.6865),
                new Eng_Vector3D(736.832, 121.808, 165.688),
                new Eng_Vector3D(644.375, 166.0625, 120.4375),
                new Eng_Vector3D(548.768, 211.512, 76.952),
                new Eng_Vector3D(455.519, 254.9435, 39.2485),
                new Eng_Vector3D(370.136, 293.144, 11.344),
                new Eng_Vector3D(298.127, 322.9005, -2.7445),
                new Eng_Vector3D(245, 341, 1)
            };
        }//end of CatmullRom3D_Data

        [Test, TestCaseSource(nameof(CatmullRom3D_Data))]
        public static void TestCatmullRom3D(
            Eng_Vector3D p0, Eng_Vector3D p1, Eng_Vector3D p2, Eng_Vector3D p3,
            Eng_Vector3D pp0, Eng_Vector3D pp1, Eng_Vector3D pp2, Eng_Vector3D pp3,
            Eng_Vector3D pp4, Eng_Vector3D pp5, Eng_Vector3D pp6, Eng_Vector3D pp7,
            Eng_Vector3D pp8, Eng_Vector3D pp9, Eng_Vector3D pp10)
        {
            // Perform the test
            double time = 0;
            Eng_Vector3D tempActual;

            List<Eng_Vector3D> actuals = new List<Eng_Vector3D>();
            List<Eng_Vector3D> expecteds = new List<Eng_Vector3D>() { pp0, pp1, pp2, pp3, pp4, pp5, pp6, pp7, pp8, pp9, pp10 };
            for (int i = 0; i < 11; i++)
            {
                tempActual = Functions.CatmullRomSpline(time, p0, p1, p2, p3);
                time += 0.1;

                actuals.Add(tempActual);
            }
            // Assert
            for (int i = 0; i < expecteds.Count; i++)
            {
                Assert.AreEqual(expecteds[i].X, Math.Round(actuals[i].X, 4));
                Assert.AreEqual(expecteds[i].Y, Math.Round(actuals[i].Y, 4));
                Assert.AreEqual(expecteds[i].Z, Math.Round(actuals[i].Z, 4));
            }
        }//end of TestCatmullRom3D
        #endregion
    }//eoc
}//eon

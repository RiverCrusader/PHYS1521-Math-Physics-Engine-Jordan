﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namesapces
using NUnit.Framework;
using Engine.Mathematics;
#endregion

namespace Engine.NunitTests.Demo
{
    [TestFixture]
    public class DemoTester
    {
        [Test,
        TestCase(0, 0, 3, 4, 5), // Instructor Data - MUST NOT DELETE OR MODIFY
        TestCase(0, 0, 6, 8, 10) // Student Data - MUST Change
    ]
        public void TestSegmentLenthPoint2D(double aX, double aY, double bX, double bY, double expected)
        {
            // Create Objects for the test
            
            // Performing the test
           
        }//eom

        public static IEnumerable<Object[]> MidPointData()
        {
            // Instructor Data - MUST NOT DELETE OR MODIFY
            // 1st new Eng_Point2D is the point A
            // 2nd new Eng_Point2D is the point B
            // 3rd new Eng_Point2D is the expected outcome
            yield return new Object[]
            {
                new Eng_Point2D(3, 4),      // point a
                new Eng_Point2D(6, 9),      // point b
                new Eng_Point2D(4.5, 6.5)   // expected midpoint
            };

            // Student Data - MUST Change
            // 1st new Eng_Point2D is the point A
            // 2nd new Eng_Point2D is the point B
            // 3rd new Eng_Point2D is student expected outcome
            yield return new Object[]
            {
                new Eng_Point2D(3, 4),      // point a
                new Eng_Point2D(6, 9),      // point b
                new Eng_Point2D(4.5, 5.5)   // expected midpoint
            };
        }//eom
        
        [Test, TestCaseSource(nameof(MidPointData))]
        public void TestMidpointPoint2D(Eng_Point2D a, Eng_Point2D b, Eng_Point2D expected)
        {
            // Performing the test (no setup required)
            
            // Assert - did we get back the correct answer
            
        }//eom
    }//eoc
}//eon

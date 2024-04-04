using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using NUnit.Framework;
using Engine.Mathematics;
using Engine.Physics;
#endregion

namespace Engine.Tests.Lab3
{
    [TestFixture]
    public class Lab3Tester
    {
        #region Part 1 - Linear Motion
        //3.a - Test 2.a - Calculate the final velocity and position of a Phys_Body that has initial position,
        //                 velocity, and acceleration properties set, over a given period of time.  
        [Test,
             // 1st - 3rd   = initial position 
             // 4th - 6th   = initial velocity
             // 7th - 9th   = acceleration
             // 10th        = time
             // 11th - 13th = expected final position
             // 14th - 16th = expected final velocity
             // Instructor Data - MUST NOT DELETE
             TestCase(0, 0, 0, 0, 0, 0, 2, 3, 0, 1.5, 2.25, 3.375, 0, 3, 4.5, 0),
             // Student Data - MUST CHANGE
             TestCase(2, 1, 0, 4, 0, 0, 6, -2, 0, 3, 39, -9, 0, 22, -6, 0)
        ]
        
        public void TestNonProjectileBody(
            double pIx, double pIy, double pIz,
            double vIx, double vIy, double vIz,
            double aX, double aY, double aZ,
            double t,
            double expPx, double expPy, double expPz,
            double expVx, double expVy, double expVz)
        {
            // Create objects for the test
            Eng_Vector3D position = new Eng_Vector3D(pIx,pIy,pIz);
            Eng_Vector3D velocity = new Eng_Vector3D(vIx,vIy,vIz);
            Eng_Vector3D acceloration = new Eng_Vector3D(aX,aY,aZ);

            Phys_Body actual = new Phys_Body(0,position,velocity,acceloration,0);
            // Perform the test
            actual.LinearPostionAndVelocity(actual, t);
            // Assert
            Assert.AreEqual(expPx, Math.Round(actual.Position.X, 4));
            Assert.AreEqual(expPy, Math.Round(actual.Position.Y, 4));
            Assert.AreEqual(expPz, Math.Round(actual.Position.Z, 4));
            Assert.AreEqual(expVx, Math.Round(actual.Velocity.X, 4));
            Assert.AreEqual(expVy, Math.Round(actual.Velocity.Y, 4));
            Assert.AreEqual(expVz, Math.Round(actual.Velocity.Z, 4));
        }//end of TestNonProjectileBody

        //3.b - Test 2.b - Calculate the new position of a Phys_Body, which has its initial position and
        //                 velocity set, that is launched as a projectile, in a given Phys_World (the 
        //                 gravity property of the Phys_World is set).
        [Test,
            // Launch horizontally
            // 1st			= gravity
            // 2nd - 4th	= initial position vector
            // 5th - 6th	= initial velocity mag@dir
            // Remainder	= expected final position
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(-9.81, 0, 8, 0, 10, 0,  12.771, 0, 0),
            // Student Data - MUST CHANGE
            TestCase(-9.81, 0, 7, 0, 31, 0, 37.0332, 0, 0),

            // Launch at an angle
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(-9.81, 0, 8, 0,  10, 30, 16.3223, 0, 0),
            // Student Data - MUST CHANGE
            TestCase(-9.81, 2, 7, 0, 17, 19, 30.3044, 0, 0)
        ]

        public void TestLaunchProjectile(
            double g,
            double pIx, double pIy, double pIz,
            double mag, double dir,
            double expX, double expY, double expZ)
        {
            // Create Objects for the test
            Phys_World actualPlanet = new Phys_World(g);

            Eng_Vector3D position = new Eng_Vector3D(pIx, pIy, pIz);
            Eng_Vector3D velocity = new Eng_Vector3D(mag, dir, 0);
            Eng_Vector3D acceloration = new Eng_Vector3D();

            Phys_Body actual = new Phys_Body(0, position, velocity, acceloration, 0);
            // Perform the test
            actual = actual.ProjectilePostionAndVelocity(actualPlanet, actual);
            // Assert
            Assert.AreEqual(expX, Math.Round(actual.Position.X, 4));
            Assert.AreEqual(expY, Math.Round(actual.Position.Y, 4));
            Assert.AreEqual(expZ, Math.Round(actual.Position.Z, 4));
        }//end of TestLaunchProjectile
        #endregion

        #region Part 2 - Rotational Motion
        //2.a - Test 1.a - Set the rotational motion properties of the Phys_Body given a Phys_Body and
        //                 a rotational speed in RPM.
        [Test, 
            // 1st = RPM
            // 2nd = radius of rotation
            // 3rd = expected angular velocity
            // 4th = expected tangential velocity
            // 5th = expected centripetal acceleration
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(5400, 0.06,  565.4867, 33.9292, 19186.511),
            // Student Data - MUST CHANGE
            TestCase(5400, 0.06, 565.4867, 33.9292, 19186.511)
        ]

        public void TestCentripetalAcceleration(double rpm, double radius, double expectedOmega, double expectedVT, double expectedAlpha)
        {
            // Create Objects for the test
            Phys_Body actual = new Phys_Body(0, radius);
            // Perform the test
            actual.CalculateCentripetalAcceleration(actual, rpm);
            // Assert
            Assert.AreEqual(expectedOmega, Math.Round(actual.Omega, 4));
            Assert.AreEqual(expectedVT, Math.Round(actual.VelocityT, 4));
            Assert.AreEqual(expectedAlpha, Math.Round(actual.CentripetalAcceleration, 4));
        }//end of TestCentripetalAcceleration
        #endregion

        #region Part 3 - Forces
        //2.a - Test 1.a - Calculate the new properties, position, velocity, and acceleration of a
        //                 Phys_Body (i.e. return a Phys_Body) in a set Phys_World (with gravity set),
        //                 given an external force applied, a given µ (mu), an incline angle (in degrees),
        //                 and over a specified time.
        [Test,
            // 1st			= gravity
            // 2nd - 6th	= Phys_Body
            // 7th			= mu
            // 8th			= incline angle in degrees
            // 9th - 10th	= applied force (mag@dir)
            // 11th			= time
            // Remainder	= new Phys_Body properties
            // Instructor Data - MUST NOT DELETE OR MODIFY
            // 1. Non-incline, force parallel to ground
            TestCase(-9.81,  10, 0, 0, 0, 0, 0.10, 0, 50, 0, 1,  2.0095, 0, 0, 4.019, 0, 0, 4.019, 0, 0),
            // Student Data - MUST CHANGE
            TestCase(-9.81, 150, 0, 0, 0, 0, 0, 0, 1500, 20, 2, 1.3564, 0, 0, 2.256, 0, 0, 4.019, 0, 0),

            // 2. Non-incline, force at an angle
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(-9.81, 10, 0, 0, 0, 0, 0.10, 0, 50, 10, 1, 2.0149, 0, 0, 4.0299, 0, 0, 4.0299, 0, 0),
            // Student Data - MUST CHANGE
            TestCase(-9.81, 13, 0, 0, 0, 0, 0.35, 0, 65, 8, 4, 2.0149, 0, 0, 4.0299, 0, 0, 4.0299, 0, 0),

            // 3. Incline, force parallel to incline
            TestCase(-9.81, 10, 0, 0, 0, 0, 0.10, 10, 50, 0, 1, 1.1652, 0, 0, 2.3304, 0, 0, 2.3304, 0, 0),
            // Student Data - MUST CHANGE
            TestCase(-9.81, 13, 0, 0, 0, 0, 0.35, 26, 65, 0, 4, 1.1652, 0, 0, 2.3304, 0, 0, 2.3304, 0, 0),

            // 4. Incline , force applied at an angle
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(-9.81, 10, 0, 0, 0, 0, 0.10, 10, 50, 10, 1, 1.1706, 0, 0, 2.3413, 0, 0, 2.3413, 0, 0),
            // Student Data - MUST CHANGE
            TestCase(-9.81, 13, 0, 0, 0, 0, 0.35, 26, 65, 8, 4, 1.1706, 0, 0, 2.3413, 0, 0, 2.3413, 0, 0)
        ]

        public void TestAppliedForce(
            double gravity,
            double mass, double vX, double vY, double vZ, double radius,
            double mu,
            double incline,
            double fMag, double fDir,
            double t,
            double expPx, double expPy, double expPz, double expVx, double expVy, double expVz, double expAx, double expAy, double expAz
            )
        {
            // Create Objects for the test
            Phys_World planet = new Phys_World(gravity);
            Phys_Body actual = new Phys_Body(mass, new Eng_Vector3D(0, 0, 0), new Eng_Vector3D(vX, vY, vZ), new Eng_Vector3D(0, 0, 0), radius);
            Eng_Vector3D force = new Eng_Vector3D(fMag, fDir, 0);
            // Perform the test
            actual.ApplyForce(planet, actual, force, mu, incline, t);
            // Assert
            Assert.AreEqual(expPx, Math.Round(actual.Position.X, 4));
            Assert.AreEqual(expPy, Math.Round(actual.Position.Y, 4));
            Assert.AreEqual(expPz, Math.Round(actual.Position.Z, 4));
            Assert.AreEqual(expVx, Math.Round(actual.Velocity.X, 4));
            Assert.AreEqual(expVy, Math.Round(actual.Velocity.Y, 4));
            Assert.AreEqual(expVz, Math.Round(actual.Velocity.Z, 4));
            Assert.AreEqual(expAx, Math.Round(actual.Acceleration.X, 4));
            Assert.AreEqual(expAy, Math.Round(actual.Acceleration.Y, 4));
            Assert.AreEqual(expAz, Math.Round(actual.Acceleration.Z, 4));
        }//end of TestAppliedForce

        //2.b - Test 1.b - Calculate the new velocity properties of two Phys_Body objects after they come
        //                 into contact with each other; each Phys_Body will have its position, velocity,
        //                 mass, and radius properties set before the collision.
        public static IEnumerable<Object[]> TestCollisionData()
        {
            // Instructor Data - MUST NOT DELETE OR MODIFY
            yield return new Object[]
            {
                new Phys_Body(1, new Eng_Vector3D(-0.6, 0.6 ,0), new Eng_Vector3D(3, 1, 0),new Eng_Vector3D(), 1),			// initial a
                new Phys_Body(2, new Eng_Vector3D(0.6, -1, 0), new Eng_Vector3D(2, 3, 0), new Eng_Vector3D(), 1),			// initial b
                new Phys_Body(1, new Eng_Vector3D(-0.6, 0.6 ,0), new Eng_Vector3D(1.24, 3.3467, 0),new Eng_Vector3D(), 1),	// expected a
                new Phys_Body(2, new Eng_Vector3D(0.6, -1, 0), new Eng_Vector3D(2.88, 1.8267, 0), new Eng_Vector3D(), 1),	// Expected b
            };
            // Student Data - YOU NEED TO ADD YOUR DATA BELOW
            yield return new Object[]
            {
                new Phys_Body(7, new Eng_Vector3D(-1, 2 ,0), new Eng_Vector3D(4, 3, 0),new Eng_Vector3D(), 8),			// initial a
                new Phys_Body(5, new Eng_Vector3D(5, -5, 0), new Eng_Vector3D(7, 5, 0), new Eng_Vector3D(), 2),			// initial b
                new Phys_Body(7, new Eng_Vector3D(-1, 2 ,0), new Eng_Vector3D(4.2353, 2.7255, 0),new Eng_Vector3D(), 8),	// expected a
                new Phys_Body(5, new Eng_Vector3D(5, -5, 0), new Eng_Vector3D(6.6706, 5.3843, 0), new Eng_Vector3D(), 2),// Expected b
            };
        }//end of TestCollisionData
        
        [Test, TestCaseSource(nameof(TestCollisionData))]
        public void TestCircleCollision(Phys_Body a, Phys_Body b, Phys_Body aExp, Phys_Body bExp)
        {
            // Perform the test
            Tuple<Phys_Body,Phys_Body> actual = a.Collision(a, b);
            //Assert
            Assert.AreEqual(aExp.Mass, Math.Round(actual.Item1.Mass, 4));
            Assert.AreEqual(aExp.Position.Y, Math.Round(actual.Item1.Position.Y,4));
            Assert.AreEqual(aExp.Position.X, Math.Round(actual.Item1.Position.X, 4));
            Assert.AreEqual(aExp.Position.Z, Math.Round(actual.Item1.Position.Z, 4));
            Assert.AreEqual(aExp.Velocity.Y, Math.Round(actual.Item1.Velocity.Y, 4));
            Assert.AreEqual(aExp.Velocity.X, Math.Round(actual.Item1.Velocity.X, 4));
            Assert.AreEqual(aExp.Velocity.Z, Math.Round(actual.Item1.Velocity.Z, 4));
            Assert.AreEqual(aExp.Radius, Math.Round(actual.Item1.Radius, 4));

            Assert.AreEqual(bExp.Mass, Math.Round(actual.Item2.Mass, 4));
            Assert.AreEqual(bExp.Position.Y, Math.Round(actual.Item2.Position.Y, 4));
            Assert.AreEqual(bExp.Position.X, Math.Round(actual.Item2.Position.X, 4));
            Assert.AreEqual(bExp.Position.Z, Math.Round(actual.Item2.Position.Z, 4));
            Assert.AreEqual(bExp.Velocity.Y, Math.Round(actual.Item2.Velocity.Y, 4));
            Assert.AreEqual(bExp.Velocity.X, Math.Round(actual.Item2.Velocity.X, 4));
            Assert.AreEqual(bExp.Velocity.Z, Math.Round(actual.Item2.Velocity.Z, 4));
            Assert.AreEqual(bExp.Radius, Math.Round(actual.Item2.Radius, 4));
        }//end of TestCircleCollision
        #endregion
        //applied Forces are still broken

        #region Part 4 - Gravitational Forces
        //3.a - Test 1.a - Calculate the force of attraction between two celestial bodies.
        [Test,
            // 1st = mass body 1
            // 2nd = mass of body 2
            // 3rd = distance between the centers of body 1 and body 2
            // 4th = expected gravitational force
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(5.98e24, 70, 6.39e6, 684.0985),
            // Student Data - MUST CHANGE
            TestCase(8.254e22, 3251, 7.45e8, 0.0323)
        ]

        public void TestGravitationalForce(double massA, double massB, double d, double expected)
        {
            // Create Objects for the test
            Phys_Body a = new Phys_Body(massA, new Eng_Vector3D(0, 0, 0), new Eng_Vector3D(0, 0, 0), new Eng_Vector3D(0, 0, 0), 0);
            Phys_Body b = new Phys_Body(massB, new Eng_Vector3D(0, 0, 0), new Eng_Vector3D(0, 0, 0), new Eng_Vector3D(0, 0, 0), 0);
            // Perform the test
            double actual = a.GravitationalForce(a, b, d);
            // Assert
            Assert.AreEqual(expected, Math.Round(actual,4));
        }//end of TestGravitationalForce

        //3.b - Test 2.a - Calculate and set the gravity property of the Phys_World with an input of a celestial Phys_Body.
        [Test,
            // 1st = mass
            // 2nd = radius
            // 3rd = expected gravity
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(5.972e24, 6.371e6, -9.8181),
            // Student Data - MUST CHANGE
            TestCase(2.956e24, 7.293e6, -3.7086)
        ]

        public void TestCalculateGravity(double mass, double radius, double expected)
        {
            // Create Objects for the test
            Phys_Body planet = new Phys_Body(mass, new Eng_Vector3D(0, 0, 0), new Eng_Vector3D(0, 0, 0), new Eng_Vector3D(0, 0, 0), radius);
            // Perform the test
            Phys_World actual = new Phys_World(planet);
            // Assert
            Assert.AreEqual(expected, Math.Round(actual.Gravity.Y, 4));
        }//end of TestCalculateGravity
        #endregion

        #region Part 5 - Springs
        //3.a - Test 1.a - Set the properties of a Spring from rest length, stretched length, and force.
        [Test,
            // 1st = spring length at rest
            // 2nd = stretched length
            // 3rd = force applied
            // 4th = expected spring constant
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(0.05, 0.075, 10, 400),
            // Student Data - MUST CHANGE
            TestCase(0.047, 0.031, 23, 1437.5)
        ]

        public void CalculateSpringConstant(double lRest, double l, double force, double expected)
        {
            // Perform the test
            Spring actual = new Spring(lRest,l,force);
            // Assert
            Assert.AreEqual(expected, Math.Round(actual.K, 4));
        }//end of CalculateSpringConstant

        //3.b - Test 2.a - Calculate the restorative force given a Spring and a stretched length.
        [Test,
            // 1st = spring length at rest
            // 2nd = spring constant
            // 3rd = compressed length
            // 4th = expected force needed
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(0.05, 400, 0.075, 10),
            // Student Data - MUST CHANGE
            TestCase(0.047, 1437.5, 0.031, 23)
        ]

        public void TestCalculateForce(double lRest, double k, double l, double expected)
        {
            // Create Objects for the test
            Spring spring = new Spring(k, lRest);
            // Perform the test
            double actual = spring.CalculateForce(spring, l);
            // Assert
            Assert.AreEqual(expected,Math.Round(actual, 4));
        }//end of TestCalculateForce

        //3.c - Test 2.b - Calculate the stretched length of a spring with an applied force.
        [Test,
            // 1st = spring length at rest
            // 2nd = spring constant
            // 3rd = applied force
            // 4th = expected stretched length
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(0.05, 400, 10, 0.075),
            // Student Data - MUST CHANGE
            TestCase(0.047, 1437.5, 23, 0.078)
        ]

        public void TestCalculateNewLength(double lRest, double k, double force, double expected)
        {
            // Create Objects for the test
            Spring spring = new Spring(k, lRest);
            // Perform the test
            double actual = spring.CalculateLength(spring, force);
            // Assert
            Assert.AreEqual(expected, Math.Round(actual, 4));
        }//end of TestCalculateNewLength

        //3.d - Test 2.c - Calculate the frequency of oscillation (in a frictionless environment) of a Spring 
        //                 that has a mass suspended from it.
        [Test,
            // 1st = spring length at rest
            // 2nd = spring constant
            // 3rd = mass
            // 4th = expected frequency
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(0.05, 1250, 2.5, 3.5588),
            // Student Data - MUST CHANGE
            TestCase(0.047, 1437.5, 7, 2.2807)
        ]

        public void TestSpringFrequency(double lRest, double k, double mass, double expected)
        {
            // Create Objects for the test
            Spring spring = new Spring(k, lRest);
            // Perform the test
            double actual = spring.CalcualteSpringFreq(spring, mass);
            // Assert
            Assert.AreEqual(expected, Math.Round(actual, 4));
        }//end of TestSpringFrequency

        //3.e - Test 2.d - Calculate the velocity at rest position of an oscillating Spring.
        [Test,
            // 1st = spring length at rest
            // 2nd = spring constant
            // 3rd = amplitude
            // 4th = mass
            // 5th = expected velocity at rest length
            // Instructor Data - MUST NOT DELETE OR MODIFY
            TestCase(0.05, 1250, 0.075, 2.5, 1.6771),
            // Student Data - MUST CHANGE
            TestCase(0.047, 1437.5, 0.031, 7, 0.4442)
        ]

        public void TestSpringRestVelocity(double lRest, double k, double l, double mass, double expected)
        {
            // Create Objects for the test
            Spring spring = new Spring(k, lRest);
            // Perform the test
            double actual = spring.VelocityAtRestLength(spring, mass,l);
            // Assert
            Assert.AreEqual(expected, Math.Round(actual, 4));
        }//end of TestSpringRestVelocity
        #endregion
    }//eoc
}//eon

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Engine.Mathematics;
#endregion

namespace Engine.Physics
{
    public class Phys_Body
    {
        #region Class Constants
        public const double G = 6.673e-11; // linear motion properties
        #endregion
		// linear motion properties
        public double Mass { get; set; }
        public Eng_Vector3D Position { get; set; }
        public Eng_Vector3D Velocity { get; set; }
        public Eng_Vector3D Acceleration { get; set; }
        public double Radius { get; set; }
        // rotational motion properties
        public double Omega { get; set; }                   // angular velocity
        public double Alpha { get; set; }                   // angular acceleration
        public double VelocityT { get; set; }               // tangential velocity
        public double CentripetalAcceleration { get; set; } // also know as tangential acceleration

        // Constructors
        // Empty constructor
        public Phys_Body()
        {
            Mass = 0;
            Position = new Eng_Vector3D(0, 0, 0);
            Velocity = new Eng_Vector3D(0, 0, 0);
            Acceleration = new Eng_Vector3D(0, 0, 0);
            Radius = 0;
            Omega = 0;
            Alpha = 0;
            CentripetalAcceleration = 0;
        }//eom

        // Greedy constructor for linear motion
        public Phys_Body(double mass, Eng_Vector3D position, Eng_Vector3D velocity, Eng_Vector3D acceleration, double radius)
        {
            Mass = mass;
            Position = position;
            Velocity = velocity;
            Acceleration = acceleration;
            Radius = radius;
        }//eom

        // Greedy constructor for rotational motion
        public Phys_Body(double omega, double radius)
        {
            Omega = omega;
            Radius = radius;
        }//eom


        #region Class Methods
		//2.a - Calculate the final velocity and position of a Phys_Body that has initial position,
		//      velocity, and acceleration properties set, over a given period of time.
		//		HINT: Modify the velocity an position properties of the Phys_Body
        public Phys_Body LinearPostionAndVelocity(Phys_Body b, double t)
        {
            b.Velocity = b.Velocity + (b.Acceleration * t);
            b.Position = (b.Velocity * t) + (b.Acceleration * 0.5 * Math.Pow(t, 2));

			return b;
		}//end of LinearPostionAndVelocity

        //2.b - Calculate the new position of a Phys_Body, which has its initial position and
        //      velocity set, that is launched as a projectile, in a given Phys_World (the 
		//      gravity property of the Phys_World is set).
		//		HINT: Modify the properties of the Phys_Body
        public Phys_Body ProjectilePostionAndVelocity(Phys_World w, Phys_Body b)
        {
			b.Position = 

			return b;
		}//end of ProjectilePostionAndVelocity

        //1.a - Set the rotational motion properties of the Phys_Body given a Phys_Body and
		//      a rotational speed in RPM.
		//		HINT: Modify the properties of the Phys_Body
        public Phys_Body CalculateCentripetalAcceleration(Phys_Body b, double rpm)
        {
			
			return b;
		}//end of CalculateCentripetalAcceleration

        //1.a - Calculate the new properties, position, velocity, and acceleration of a
        //      Phys_Body (i.e. return a Phys_Body) in a set Phys_World (with gravity set),
        //      given an external force applied, a given µ (mu), an incline angle (in degrees),
        //      and over a specified time.
		//		HINT: Modify the properties of the Phys_Body
        public Phys_Body ApplyForce(Phys_World w, Phys_Body b, Eng_Vector3D force, double mu, double angle, double t)
        {
			
			return b;
		}//end of ApplyForce

        //1.b - Calculate the new velocity properties of two Phys_Body objects after they come
        //      into contact with each other; each Phys_Body will have its position, velocity,
        //      mass, and radius properties set before the collision.
		//		HINT: Modify the properties of each Phys_Body
        public Tuple<Phys_Body, Phys_Body> Collision(Phys_Body a, Phys_Body b)
        {
			
			return Tuple.Create(a, b);
		}//end of Collision

        //1.a - Calculate the force of attraction between two celestial bodies.
        public double GravitationalForce(Phys_Body a, Phys_Body b, double d)
        {
			
		}//end of GravitationalForce
        #endregion
    }//eoc
}//eon

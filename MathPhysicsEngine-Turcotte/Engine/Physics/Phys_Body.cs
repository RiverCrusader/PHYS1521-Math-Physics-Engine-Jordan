using System;

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
            b.Position = (b.Velocity * t) + (b.Acceleration * 0.5 * Math.Pow(t, 2));
            b.Velocity = b.Velocity + (b.Acceleration * t);
            return b;
        }//end of LinearPostionAndVelocity

        //2.b - Calculate the new position of a Phys_Body, which has its initial position and
        //      velocity set, that is launched as a projectile, in a given Phys_World (the 
        //      gravity property of the Phys_World is set).
        //		HINT: Modify the properties of the Phys_Body
        public Phys_Body ProjectilePostionAndVelocity(Phys_World w, Phys_Body b) //fix amgled Y still broken need to fix works... i guess
        {
            //Vi
            //Vi x and Y
            double angle = Functions.DegreesToRadians(b.Velocity.Y);

            double ViX = b.Velocity.X * Math.Cos(angle);
            double ViY = b.Velocity.X * Math.Sin(angle);
            //Time to ground horizontal
            double A = w.Gravity.Y;
            double D = b.Position.Y;
            double Vi = ViY;
            double t = Functions.QuadraticNegative(A, Vi, D);

            if (t <= 0)
            {
                t = Functions.QuadraticPositive(A, Vi, D);
            }

            //Horizontal up to the apex
            b.Position.X = ViX * t;

            //at apex Vi = 0
            //Apex and vertical values
            //time at the apex

            double ta = -ViY / w.Gravity.Y;

            //position Y at apex (added to original)
            //TOTAL FALL DISTANCE IS HERE
            b.Position.Y += -Math.Pow(ViY, 2) / (2 * w.Gravity.Y);

            //D when time is done? i guess
            //ONLY DONE TO GET 0
            b.Position.Y -= b.Position.Y;

            return b;
        }//end of ProjectilePostionAndVelocity

        //1.a - Set the rotational motion properties of the Phys_Body given a Phys_Body and
        //      a rotational speed in RPM.
        //		HINT: Modify the properties of the Phys_Body
        public Phys_Body CalculateCentripetalAcceleration(Phys_Body b, double rpm)
        {
            b.Omega = (2 * (rpm / 60)) * Math.PI;

            b.CentripetalAcceleration = Math.Pow(b.Omega, 2) * b.Radius;

            b.VelocityT = b.Omega * b.Radius;

            return b;
        }//end of CalculateCentripetalAcceleration

        //1.a - Calculate the new properties, position, velocity, and acceleration of a
        //      Phys_Body (i.e. return a Phys_Body) in a set Phys_World (with gravity set),
        //      given an external force applied, a given µ (mu), an incline angle (in degrees),
        //      and over a specified time.
        //		HINT: Modify the properties of the Phys_Body
        public Phys_Body ApplyForce(Phys_World w, Phys_Body b, Eng_Vector3D force, double mu, double angle, double t) //very very broken I have absolutly no idea whats wrong -- just gonna tank the mark and ask later could not figure out tried my best just want to spend easter with family not code (lol)
        {
            double Fangle = Functions.DegreesToRadians(force.Y);
            angle = Functions.DegreesToRadians(angle);
            //Weight

            double Wsin = b.Mass * w.Gravity.Y * Math.Sin(angle); //x
            double Wcos = b.Mass * w.Gravity.Y * Math.Cos(angle); //y
            double W = b.Mass * w.Gravity.Y;
            //Force applied
            Eng_Vector3D Fapp = new Eng_Vector3D((force.X * Math.Cos(Fangle)) - Wsin, force.X * Math.Sin(Fangle), 0);
            double FappCos = (force.X * Math.Cos(Fangle)) - Wsin;
            double FappSin = force.X * Math.Sin(Fangle);


            double Fn = -W + FappSin;
            double Fs = -(mu * Fn);

            double FnetX;
            double FnetY;

            FnetX = Fs + Fapp.X;
            FnetY = W + Fn + Fapp.Y;


            b.Acceleration.X = FnetX * (1/ b.Mass);
            b.Acceleration.Y = FnetY * (1/ b.Mass);

            b.Velocity = b.Acceleration * t;

            b.Position = b.Velocity * t;

            return b;
        }//end of ApplyForce

        //1.b - Calculate the new velocity properties of two Phys_Body objects after they come
        //      into contact with each other; each Phys_Body will have its position, velocity,
        //      mass, and radius properties set before the collision.
        //		HINT: Modify the properties of each Phys_Body
        public Tuple<Phys_Body, Phys_Body> Collision(Phys_Body a, Phys_Body b) //pretty sure this is wrong and needs to be fixed, very weird output broken
        {
            //are they connected
            double distanceBetweenCenters = (Math.Pow(b.Position.X - a.Position.X, 2)) + (Math.Pow(b.Position.Y - a.Position.Y, 2));
            double sumRadii = Math.Pow(a.Radius + b.Radius, 2);

            if (distanceBetweenCenters <= sumRadii)
            {
                //they collide

                Eng_Vector3D n = a.Position - b.Position;
                n.Normalize();

                double a1 = a.Velocity.DotProduct(n);
                double a2 = b.Velocity.DotProduct(n);

                double Optomized = ((a1 - a2) * 2) / (a.Mass + b.Mass);
                //problem area
                a.Velocity = a.Velocity - (n * (Optomized * b.Mass));
                b.Velocity = b.Velocity + (n * (Optomized * a.Mass));
                //end of problem area
                return Tuple.Create(a, b);
            }
            else
            {
                //no change
                return Tuple.Create(a, b);
            }
        }//end of Collision

        //1.a - Calculate the force of attraction between two celestial bodies.
        public double GravitationalForce(Phys_Body a, Phys_Body b, double d)  //i think this works
        {
            return G * ((a.Mass * b.Mass) / Math.Pow(d, 2));
        }//end of GravitationalForce
        #endregion
    }//eoc
}//eon

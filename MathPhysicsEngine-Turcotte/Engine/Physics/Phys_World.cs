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
    public class Phys_World
    {
        public Eng_Vector3D Gravity { get; set; }

        // Constructors
        public Phys_World()
        {
            Gravity = new Eng_Vector3D(0, -9.81, 0);
        }//eom

        public Phys_World(double g)
        {
            Gravity = new Eng_Vector3D(0, g, 0);
        }//eom

        //2.a - Calculate and set the gravity property of the Phys_World with an input of a celestial Phys_Body.
		//HINT: Set the Gravity property
        public Phys_World(Phys_Body b)
        {
            Gravity = new Eng_Vector3D(0, Phys_Body.G * (b.Mass / Math.Pow(b.Radius, 2)), 0);
		}//eom

    }//eoc
}//eon

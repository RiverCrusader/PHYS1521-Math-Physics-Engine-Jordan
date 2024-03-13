using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Physics
{
    public class Spring
    {
        // Properties
        public double K { get; set; }
        public double LRest { get; set; }

        // Constructors
        public Spring(){}//eom

        public Spring(double k, double lRest)
        {
            K = k;
            LRest = lRest;
        }//end of Spring

        //1.a - Set the properties of a Spring from rest length, stretched length, and force.
		public Spring(double lRest, double l, double force)
        {
			
		}//end of Spring
        
        #region Class Methods
        //2.a - Calculate the restorative force given a Spring and a stretched length.
        public double CalculateForce(Spring s, double l)
        {
			
		}//end of CalculateForce

        //2.b - Calculate the stretched length of a spring with an applied force.
        public double CalculateLength(Spring s, double force)
        {
			
		}//end of CalculateLength

        //2.c - Calculate the frequency of oscillation (in a frictionless environment) of a Spring 
		//      that has a mass suspended from it.
        public double CalcualteSpringFreq(Spring s, double mass)
        {
			
		}//end of CalcualteSpringFreq

        //2.d - Calculate the velocity at rest position of an oscillating Spring.
        public double VelocityAtRestLength(Spring s, double mass, double length)
        {
			
		}//end of VelocityAtRestLength
        #endregion
    }//eoc
}//eon

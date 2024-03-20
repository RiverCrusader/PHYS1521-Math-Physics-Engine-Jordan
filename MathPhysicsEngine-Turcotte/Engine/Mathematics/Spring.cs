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
            LRest = lRest;
            K = (force / (lRest - l));
		}//end of Spring
        
        #region Class Methods
        //2.a - Calculate the restorative force given a Spring and a stretched length.
        public double CalculateForce(Spring s, double l)
        {
            return s.K * (s.LRest - l);
		}//end of CalculateForce

        //2.b - Calculate the stretched length of a spring with an applied force.
        public double CalculateLength(Spring s, double force)
        {
			return s.LRest - (force / s.K);
		}//end of CalculateLength

        //2.c - Calculate the frequency of oscillation (in a frictionless environment) of a Spring 
		//      that has a mass suspended from it.
        public double CalcualteSpringFreq(Spring s, double mass) // calculate is spelled wrong
        {
			return (1/(2*Math.PI))*(Math.Sqrt(s.K * mass));
		}//end of CalcualteSpringFreq

        //2.d - Calculate the velocity at rest position of an oscillating Spring.
        public double VelocityAtRestLength(Spring s, double mass, double length)
        {
            double springFreq = CalcualteSpringFreq(s, mass);

            return (-1 * (s.LRest - length)) * springFreq;
		}//end of VelocityAtRestLength
        #endregion
    }//eoc
}//eon

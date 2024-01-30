using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Mathematics
{
    public class Functions
    {
        #region Class Variabbles
        private static double pi = Math.PI;
		#endregion

		#region Methods for later use

		#endregion

		#region General Math
		//1.a - A method to convert degrees to radians

		public double DegreesToRadians(double inputDegree)
		{
			double outputRadian;
			outputRadian = inputDegree * pi;
			outputRadian = outputRadian / 180;
			return outputRadian;
		}

		//1.b - A method to convert radians to degrees

		public double RadiansToDegrees(double inputRadian)
		{
			double outputDegree;
			outputDegree = inputRadian / pi;
			outputDegree = outputDegree * 180;
			return outputDegree;
		}
		#endregion

		#region Solve Right Triangles
		//1.c - A method to solve a right triangle given an angle in degrees and the hypotenuse;
		//      returns a Tuple<double, double> for the missing sides (adjacent, opposite).

		public static Tuple<double, double> FindAdjacentAndOpposite(double degrees, double hypotenuse)
		{
			double adjacent, opposite;

			//sine()opp/hyp



			//cosine()adj/hyp

			return Tuple.Create(adjacent, opposite);
        }

		//1.d – A method to solve a right triangle given an angle in degrees and the side opposite;
		//      returns a Tuple<double, double> for the missing sides (adjacent, hypotenuse).

		//1.e – A method to solve a right triangle given an angle in degrees and the side adjacent;
		//      returns a Tuple<double, double> for the missing sides (opposite, hypotenuse).

		//1.f – A method to solve a right triangle given side opposite and side adjacent;
		//      returns a Tuple<double, double> for the missing side and the angle in degrees.

		//1.g – A method to solve a right triangle given side opposite and hypotenuse;
		//      returns a Tuple<double, double> for the missing side and the angle in degrees.

		//1.h – A method to solve a right triangle given side adjacent and hypotenuse;
		//      returns a Tuple<double, double> for the missing side and the angle in degrees.

		#endregion
	}//eoc
}//eon

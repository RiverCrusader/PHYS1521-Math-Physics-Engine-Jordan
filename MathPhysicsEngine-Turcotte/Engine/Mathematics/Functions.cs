﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Mathematics
{
    public static class Functions
    {
        #region Class Variabbles
        private static double pi = Math.PI;
        #endregion

        #region Methods for later use
        public static double QuadraticNegative(double a, double b, double c)
        {
            double b2 = b * b;
            double ac2 = 2 * a * c;
            double root = b2 - ac2;
            return (-1 * b - Math.Sqrt(root)) / a;
        }//eom

        public static double QuadraticPositive(double a, double b, double c)
        {
            double b2 = b * b;
            double ac2 = 2 * a * c;
            double root = b2 - ac2;
            return (-1 * b + Math.Sqrt(root)) / a;
        }//eom
        #endregion

        #region General Math
        //1.a - A method to convert degrees to radians

        public static double DegreesToRadians(double inputDegree)
		{
			double outputRadian;
			outputRadian = inputDegree * pi;
			outputRadian = outputRadian / 180;

			return outputRadian;
		}

		//1.b - A method to convert radians to degrees

		public static double RadiansToDegrees(double inputRadian)
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
            degrees = DegreesToRadians(degrees);
            //sine()opp/hyp

            opposite = Math.Sin(degrees) * hypotenuse;

            //cosine()adj/hyp

            adjacent = Math.Cos(degrees) * hypotenuse;

			return Tuple.Create(adjacent, opposite);
        }

        //1.d – A method to solve a right triangle given an angle in degrees and the side opposite;
        //      returns a Tuple<double, double> for the missing sides (adjacent, hypotenuse).

        public static Tuple<double, double> FindAdjacentAndHypotenuse(double degrees, double opposite)
        {
            double adjacent, hypotenuse;
            degrees = DegreesToRadians(degrees);
            //sine()opp/hyp

            hypotenuse = opposite / Math.Sin(degrees);

            //tangent()opp/adj

            adjacent = opposite / Math.Tan(degrees) ;

			return Tuple.Create(adjacent, hypotenuse);
        }

        //1.e – A method to solve a right triangle given an angle in degrees and the side adjacent;
        //      returns a Tuple<double, double> for the missing sides (opposite, hypotenuse).

        public static Tuple<double, double> FindOppositeAndHypotenuse(double degrees, double adjacent)
        {
            double opposite, hypotenuse;
            degrees = DegreesToRadians(degrees);
            //tangent()opp/adj

            opposite = Math.Tan(degrees) * adjacent;

			//cosine()adj/hyp

			hypotenuse = adjacent / Math.Cos(degrees);

			return Tuple.Create(opposite, hypotenuse);
        }

        //1.f – A method to solve a right triangle given side opposite and side adjacent;
        //      returns a Tuple<double, double> for the missing side and the angle in degrees.

        public static Tuple<double, double> FindHypotenuseAndDegree(double opposite, double adjacent)
        {
            double degrees, hypotenuse;

            //A2 + B2 = C2

            hypotenuse = Math.Pow(opposite, 2) + Math.Pow(adjacent, 2);
            hypotenuse = Math.Sqrt(hypotenuse);

			//tangent()opp/adj

			degrees = Math.Atan(opposite/adjacent);

            return Tuple.Create(hypotenuse,degrees) ;
        }

        //1.g – A method to solve a right triangle given side opposite and hypotenuse;
        //      returns a Tuple<double, double> for the missing side and the angle in degrees.

        public static Tuple<double, double> FindAdjacentAndDegree(double opposite, double hypotenuse)
        {
            double degrees, adjacent;

            //C2 - B2 = A2

            adjacent = Math.Pow(hypotenuse, 2) - Math.Pow(opposite, 2);
            adjacent = Math.Sqrt(adjacent);

			//sine()opp/hyp

			degrees = Math.Asin(opposite / hypotenuse);

			return Tuple.Create(adjacent, degrees);
        }

        //1.h – A method to solve a right triangle given side adjacent and hypotenuse;
        //      returns a Tuple<double, double> for the missing side and the angle in degrees.

        public static Tuple<double, double> FindOppositeAndDegree(double adjacent, double hypotenuse)
        {
            double degrees, opposite;

            //C2 - A2 = B2

            opposite = Math.Pow(hypotenuse, 2) - Math.Pow(adjacent, 2);
            opposite = Math.Sqrt(opposite);

			//Cosine()adj/hyp

			degrees = Math.Acos(adjacent / hypotenuse);

			return Tuple.Create(opposite, degrees);
        }

        #endregion

        #region Lab 4 - Part 1: Bezier Curves
        // 1.a - Quadratic Bezier 2D
        public static Eng_Vector2D QuadraticBezier(double t, Eng_Vector2D p0, Eng_Vector2D p1, Eng_Vector2D p2)
        {
            double ts = 1 - t,
                ts2 = ts * ts,
                t2 = t * t;
            return p0 * ts2 + 2 * p1 * t * ts + p2 * t2;
        }//end of QuadraticBezier

        // 1.b - Cubic Bezier 2D
        public static Eng_Vector2D CubicBezier(double t, Eng_Vector2D p0, Eng_Vector2D p1, Eng_Vector2D p2, Eng_Vector2D p3)
        {
            double ts = 1 - t,
                ts2 = ts * ts,
                ts3 = ts2 * ts,
                t2 = t * t,
                t3 = t2 * t;
            return p0 * ts3 + 3 * t * p1 * ts2 + 3 * p2 * t2 * ts + p3 * t3;
        }//end of CubicBezier

        // 1.c - Quartic Bezier 2D
        public static Eng_Vector2D QuarticBezier(double t, Eng_Vector2D p0, Eng_Vector2D p1, Eng_Vector2D p2, Eng_Vector2D p3, Eng_Vector2D p4)
        {
            double ts = 1 - t,
                ts2 = ts * ts,
                ts3 = ts2 * ts,
                ts4 = ts3 * ts,
                t2 = t * t,
                t3 = t2 * t,
                t4 = t3 * t;
            return p0 * ts4 + 4 * p1 * t * ts3 + 6 * p2 * t2 * ts2 + 4 * p3 * t3 * ts + t4 * p4;
        }//end of QuarticBezier

        // 1.d - Quadratic Bezier 3D
        public static Eng_Vector3D QuadraticBezier(double t, Eng_Vector3D p0, Eng_Vector3D p1, Eng_Vector3D p2)
        {
            double ts = 1 - t,
                ts2 = ts * ts,
                t2 = t * t;
            return p0 * ts2 + 2 * p1 * t * ts + p2 * t2;
        }//eom

        // 1.e - Cubic Bezier 3D
        public static Eng_Vector3D CubicBezier(
            double t, Eng_Vector3D p0, Eng_Vector3D p1, Eng_Vector3D p2, Eng_Vector3D p3)
        {
             double ts = 1 - t,
                ts2 = ts * ts,
                ts3 = ts2 * ts,
                t2 = t * t,
                t3 = t2 * t;
            return p0 * ts3 + 3 * t * p1 * ts2 + 3 * p2 * t2 * ts + p3 * t3;
        }//end of CubicBezier

        // 1.f - Quartic Bezier 3D
        public static Eng_Vector3D QuarticBezier(double t, Eng_Vector3D p0, Eng_Vector3D p1, Eng_Vector3D p2, Eng_Vector3D p3, Eng_Vector3D p4)
        {
            double ts = 1 - t,
                ts2 = ts * ts,
                ts3 = ts2 * ts,
                ts4 = ts3 * ts,
                t2 = t * t,
                t3 = t2 * t,
                t4 = t3 * t;
            return p0 * ts4 + 4 * p1 * t * ts3 + 6 * p2 * t2 * ts2 + 4 * p3 * t3 * ts + t4 * p4;
        }//end of QuarticBezier
        #endregion

        #region Lab 4 - Part 2: Catmul-Rom Splines
        // 1.a - 2D Spline
        public static Eng_Vector2D CatmullRomSpline(double t, Eng_Vector2D p0, Eng_Vector2D p1, Eng_Vector2D p2, Eng_Vector2D p3)
        {
            double t2 = t * t,
                t3 = t2 * t;
            return 0.5 * ((2 * p1) + (p2 - p0) * t + (2 * p0 - 5 * p1 + 4 * p2 - p3) * t2 + (p3 - p0 + 3 * p1 - 3 * p2) * t3);
        }//end of CatmullRomSpline

        // 1.b - 3D Spline
        public static Eng_Vector3D CatmullRomSpline(
            double t, Eng_Vector3D p0, Eng_Vector3D p1, Eng_Vector3D p2, Eng_Vector3D p3)
        {
            double t2 = t * t,
                t3 = t2 * t;
            return 0.5 * ((2 * p1) + (p2 - p0) * t + (2 * p0 - 5 * p1 + 4 * p2 - p3) * t2 + (p3 - p0 + 3 * p1 - 3 * p2) * t3);
        }//end of CatmullRomSpline
        #endregion
    }//eoc
}//eon

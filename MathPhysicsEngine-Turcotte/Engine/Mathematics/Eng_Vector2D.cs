using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Mathematics
{
    public class Eng_Vector2D
    {
        //1.a - Properties (component form of a vector).

        public double X { get; set; }
        public double Y { get; set; }

        //1.b - Empty Constructor.

        public Eng_Vector2D()
        {
            X = 0;
            Y = 0;
        }

        //1.c - Non-empty constructor.

        public Eng_Vector2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        #region Class Methods
        // 2.a - Magnitude of a 2D vector.
        public double Magnitude()
        {
            double magnitude;

            magnitude = Math.Pow(X, 2) + Math.Pow(Y, 2);
            magnitude = Math.Sqrt(magnitude);

            return magnitude;   
		}//end of Magnitude

        //2.b - The Dot Product of two 2D vectors.
        public double DotProduct(Eng_Vector2D b)
        {
            double dotProduct;

            dotProduct = X * b.X + Y * b.Y;

            return dotProduct;
		}//end of DotProduct

        //2.c – The angle between two 2D vectors.
        public double AngleBetweenVectors(Eng_Vector2D b)
        {
            double magnitudeA, magnitudeB, dotProduct, degrees;

            magnitudeA = Magnitude();
            magnitudeB = b.Magnitude();

            dotProduct = DotProduct(b);

            degrees = Math.Acos(dotProduct / (magnitudeA * magnitudeB));
            degrees = Functions.RadiansToDegrees(degrees);

            return degrees;
        }//end of AngleBetweenVectors

        //2.d – To Normalize a 2D vector.
        public void Normalize()
        {
            double magnitude;

            magnitude = Magnitude();

            X = X / magnitude;
            Y = Y / magnitude;    
		}//end of Normalize
        #endregion

        #region Overload Operators
        #region Complier Warning Fix
        // the following two methods are to remove the CS0660 and CS0661 compiler warnings
        public override bool Equals(object obj)
        {
            return true;
        }//eom
		
        public override int GetHashCode()
        {
            return 0;
        }//eom
        #endregion

        //3.a - Adding two 2D vectors.

        public static Eng_Vector2D operator + (Eng_Vector2D a, Eng_Vector2D b)
        {
			double sumX, sumY;

			sumX = a.X + b.X;
			sumY = a.Y + b.Y;

			return new Eng_Vector2D(sumX, sumY);
		}
		//3.b - Subtracting two 2D vectors.

		public static Eng_Vector2D operator -(Eng_Vector2D a, Eng_Vector2D b)
        {
			double sumX, sumY;

			sumX = a.X - b.X;
			sumY = a.Y - b.Y;

			return new Eng_Vector2D(sumX, sumY);
		}

		//3.c - Multiplying a 2D vector by a scalar.

		public Eng_Vector2D Multiplying2DVectorByScalar(Eng_Vector2D Vector, double scalar)
        {
            double scalarMultiX, scalarMultiY;

            scalarMultiX = Vector.X * scalar;
            scalarMultiY = Vector.Y * scalar;

            return new Eng_Vector2D(scalarMultiX, scalarMultiY);
        }

		public static Eng_Vector2D operator *(Eng_Vector2D Vector, double scalar)
        {
			double scalarMultiX, scalarMultiY;

			scalarMultiX = Vector.X * scalar;
			scalarMultiY = Vector.Y * scalar;

			return new Eng_Vector2D(scalarMultiX, scalarMultiY);
		}

		public static Eng_Vector2D operator *(double scalar, Eng_Vector2D Vector)
		{
			double scalarMultiX, scalarMultiY;

			scalarMultiX = Vector.X * scalar;
			scalarMultiY = Vector.Y * scalar;

			return new Eng_Vector2D(scalarMultiX, scalarMultiY);
		}
		//3.d - Equality of two 2D vectors.

		public static bool operator ==(Eng_Vector2D a,Eng_Vector2D b)
        {
			return a.X == b.X && a.Y == b.Y;
		}

		//3.e - Inequality of two 2D vectors

		public static bool operator !=(Eng_Vector2D a, Eng_Vector2D b)
        {
			return a.X != b.X || a.Y != b.Y;
		}

		#endregion
	}//eoc
}//eom

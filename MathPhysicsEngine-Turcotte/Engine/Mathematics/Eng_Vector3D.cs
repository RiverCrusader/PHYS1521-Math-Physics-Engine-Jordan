using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Mathematics
{
    public class Eng_Vector3D
    {
        //1.a - Properties.

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        //1.b - Empty Constructor.

        public Eng_Vector3D()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        //1.c - Non-empty Constructor.

        public Eng_Vector3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        #region Class Methods
        //2.a - Magnitude of a 3D vector
        public double Magnitude()
        {
            double magnitude;

            magnitude = Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z,2);
            magnitude = Math.Sqrt(magnitude);

            return magnitude;
        }//end of Magnitude
		
        //2.b - Calculate the Dot Product of two 3D vectors.
        public double DotProduct(Eng_Vector3D b)
        {
            double dotProduct;

            dotProduct = X * b.X + Y * b.Y + Z * b.Z;

            return dotProduct;
        }//end of DotProduct
		
        //2.c – Calculate the angle between two 3D vectors.
        public double AngleBetweenVectors(Eng_Vector3D b)
        {
            double magnitudeA, magnitudeB, dotProduct, degrees;

            magnitudeA = Magnitude();
            magnitudeB = b.Magnitude();

            dotProduct = DotProduct(b);

            degrees = Math.Acos(dotProduct / (magnitudeA * magnitudeB));
            degrees = Functions.RadiansToDegrees(degrees);

            return degrees;
        }//end of AngleBetweenVectors
		
        //2.d – Normalize a 3D vector.
        public void Normalize()
        {
            double magnitude;

            magnitude = Magnitude();

            X = X / magnitude;
            Y = Y / magnitude;
            Z = Z / magnitude;
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

		//3.a - Adding two 3D Vectors.

		public static Eng_Vector3D operator +(Eng_Vector3D a, Eng_Vector3D b)
		{
			double sumX, sumY, sumZ;

			sumX = a.X + b.X;
			sumY = a.Y + b.Y;
			sumZ = a.Z + b.Z;

			return new Eng_Vector3D(sumX, sumY,sumZ);
		}

		//3.b - Subtracting two 3D Vectors.

		public static Eng_Vector3D operator -(Eng_Vector3D a, Eng_Vector3D b)
        {
			double sumX, sumY, sumZ;

			sumX = a.X - b.X;
			sumY = a.Y - b.Y;
			sumZ = a.Z - b.Z;

			return new Eng_Vector3D(sumX, sumY, sumZ);
		}

		//3.c - Multiplying a 3D vector by a scalar.

		public static Eng_Vector3D operator *(Eng_Vector3D Vector, double scalar)
        {
			double scalarMultiX, scalarMultiY, scalarMultiZ;

			scalarMultiX = Vector.X * scalar;
			scalarMultiY = Vector.Y * scalar;
			scalarMultiZ = Vector.Z * scalar;

			return new Eng_Vector3D(scalarMultiX, scalarMultiY, scalarMultiZ);
		}
		//3.d - Equality of two 3D vectors

		public static bool operator ==(Eng_Vector3D a, Eng_Vector3D b)
		{
			return a.X == b.X && a.Y == b.Y && a.Z == b.Z;
		}

		//3.e - Inequality of two 3D vectors

		public static bool operator !=(Eng_Vector3D a, Eng_Vector3D b)
		{
			return a.X != b.X || a.Y != b.Y || a.Z != b.Z;
		}

        //3.f - Calculate the Cross Product of two 3D vectors.

        public static Eng_Vector3D operator *(Eng_Vector3D a, Eng_Vector3D b)
        {
            double crossX, crossY, crossZ;

            crossX = a.Y * b.Z - a.Z * b.Y;
            crossY = a.Z * b.X - a.X * b.Z;
            crossZ = a.X * b.Y - a.Y * b.X;

            return new Eng_Vector3D(crossX, crossY, crossZ);
        }

        #endregion

        #region Lab 2
        //5.a - Overload operator to multiply a vector by a 3x3 matrix

        public static Eng_Vector3D operator *(Eng_Matrix3x3 m, Eng_Vector3D v)
        {
            //return xyz in new eng vector 

            return new Eng_Vector3D((v.X * m.M11 + v.Y * m.M12 + v.Z * m.M13),
                                    (v.X * m.M21 + v.Y * m.M22 + v.Z * m.M23),
                                    (v.X * m.M31 + v.Y * m.M32 + v.Z * m.M33));
        }
        #endregion
    }//eoc
}//eon

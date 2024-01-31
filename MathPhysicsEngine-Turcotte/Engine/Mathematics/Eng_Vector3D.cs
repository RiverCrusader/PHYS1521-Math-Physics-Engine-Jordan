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
            magnitude = Math.Round(magnitude, 4);

            return magnitude;
        }//end of Magnitude
		
        //2.b - Calculate the Dot Product of two 3D vectors.
        public double DotProduct(Eng_Vector3D b)
        {
            double dotProduct;

            dotProduct = X * b.X + Y * b.Y + Z * b.Z;
            Math.Round(dotProduct, 4);

            return dotProduct;
        }//end of DotProduct
		
        //2.c – Calculate the angle between two 3D vectors.
        public double AngleBetweenVectors(Eng_Vector3D b)
        {
            double magnitudeA, magnitudeB, dotProduct, degrees;

            magnitudeA = Magnitude();
            magnitudeB = Magnitude();

            dotProduct = DotProduct(b);

            degrees = Math.Acos(dotProduct / (magnitudeA * magnitudeB));
            degrees = Math.Round(degrees, 4);

            return degrees;
        }//end of AngleBetweenVectors
		
        //2.d – Normalize a 3D vector.
        public void Normalize()
        {
            double magnitude, normalX, normalY, normalZ;

            magnitude = Magnitude();

            normalX = X / magnitude;
            normalY = Y / magnitude;
            normalZ = Z / magnitude;
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
		
		//3.b - Subtracting two 3D Vectors.
        
		//3.c - Multiplying a 3D vector by a scalar.
		
		//3.d - Equality of two 3D vectors
		
		//3.e - Inequality of two 3D vectors
        
		//3.f - Calculate the Cross Product of two 3D vectors.
        
        #endregion
    }//eoc
}//eon

using System;
using System.Collections.Generic;
using System.Linq;
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

        //1.c - Non-empty constructor.

        #region Class Methods
        // 2.a - Magnitude of a 2D vector.
        public double Magnitude()
        {
			
		}//end of Magnitude

        //2.b - The Dot Product of two 2D vectors.
        public double DotProduct(Eng_Vector2D b)
        {
			
		}//end of DotProduct

        //2.c – The angle between two 2D vectors.
        public double AngleBetweenVectors(Eng_Vector2D b)
        {
			
		}//end of AngleBetweenVectors

        //2.d – To Normalize a 2D vector.
        public void Normalize()
        {
			
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
		
		//3.b - Subtracting two 2D vectors.
       
        //3.c - Multiplying a 2D vector by a scalar.
       
		//3.d - Equality of two 2D vectors.
		 
		//3.e - Inequality of two 2D vectors
       
        #endregion
    }//eoc
}//eom

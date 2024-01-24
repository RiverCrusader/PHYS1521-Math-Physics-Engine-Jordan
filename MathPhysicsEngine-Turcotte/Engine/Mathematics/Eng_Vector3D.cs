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
       
        //1.b - Empty Constructor.
		
		//1.c - Non-empty Constructor.
        
        #region Class Methods
        //2.a - Magnitude of a 3D vector
        public double Magnitude()
        {
			
		}//end of Magnitude
		
        //2.b - Calculate the Dot Product of two 3D vectors.
        public double DotProduct(Eng_Vector3D b)
        {
			
		}//end of DotProduct
		
        //2.c – Calculate the angle between two 3D vectors.
        public double AngleBetweenVectors(Eng_Vector3D b)
        {
			
		}//end of AngleBetweenVectors
		
        //2.d – Normalize a 3D vector.
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

        //3.a - Adding two 3D Vectors.
		
		//3.b - Subtracting two 3D Vectors.
        
		//3.c - Multiplying a 3D vector by a scalar.
		
		//3.d - Equality of two 3D vectors
		
		//3.e - Inequality of two 3D vectors
        
		//3.f - Calculate the Cross Product of two 3D vectors.
        
        #endregion
    }//eoc
}//eon

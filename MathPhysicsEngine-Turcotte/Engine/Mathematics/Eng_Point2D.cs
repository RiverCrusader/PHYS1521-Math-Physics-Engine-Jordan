using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Mathematics
{
    public class Eng_Point2D
    {
        // Properties
        public double X { get; set; }
        public double Y { get; set; }

        // Empty Constructor
        public Eng_Point2D()
        {
            X = 0;
            Y = 0;
        }//eom

        // Greedy Constructor
        public Eng_Point2D(double x, double y)
        {
            X = x;
            Y = y;
        }//eom

		#region Class Methods
		public double SegmentLength(Eng_Point2D b)
		{
			return Math.Sqrt(Math.Pow(b.X - X, 2) + Math.Pow(b.Y - Y, 2));
		}//eom

		public Eng_Point2D MidPoint(Eng_Point2D b)
		{
			return new Eng_Point2D(0.5 * (X + b.X), 0.5 * (Y + b.Y));
		}//eom
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
		// the == and != must both be coded or you get a compile error
		public static bool operator ==(Eng_Point2D a, Eng_Point2D b)
		{
			return a.X == b.X && a.Y == b.Y;
		}//eom

		public static bool operator !=(Eng_Point2D a, Eng_Point2D b)
		{
			return a.X != b.X || a.Y != b.Y;
		}//eom

		public static Eng_Point2D operator *(double s, Eng_Point2D p)
		{
			return new Eng_Point2D(s * p.X, s * p.Y);
		}//eom
		#endregion
	}//eoc
}//eon

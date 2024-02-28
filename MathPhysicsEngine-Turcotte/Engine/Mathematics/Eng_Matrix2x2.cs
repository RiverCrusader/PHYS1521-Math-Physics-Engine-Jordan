using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Mathematics
{
    public class Eng_Matrix2x2
    {
        public double M11 { get; set; }
        public double M12 { get; set; }
        public double M21 { get; set; }
		public double M22 { get; set; }
		
        public Eng_Matrix2x2() {
            M11 = 0;
            M12 = 0;
            M21 = 0;
            M22 = 0;
        }//eom

        public Eng_Matrix2x2(double m11, double m12, double m21, double m22)
        {
            M11 = m11;
            M12 = m12;
            M21 = m21;
            M22 = m22;
        }//eom

        public Eng_Matrix2x2(Eng_Vector2D v, Eng_Vector2D q)
        {
            M11 = v.X;
            M12 = q.X;
            M21 = v.Y;
            M22 = q.Y;
        }//eom

        #region Public Methods
        public double Determinant()
        {
            return M11 * M22 - M12 * M21;
        }//end of Determinant

        #endregion
    }//eoc
}//eon

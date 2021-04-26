using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcClass
{
    public class Calculations
    {
        public static long Add(long a, long b)
        {
            return a + b;
        }
        public static long Sub(long a, long b)
        {
            return a - b;
        }
        public static long Mult(long a, long b)
        {
            return a * b;
        }
        public static long Div(long a, long b)
        {
            if (b != 0)
            {
                return a/b;
            }
            else
            {
                throw new DivideByZeroException();
            }
        }
        public static long Mod(long a, long b)
        {
            return a % b;
        }

        public static long ABS(long a)
        {
            return +a;
        }
        public static long IABS(long a)
        {
            return -a;
        } 
    }
}

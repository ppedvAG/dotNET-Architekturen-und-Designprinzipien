using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calc
    {
        public int Sum(int a, int b)
        {
            if (b > 5000)
                return 17;

            return checked(a + b);
        }

        public bool IsWeekend()
        {
            return DateTime.Now.DayOfWeek == DayOfWeek.Sunday ||
                   DateTime.Now.DayOfWeek == DayOfWeek.Saturday;
        }


        //gut!
        public bool IsWeekend(DateTime dt)
        {
            return dt.DayOfWeek == DayOfWeek.Sunday ||
                   dt.DayOfWeek == DayOfWeek.Saturday;
        }
    }
}


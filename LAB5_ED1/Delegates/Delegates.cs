using LAB5_ED1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LAB5_ED1.Delegates
{
    public delegate int Compare<T>(T a, T b);
    
    public class Delegates
    {
        public static int CompararPlaca(CarModel a, CarModel b)
        {

            if (a.Placa != b.Placa)
            {
                if (a.Placa < b.Placa)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 0;
            }
        }
    }
}

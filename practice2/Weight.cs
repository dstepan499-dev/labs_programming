using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac2
{
    public struct Weight
    {
        public double ValueKg { get; set; }

        public Weight(double kg)
        {
            ValueKg = kg;
        }

        public override string ToString()
        {
            return $"{ValueKg:F2} кг";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auti
{
    public partial class Car
    {
        public double TotalPrice;

        public double MyProperty
        {
            get { return TotalPrice = CalculateTotalPrice(); }
            set { TotalPrice = value; }
        }


        public double CalculateTotalPrice()
        {
            if (this.Power <= 100)
            {
                TotalPrice = this.Price * 1.1;
            }
            else
            {
                TotalPrice = this.Price * 1.25;
            }
            return TotalPrice;
        }
    }
}

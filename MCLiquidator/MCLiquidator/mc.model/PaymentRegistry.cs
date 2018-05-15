using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCLiquidator.mc.model
{
    public class PaymentRegistry
    {
        public string Identifier { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }
        
        public double IPCRate { get; set; }

        public double DFTRate { get; set; }

        public double Fee { get; set; }

        public double Total { get; set; }

        public PaymentRegistry(string identifier, int month, int year, double iPCRate, double dFTRate, double fee, double total)
        {
            Identifier = identifier;
            Month = month;
            Year = year;
            IPCRate = iPCRate;
            DFTRate = dFTRate;
            Fee = fee;
            Total = total;
        }
    }
}

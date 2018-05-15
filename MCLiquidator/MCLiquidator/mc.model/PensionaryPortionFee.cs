using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCLiquidator.mc.model
{
    public class PensionaryPortionFee
    {
        public string Identifier { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double InitialFee { get; set; }
    }
}

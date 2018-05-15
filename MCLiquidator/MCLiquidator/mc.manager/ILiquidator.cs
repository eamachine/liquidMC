using MCLiquidator.mc.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCLiquidator.mc.manager
{
    public interface ILiquidator
    {
        IEnumerable<PaymentRegistry> ExecuteLiquidator(PensionaryPortionFee fee, Dictionary<int, double[]> DTFs, Dictionary<int, double[]> IPCs);
    }
}

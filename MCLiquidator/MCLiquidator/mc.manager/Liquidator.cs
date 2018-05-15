using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCLiquidator.mc.model;

namespace MCLiquidator.mc.manager
{
    public class Liquidator : ILiquidator
    {
        public IEnumerable<PaymentRegistry> ExecuteLiquidator(PensionaryPortionFee fee, Dictionary<int,double[]> DTFs, Dictionary<int, double[]> IPCs)
        {
            var paymentRegistries = new List<PaymentRegistry>();

            //initial year
            for (var j = fee.StartDate.Month; j <= 12; j++)
            {
                paymentRegistries.Add(new PaymentRegistry(fee.Identifier
                    , j
                    , fee.StartDate.Year
                    , IPCs[fee.StartDate.Year][j-1]
                    , DTFs[fee.StartDate.Year][j-1]
                    , fee.InitialFee
                    , DTFs[fee.StartDate.Year][j-1]*fee.InitialFee));
            }

            var IPCfactorial = IPCs[fee.StartDate.Year][11];

            //years of application
            for (var i = fee.StartDate.Year + 1 ; i <= fee.EndDate.Year - 1 ; i++)
            {
                for (var j = 1; j <= 12; j++)
                {
                    paymentRegistries.Add(new PaymentRegistry(fee.Identifier
                    , j
                    , i
                    , IPCs[i][j-1]
                    , DTFs[i][j-1]
                    , fee.InitialFee
                    , DTFs[i][j-1] * IPCfactorial * fee.InitialFee));
                }

                IPCfactorial = IPCfactorial * IPCs[i][11];
            }

            //last year
            for (var j = 1; j <= fee.EndDate.Month; j++)
            {
                paymentRegistries.Add(new PaymentRegistry(fee.Identifier
                    , j
                    , fee.EndDate.Year
                    , IPCs[fee.EndDate.Year][j - 1]
                    , DTFs[fee.EndDate.Year][j - 1]
                    , fee.InitialFee
                    , DTFs[fee.EndDate.Year][j - 1] * IPCfactorial * fee.InitialFee));
            }

            return paymentRegistries;
        }
    }
}

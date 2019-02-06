using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Stateless1
{
    public class CalculatorService : MyServiceBehavior, ICalculatorService
    {
        public Task<double> Add(double a, double b) => Task.FromResult(a + b);

        public Task Echo(string Msg)
        {
            var Callback = OperationContext.Current.GetCallbackChannel<ICalculatorCallbackService>();

            return Callback.EchoResult($"Echo for {Msg}");
        }
    }
}

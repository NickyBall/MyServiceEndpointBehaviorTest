using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    [ServiceContract]
    public interface ICalculatorCallbackService
    {
        [OperationContract(IsOneWay = true)]
        Task EchoResult(string Msg);
    }
}

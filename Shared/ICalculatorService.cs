﻿using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    [ServiceContract(CallbackContract = typeof(ICalculatorCallbackService))]
    public interface ICalculatorService
    {
        [OperationContract(IsOneWay = false)]
        Task<double> Add(double a, double b);
        [OperationContract(IsOneWay = true)]
        Task Echo(string Msg);
    }
}

﻿using System;
using System.Collections.Generic;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;

namespace Shared
{
    public class MyEndpointBehavior : IEndpointBehavior
    {
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.ClientMessageInspectors.Add(new MyClientMessageInspector());
            clientRuntime.CallbackDispatchRuntime.MessageInspectors.Add(new MyDispatchMessageInspector());
            foreach (OperationDescription operationDescription in endpoint.Contract.Operations)
            {
                DataContractSerializerOperationBehavior dataContractSerializerOperationBehavior = operationDescription.Behaviors.Find<DataContractSerializerOperationBehavior>();
                if (dataContractSerializerOperationBehavior != null)
                {
                    operationDescription.Behaviors.Remove(dataContractSerializerOperationBehavior);

                    MyOperationBehavior myOperationBehavior = new MyOperationBehavior(operationDescription)
                    {
                        MaxItemsInObjectGraph = dataContractSerializerOperationBehavior.MaxItemsInObjectGraph
                    };

                    operationDescription.Behaviors.Add(myOperationBehavior);
                }
            }
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            foreach (OperationDescription operationDescription in endpoint.Contract.Operations)
            {
                DataContractSerializerOperationBehavior dataContractSerializerOperationBehavior = operationDescription.Behaviors.Find<DataContractSerializerOperationBehavior>();
                if (dataContractSerializerOperationBehavior != null)
                {
                    operationDescription.Behaviors.Remove(dataContractSerializerOperationBehavior);

                    MyOperationBehavior myOperationBehavior = new MyOperationBehavior(operationDescription)
                    {
                        MaxItemsInObjectGraph = dataContractSerializerOperationBehavior.MaxItemsInObjectGraph
                    };

                    operationDescription.Behaviors.Add(myOperationBehavior);
                }
            }
        }

        public void Validate(ServiceEndpoint endpoint)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel.Description;
using System.Text;
using System.Xml;

namespace Shared
{
    public class MyOperationBehavior : DataContractSerializerOperationBehavior
    {
        public MyOperationBehavior(OperationDescription operation) : base(operation)
        {
        }
        
         
        public override XmlObjectSerializer CreateSerializer(Type type, XmlDictionaryString name, XmlDictionaryString ns, IList<Type> knownTypes)
        {
            return new MyObjectSerializer();
        }

        public override XmlObjectSerializer CreateSerializer(Type type, string name, string ns, IList<Type> knownTypes)
        {
            return new MyObjectSerializer();
        }
    }
}

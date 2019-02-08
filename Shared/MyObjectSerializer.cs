using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace Shared
{
    public class MyObjectSerializer : XmlObjectSerializer
    {
        public override bool IsStartObject(XmlDictionaryReader reader)
        {
            throw new NotImplementedException();
            return true;
        }

        public override object ReadObject(XmlDictionaryReader reader, bool verifyObjectName)
        {
            throw new NotImplementedException();
            return null;
        }

        public override void WriteEndObject(XmlDictionaryWriter writer)
        {
            throw new NotImplementedException();
        }

        public override void WriteObjectContent(XmlDictionaryWriter writer, object graph)
        {
            throw new NotImplementedException();
        }

        public override void WriteStartObject(XmlDictionaryWriter writer, object graph)
        {
            throw new NotImplementedException();
        }
    }
}

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
            return true;
        }

        public override object ReadObject(XmlDictionaryReader reader, bool verifyObjectName)
        {
            return null;
        }

        public override void WriteEndObject(XmlDictionaryWriter writer)
        {
            
        }

        public override void WriteObjectContent(XmlDictionaryWriter writer, object graph)
        {
            
        }

        public override void WriteStartObject(XmlDictionaryWriter writer, object graph)
        {
            
        }
    }
}

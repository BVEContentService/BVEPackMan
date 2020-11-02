using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Zbx1425.BveCSRegistry.Utilities {

    internal interface IXmlDeserializationCallback {
        void OnXmlDeserialization(object param);
    }

    internal class ParamXmlSerializer : XmlSerializer {

        public object Param { get; set; }

        public ParamXmlSerializer(object param, Type type) : base(type) {
            Param = param;
        }

        public new object Deserialize(TextReader reader) {
            var result = base.Deserialize(reader);

            var deserializedCallback = result as IXmlDeserializationCallback;
            if (deserializedCallback != null) {
                deserializedCallback.OnXmlDeserialization(Param);
            }

            return result;
        }
    }
}

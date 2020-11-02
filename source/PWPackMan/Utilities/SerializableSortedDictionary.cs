using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Zbx1425.PWPackMan.Utilities {
	
	// https://stackoverflow.com/a/1728996/12845970
	// (C) osman pirci CC BY-SA 3.0

	[Serializable]
	public class SerializableSortedDictionary<TKey, TValue>
    : SortedDictionary<TKey, TValue>, IXmlSerializable {
		public SerializableSortedDictionary() {
		}
		public SerializableSortedDictionary(IDictionary<TKey, TValue> dictionary)
			: base(dictionary) {
		}
		public SerializableSortedDictionary(IDictionary<TKey, TValue> dictionary, IComparer<TKey> comparer)
			: base(dictionary, comparer) {
		}
		public SerializableSortedDictionary(IComparer<TKey> comparer)
			: base(comparer) {
		}

		#region IXmlSerializable Members
		public System.Xml.Schema.XmlSchema GetSchema() {
			return null;
		}

		public void ReadXml(System.Xml.XmlReader reader) {
			XmlSerializer keySerializer = new XmlSerializer(typeof(TKey));
			XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));

			bool wasEmpty = reader.IsEmptyElement;
			reader.Read();

			if (wasEmpty)
				return;

			while (reader.NodeType != System.Xml.XmlNodeType.EndElement) {
				reader.ReadStartElement("item");

				reader.ReadStartElement("key");
				TKey key = (TKey)keySerializer.Deserialize(reader);
				reader.ReadEndElement();

				reader.ReadStartElement("value");
				TValue value = (TValue)valueSerializer.Deserialize(reader);
				reader.ReadEndElement();

				this.Add(key, value);

				reader.ReadEndElement();
				reader.MoveToContent();
			}
			reader.ReadEndElement();
		}

		public void WriteXml(System.Xml.XmlWriter writer) {
			XmlSerializer keySerializer = new XmlSerializer(typeof(TKey));
			XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));

			foreach (TKey key in this.Keys) {
				writer.WriteStartElement("item");

				writer.WriteStartElement("key");
				keySerializer.Serialize(writer, key);
				writer.WriteEndElement();

				writer.WriteStartElement("value");
				TValue value = this[key];
				valueSerializer.Serialize(writer, value);
				writer.WriteEndElement();

				writer.WriteEndElement();
			}
		}
		#endregion
	}
}

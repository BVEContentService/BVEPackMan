using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Zbx1425.PWPackMan.Models;
using Zbx1425.BveCSRegistry.Utilities;

namespace Zbx1425.BveCSRegistry.Models {
	
	[Serializable]
	public class Package : RemotePackageInfo, IXmlDeserializationCallback {
		
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }

        public string Identifier { get; set; }
        public string GUID { get; set; }
        
		public TripleString Name { get; set; }

		public Developer Uploader { get; set; }
		public Developer Author { get; set; }

		public string Homepage { get; set; }
		public bool ForcePopup { get; set; }
		public string Thumbnail { get; set; }
		public string ThumbnailLQ { get; set; }

        public File[] Files { get; set; }

        public void OnXmlDeserialization(object param) {
            PlainName = Name.ToString();
            if (Author != null) AuthorName = Author.Name.ToString();
            if (string.IsNullOrEmpty(GUID)) {
                ID = new Identifier(Identifier);
            } else {
                ID = new Identifier(Identifier, Guid.Parse(GUID));
            }
            if (Files != null) {
                AvailableVersions.Clear();
                foreach (var file in Files) {
                    if (file.Platform == param.ToString() && (!file.NeedValidation || file.Validated)) {
                        AvailableVersions.Add(file.Version, file.FetchURL);
                    }
                }
            }
        }
    }
}

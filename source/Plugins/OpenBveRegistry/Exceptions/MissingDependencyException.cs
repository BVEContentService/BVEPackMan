
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Zbx1425.PWPackMan;
using Zbx1425.PWPackMan.Models;
using Zbx1425.PWPackMan.Utilities;
using OpenBveApi.Packages;

namespace Zbx1425.OpenBveRegistry.Exceptions {
	
	public class MissingDependencyException : Exception, ISerializable {
		public MissingDependencyException() {
		}

		public MissingDependencyException(string message)
			: base(message) {
		}

		public MissingDependencyException(string message, Exception innerException)
			: base(message, innerException) {
		}

		// This constructor is needed for serialization.
		protected MissingDependencyException(SerializationInfo info, StreamingContext context)
			: base(info, context) {
		}
		
		public MissingDependencyException(Context ctx, IEnumerable<Package> blame) : base(GenerateMessage(ctx, blame)) { }
		
		private static string GenerateMessage(Context ctx, IEnumerable<Package> blame) {
			return ctx.Translation.Translate("bpmplugin_openbve_exception_missingdependency", 
				string.Join(Environment.NewLine, blame.Select(pack => 
                    new Identifier(pack.Name, new Guid(pack.GUID)).ToString() +
				new VersionRange(pack.MinimumVersion, pack.MaximumVersion).ToString()
				))
			);
		}
	}
}
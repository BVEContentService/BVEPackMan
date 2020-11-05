
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Zbx1425.PWPackMan;
using Zbx1425.PWPackMan.Models;
using OpenBveApi.Packages;

namespace Zbx1425.OpenBveRegistry.Exceptions {
	
	public class BrokenDependencyException : Exception, ISerializable {
		public BrokenDependencyException() {
		}

		public BrokenDependencyException(string message)
			: base(message) {
		}

		public BrokenDependencyException(string message, Exception innerException)
			: base(message, innerException) {
		}

		// This constructor is needed for serialization.
		protected BrokenDependencyException(SerializationInfo info, StreamingContext context)
			: base(info, context) {
		}
		
		public BrokenDependencyException(Context ctx, IEnumerable<Package> blame) : base(GenerateMessage(ctx, blame)) { }
		
		private static string GenerateMessage(Context ctx, IEnumerable<Package> blame) {
			return ctx.Translation.Translate("bpmplugin_openbve_exception_brokendependency", 
				string.Join(Environment.NewLine, blame.Select(pack => 
                    new Identifier(pack.Name, new Guid(pack.GUID)).ToString() +
				pack.PackageVersion.ToString()
				))
			);
		}
	}
}
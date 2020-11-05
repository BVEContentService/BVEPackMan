
using System;
using System.Runtime.Serialization;
using Zbx1425.PWPackMan;

namespace Zbx1425.OpenBveRegistry.Exceptions {
	
	public class MalformedPackageException : Exception, ISerializable {
		public MalformedPackageException() {
		}

		public MalformedPackageException(string message)
			: base(message) {
		}

		public MalformedPackageException(string message, Exception innerException)
			: base(message, innerException) {
		}

		// This constructor is needed for serialization.
		protected MalformedPackageException(SerializationInfo info, StreamingContext context)
			: base(info, context) {
		}
		
		public MalformedPackageException(Context ctx) : base(GenerateMessage(ctx)) { }
		
		private static string GenerateMessage(Context ctx) {
			return ctx.Translation.Translate("bpmplugin_openbve_exception_badpackage");
		}
	}
}
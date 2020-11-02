using System;
using System.Runtime.Serialization;
using Zbx1425.PWPackMan.Models;

namespace Zbx1425.PWPackMan.Exceptions {
	
	public class PackageNotFoundException : Exception, ISerializable {
		public PackageNotFoundException() { }

	 	public PackageNotFoundException(string message) : base(message) { }

		public PackageNotFoundException(string message, Exception innerException) : base(message, innerException) { }

		protected PackageNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
		
		public PackageNotFoundException(Context ctx, Identifier id) : base(GenerateMessage(ctx, id)) { }
		
		private static string GenerateMessage(Context ctx, Identifier id) {
			return ctx.Translation.Translate("bpmcore_exception_notfound", id.ToString());
		}
	}
}
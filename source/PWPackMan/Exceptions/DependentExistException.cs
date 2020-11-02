using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Zbx1425.PWPackMan.Exceptions {
	
	public class DependentExistException : Exception, ISerializable {
		public DependentExistException() { }

		public DependentExistException(string message) : base(message) { }

		public DependentExistException(string message, Exception innerException) : base(message, innerException) { }

		// This constructor is needed for serialization.
		protected DependentExistException(SerializationInfo info, StreamingContext context) : base(info, context) { }
		
		public DependentExistException(Context ctx, List<string> blame) : base(GenerateMessage(ctx, blame)) { }
			
		private static string GenerateMessage(Context ctx, List<string> blame) {
			var sb = new StringBuilder();
			sb.AppendLine(ctx.Translation.Translate("bpmcore_exception_uninstalldependency"));
			sb.AppendLine(ctx.Translation.Translate("bpmcore_exception_blame"));
			foreach (var item in blame) {
				sb.AppendLine(item);
			}
			return sb.ToString();
		}
	}
}
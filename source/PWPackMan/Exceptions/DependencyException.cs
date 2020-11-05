using System;
using System.Runtime.Serialization;
using Zbx1425.PWPackMan.Models;
using Zbx1425.PWPackMan.Utilities;

namespace Zbx1425.PWPackMan.Exceptions {
	
	public class DependencyException : Exception, ISerializable {
		public DependencyException() { }
		
		public DependencyException(string message) : base(message) { }

		public DependencyException(string message, Exception innerException) : base(message, innerException) { }

		protected DependencyException(SerializationInfo info, StreamingContext context) : base(info, context) { }
		
		public DependencyException(Context ctx, string installing, string dependant, Exception innerException) : 
			base(GenerateMessage(ctx, installing, dependant, innerException), innerException) { }
		
		private static string GenerateMessage(Context ctx, string installing, string dependant, Exception innerException) {
			return string.IsNullOrEmpty(dependant) ? 
				ctx.Translation.Translate("bpmcore_exception_dependency1", installing, innerException.Message) : 
				ctx.Translation.Translate("bpmcore_exception_dependency2", installing, dependant, innerException.Message);
		}
	}
}
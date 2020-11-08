using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Zbx1425.PWPackMan.Utilities;

namespace Zbx1425.PWPackMan.Exceptions {
	public class RangeNotSatisfiableException : Exception, ISerializable {
		
		public RangeNotSatisfiableException() {
		}

		public RangeNotSatisfiableException(string message)
			: base(message) {
		}

		public RangeNotSatisfiableException(string message, Exception innerException)
			: base(message, innerException) {
		}

		public RangeNotSatisfiableException(Context ctx, VersionRange finalRange, List<Tuple<VersionRange, string[]>> blame)
			: base(GenerateMessage(ctx, finalRange, blame)) {
		}
		
		// This constructor is needed for serialization.
		protected RangeNotSatisfiableException(SerializationInfo info, StreamingContext context)
			: base(info, context) {
		}
		
		private static string GenerateMessage(Context ctx, VersionRange finalRange, List<Tuple<VersionRange, string[]>> blame) {
			var sb = new StringBuilder();
			if (finalRange.Minimum != null && finalRange.Maximum != null && finalRange.Minimum > finalRange.Maximum) {
				sb.AppendLine(ctx.Translation.Translate("bpmcore_exception_badrange1"));
			} else {
				sb.AppendLine(ctx.Translation.Translate("bpmcore_exception_badrange2"));
			}
			sb.AppendLine(ctx.Translation.Translate("bpmcore_exception_blame"));
			foreach (var item in blame) {
				sb.AppendLine(ctx.Translation.Translate("bpmcore_exception_constraint", item.Item1.ToString(), 
					string.IsNullOrEmpty(item.Item2[0]) ? ctx.Translation.Translate("bpmcore_exception_userconstraint") : item.Item2[0],
					item.Item2.Length > 1 ? "...(" + (item.Item2.Length - 1).ToString() + "+)" : ""));
			}
			return sb.ToString();
		}
	}
}
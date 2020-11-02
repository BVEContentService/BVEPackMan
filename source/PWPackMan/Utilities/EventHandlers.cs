using System;

namespace Zbx1425.PWPackMan.Utilities {
	
	public enum LogLevel {
		Verbose,
		Debug,
		Info,
		Warning
	}
	
	public delegate void LogHandler(LogLevel level, string message);
	
	public delegate void ProgressHandler(long? totalWork, long? finishedWork, double? ratio);
}
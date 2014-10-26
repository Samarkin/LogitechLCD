using System;

namespace Logitech
{
	public class LogitechLCDException : Exception
	{
		public LogitechLCDException()
		{
		}

		public LogitechLCDException(string message) : base(message)
		{
		}

		public LogitechLCDException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
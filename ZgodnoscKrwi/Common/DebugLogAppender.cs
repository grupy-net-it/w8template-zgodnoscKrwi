using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StyleMVVM.DependencyInjection;
using StyleMVVM.Logging;
using StyleMVVM.Utilities;
using Windows.Foundation;

namespace  ZgodnoscKrwi.Common
{
	public class DebugLogAppender : ILogAppender
	{
		[Conditional("DEBUG")]
		public static void RegisterExport(IDependencyInjectionContainer container)
		{
			container.Register<DebugLogAppender>().As<ILogAppender>();
		}

		public IAsyncOperation<bool> Configure()
		{
			return TaskHelper.ReturnTask(true).AsAsyncOperation();
		}

		public void Flush()
		{
			
		}

		public LogLevel LoggingLevel { get; set; }

		public void Log(LogEntry entry)
		{
			string output =
				string.Format("{0:MM/dd/yyyy HH:mm:ss:fff} - {1} {2}: {3}", entry.EventTime.DateTime, entry.Level, entry.Supplemental, entry.Message);


			System.Diagnostics.Debug.WriteLine(output);

			if (entry.Exception != null)
			{
				System.Diagnostics.Debug.WriteLine("Exception: " + entry.Exception);
			}

			if (Debugger.IsAttached && 
				(entry.Level == LogLevel.ERROR || entry.Level == LogLevel.FATAL))
			{
				Debugger.Break();
			}
		}
	}
}

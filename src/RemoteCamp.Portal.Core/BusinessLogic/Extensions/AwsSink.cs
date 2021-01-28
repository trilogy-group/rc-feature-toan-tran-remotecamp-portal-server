using System;
using System.Diagnostics;
using System.IO;
using RemoteCamp.Portal.Core.Infrastructure.AwsLogger;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting;
using AwsLoggerCore = RemoteCamp.Portal.Core.Infrastructure.AwsLogger.AwsLoggerCore;

namespace RemoteCamp.Portal.Core.BusinessLogic.Extensions
{
    /// <summary>
    /// A Serilog sink that can be used with the Serilogger logging library to send messages to AWS.
    /// </summary>
    public class AwsSink : ILogEventSink, IDisposable
    {
        private const string LogType = "SeriLogger";
        private readonly AwsLoggerCore _core;
        private readonly IFormatProvider _iformatDriver;
        private readonly ITextFormatter _textFormatter;
        private bool disposedValue;

        /// <summary>
        /// Default constructor
        /// </summary>
        public AwsSink()
        {
        }

        /// <summary>
        /// Constructor called by AWSLoggerSeriLoggerExtension
        /// </summary>
        public AwsSink(AwsLoggerConfig loggerConfiguration,
            IFormatProvider iFormatProvider = null,
            ITextFormatter textFormatter = null)
        {
            _core = new AwsLoggerCore(loggerConfiguration, LogType);
            _iformatDriver = iFormatProvider;
            _textFormatter = textFormatter;
        }

        public void Emit(LogEvent logEvent)
        {
            var message = RenderLogEvent(logEvent);
            if (_textFormatter == null && logEvent.Exception != null)
            {
                message = string.Concat(
                    message,
                    Environment.NewLine,
                    logEvent.Exception.ToString(),
                    Environment.NewLine);
            }
            else
            {
                message = string.Concat(message, Environment.NewLine);
            }
            _core.AddMessage(message);
        }

        private string RenderLogEvent(LogEvent logEvent)
        {
            if (_iformatDriver == null && _textFormatter != null)
            {
                using (var writer = new StringWriter())
                {
                    _textFormatter.Format(logEvent, writer);
                    writer.Flush();
                    return writer.ToString();
                }
            }
            return logEvent.RenderMessage(_iformatDriver);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    try
                    {
                        _core.Close();
                    }
                    catch (Exception ex)
                    {
                        // .. and as ugly as this is, Dispose() methods shall not throw exceptions
                        Trace.TraceError("Exception suppressed: {0}", ex);
                    }
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}

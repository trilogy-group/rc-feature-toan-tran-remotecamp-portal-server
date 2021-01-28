using System;
using Serilog;
using Serilog.Formatting;
using Serilog.Configuration;
using Microsoft.Extensions.Configuration;
using RemoteCamp.Portal.Core.Infrastructure.AwsLogger;

namespace RemoteCamp.Portal.Core.BusinessLogic.Extensions
{
    /// <summary>
    /// Extensions methods for <see cref="LoggerSinkConfiguration"/> to register <see cref="AwsSink"/>
    /// </summary>
    public static class AwsLoggerSeriLogExtension
    {
        private static readonly string LogGroup = "Serilog:LogGroup";
        private static readonly string AwsAccessKey = "AwsAccessKey";
        private static readonly string AwsSecretKey = "AwsSecretKey";
        private static readonly string Region = "Serilog:Region";

        public static LoggerConfiguration AWSSeriLog(
            this LoggerSinkConfiguration loggerConfiguration,
            IConfiguration configuration,
            IFormatProvider iFormatProvider = null,
            ITextFormatter textFormatter = null)
        {
            var aWSLoggerConfig = new AwsLoggerConfig
            {
                LogGroup = configuration[LogGroup],
                Region = configuration[Region],
                AwsAccessKey = configuration[AwsAccessKey],
                AwsSecretKey = configuration[AwsSecretKey]
            };
            return AWSSeriLog(loggerConfiguration, aWSLoggerConfig, iFormatProvider, textFormatter);
        }

        public static LoggerConfiguration AWSSeriLog(
                  this LoggerSinkConfiguration loggerConfiguration,
                   AwsLoggerConfig configuration = null,
                   IFormatProvider iFormatProvider = null,
                   ITextFormatter textFormatter = null)
        {
            if (loggerConfiguration == null)
            {
                throw new ArgumentNullException(nameof(loggerConfiguration));
            }
            return loggerConfiguration.Sink(new AwsSink(configuration, iFormatProvider, textFormatter));
        }
    }
}

﻿namespace RemoteCamp.Portal.Core.Infrastructure.AwsLogger
{
    /// <summary>
    /// Interface for sending messages to CloudWatch Logs
    /// </summary>
    public interface IAwsLoggerCore
    {
        /// <summary>
        /// Flushes all pending messages
        /// </summary>
        void Flush();

        /// <summary>
        /// Flushes and Closes the background task
        /// </summary>
        void Close();

        /// <summary>
        /// Sends message to CloudWatch Logs
        /// </summary>
        /// <param name="message"></param>
        void AddMessage(string message);

        /// <summary>
        /// Start background task for sending messages to CloudWatch Logs
        /// </summary>
        void StartMonitor();
    }
}

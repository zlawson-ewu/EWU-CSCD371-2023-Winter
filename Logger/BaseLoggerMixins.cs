﻿using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(this BaseLogger logger, string message, params string[] args)
        {
            if (logger is null)
            {
                throw new ArgumentNullException();
            }
            string.Format(message, args);
            logger.Log(LogLevel.Error, message);
        }
        public static void Warning(this BaseLogger logger, string message, params string[] args)
        {
            if (logger is null)
            {
                throw new ArgumentNullException();
            }
            string.Format(message, args);
            logger.Log(LogLevel.Warning, message);
        }
        public static void Information(this BaseLogger logger, string message, params string[] args)
        {
            if (logger is null)
            {
                throw new ArgumentNullException();
            }
            string.Format(message, args);
            logger.Log(LogLevel.Information, message);
        }
        public static void Debug(this BaseLogger logger, string message, params string[] args)
        {
            if (logger is null)
            {
                throw new ArgumentNullException();
            }
            string.Format(message, args);
            logger.Log(LogLevel.Debug, message);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
namespace KusumgarCrossCutting.Logging
{
    public static class Logger
    {
        //This property should be used to write values to file (.txt).
        private static ILog _fileLogger;

        //This property should be used to push information to MSMQ server.
        private static ILog _msmqLogger;

        static Logger()
        {
            // This property reads information from Log4Net.config setting for FileLogger.
            _fileLogger = LogManager.GetLogger("FileLogger");

            // This property reads information from Log4Net.config setting for MSMQLogger.
            _msmqLogger = LogManager.GetLogger("MSMQLogger");

            // Important.
            log4net.Config.XmlConfigurator.Configure();
        }

        #region Methods to write log to a File (.txt)

        public static void Info(object message)
        {
            if (_fileLogger.IsInfoEnabled)
                _fileLogger.Info(message);
        }

        public static void Warn(object message)
        {
            if (_fileLogger.IsWarnEnabled)
                _fileLogger.Warn(message);
        }

        public static void Debug(object message)
        {
            if (_fileLogger.IsDebugEnabled)
                _fileLogger.Debug(message);
        }

        public static void Error(object message)
        {
            if (_fileLogger.IsErrorEnabled)
                _fileLogger.Error(message);
        }

        public static void Fatal(object message)
        {
            if (_fileLogger.IsFatalEnabled)
                _fileLogger.Fatal(message);
        }

        #endregion

        #region Methods to push log to MSMQ server.

        public static void Info(DBLogInfo message)
        {
            if (_msmqLogger.IsInfoEnabled)
                _msmqLogger.Info(message);
        }

        public static void Warn(DBLogInfo message)
        {
            if (_msmqLogger.IsWarnEnabled)
                _msmqLogger.Warn(message);
        }

        public static void Debug(DBLogInfo message)
        {
            if (_msmqLogger.IsDebugEnabled)
                _msmqLogger.Debug(message);
        }

        public static void Error(DBLogInfo message)
        {
            if (_msmqLogger.IsErrorEnabled)
                _msmqLogger.Error(message);
        }

        public static void Fatal(DBLogInfo message)
        {
            if (_msmqLogger.IsFatalEnabled)
                _msmqLogger.Fatal(message);
        }

        #endregion
    }
}

using System;
using Dit.Umb.Mutobo.Constants;
using Dit.Umb.Mutobo.Interfaces;

namespace Dit.Umb.Mutobo.Services
{
    public class LoggingService : BaseService, ILoggingService
    {
        //no Exception
        public void Error(Type type, string message)
        {
            _logger.Error(type, $"{AppConstants.LoggingPrefix + message}");
        }
        public void Info(Type type, string message)
        {
            _logger.Info(type, $"{AppConstants.LoggingPrefix + message}");
        }
        public void Warn(Type type, string message)
        {
            _logger.Warn(type, $"{AppConstants.LoggingPrefix + message}");
        }

        //with Exception
        public void Error(Type type, Exception exception, string message)
        {
            _logger.Error(type, exception, $"{AppConstants.LoggingPrefix + message}");
        }
        public void Warn(Type type, Exception exception, string message)
        {
            _logger.Warn(type, exception, $"{AppConstants.LoggingPrefix + message}");

        }
    }
}

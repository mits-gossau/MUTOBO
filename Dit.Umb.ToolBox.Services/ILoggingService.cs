using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dit.Umb.ToolBox.Services
{
    public interface ILoggingService
    {
        void Warn(Type type, string message);
        void Error(Type type, string message);
        void Info(Type type, string message);

        void Warn(Type type, Exception exception, string message);
        void Error(Type type, Exception exception, string message);
    }
}

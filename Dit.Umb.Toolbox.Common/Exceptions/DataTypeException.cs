using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dit.Umb.ToolBox.Common.Exceptions
{
    public class DataTypeException : ToolboxException
    {
        public DataTypeException(string message) : base(message)
        {
        }
    }
}

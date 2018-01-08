using System;
using System.Collections.Generic;
using System.Text;

namespace LogHelper
{
    [Flags]
    public enum LogLevel
    {
        NONE = 0,
        DEBUG = 1,
        INFO = 2,
        WARNING = 4,
        ERROR = 8,
        EXCEPT = 16,
        CRITICAL = 32
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoli.Model
{
    public class LogEventArgs : EventArgs
    {
        private readonly string _logMessage;
        private readonly decimal _value;

        public LogEventArgs(string logMessage, decimal value)
        {
            _logMessage = logMessage;
            _value = value;
        }

        public decimal Value
        {
            get { return _value; }
        }

        public string LogMessage
        {
            get { return _logMessage; }
        }
    }
}

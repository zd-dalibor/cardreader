using System;

namespace CardReader.Infrastructure.Events
{
    internal class ErrorEventArgs : EventArgs
    {
        public ErrorEventArgs(Exception error)
        {
            Error = error;
        }

        public Exception Error { get; }
    }
}

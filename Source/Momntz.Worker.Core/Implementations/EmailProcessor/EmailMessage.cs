﻿namespace Momntz.Worker.Core.Implementations.EmailProcessor
{
    public class EmailMessage
    {
        public string To { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }
    }
}

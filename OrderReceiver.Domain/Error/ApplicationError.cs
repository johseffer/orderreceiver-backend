using System;
using System.Collections.Generic;
using System.Text;

namespace OrderReceiver.Domain.Error
{
    public class ApplicationError
    {
        public ApplicationError(string message)
        {
            this.Message = message;
        }

        public string Message { get; set; }
    }
}

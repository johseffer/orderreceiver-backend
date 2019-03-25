using System;
using System.Collections.Generic;
using System.Text;

namespace OrderReceiver.Domain.Error
{
    public class ApplicationException : Exception
    {
        public ApplicationException(List<ApplicationError> errors)
        {
            this.Errors = errors;
        }

        public List<ApplicationError> Errors { get; set; }
    }
}

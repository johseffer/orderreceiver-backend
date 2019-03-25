using System;
using System.Collections.Generic;
using System.Text;

namespace OrderReceiver.Definitions.IoC
{
    public class TypeToRegister
    {
        public TypeToRegister(Type type, Type typeInterface)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            if (typeInterface == null)
                throw new ArgumentNullException("typeInterface");

            this.Type = type;
            this.Interface = typeInterface;
        }

        public Type Type { get; set; }
        public Type Interface { get; set; }
    }
}

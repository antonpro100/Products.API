using System;

namespace Products.Core.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message)
            : base(message) { }
    }
}

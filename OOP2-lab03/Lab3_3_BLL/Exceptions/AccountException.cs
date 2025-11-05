using System;

namespace Lab3_3_BLL.Exceptions
{
    public class AccountException : Exception
    {
        public AccountException() { }
        public AccountException(string message) : base(message) { }
    }
}

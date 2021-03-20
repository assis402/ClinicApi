using System;

namespace Presentation.Utils.Messages
{
    public static class ExceptionMessages
    {
        public static string EXC001(string entityName)
        {
            return String.Format("The {} entity cannot be empty.", entityName);
        }

        public static string EXC002(string entityName)
        {
            return String.Format("The {} entity cannot be null.", entityName);
        }

        public static string EXC003(string parameterName)
        {
            return String.Format("The {} parameter cannot be empty.", parameterName);
        }

        public static string EXC004(string parameterName)
        {
            return String.Format("The {} parameter cannot be null.", parameterName);
        }

        public static string EXC005()
        {
            return "A entidade não pode ser nula.";
        }
    }
}

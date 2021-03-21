using System;

namespace Presentation.Utils.Messages
{
    public static class ExceptionMessages
    {
        public static string EXC001(string entityName)
        {
            return String.Format("The {0} entity cannot be empty.", entityName);
        }

        public static string EXC002(string entityName)
        {
            return String.Format("The {0} entity cannot be null.", entityName);
        }

        public static string EXC003(string parameterName)
        {
            return String.Format("The {0} parameter cannot be empty.", parameterName);
        }

        public static string EXC004(string parameterName)
        {
            return String.Format("The {0} parameter cannot be null.", parameterName);
        }

        public static string EXC005(string parameterName, int min)
        {
            return String.Format("The {0} parameter must be at least {1} characters long.", parameterName, min);
        }

        public static string EXC006(string parameterName, int max)
        {
            return String.Format("The {0} parameter must have a maximum of {1} characters.", parameterName, max);
        }

        public static string EXC007(string parameterName)
        {
            return String.Format("The {0} parameter entered is not valid.", parameterName);
        }

        public static string EXC008(string parameterName)
        {
            return String.Format("The {0} parameter entered is not valid.", parameterName);
        }

        public static string EXC009()
        {
            return String.Format("The Post request cannot be empty");
        }

        public static string EXC010()
        {
            return String.Format("The Post request cannot be null");
        }

        public static string EXC011()
        {
            return String.Format("The Get request cannot be empty");
        }

        public static string EXC012()
        {
            return String.Format("The Get request cannot be Null");
        }

        public static string EXC013(string parameterName, int length)
        {
            return String.Format("The {0} parameter must be {1} characters.", parameterName, length);
        }

        public static string EXC014()
        {
            return String.Format("The following parameters are invalid:");
        }
    }
}

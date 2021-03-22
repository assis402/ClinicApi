using System.Linq;

namespace Presentation.Utils
{
    public class UsefulFunctions
    {
        public static string RemoveNonNumeric(string text)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"[^0-9]");
            string ret = reg.Replace(text, string.Empty);
            return ret;
        }

        public static bool IsValidCNPJ(string rawCnpj)
        {
            rawCnpj = RemoveNonNumeric(rawCnpj);
            
            if (rawCnpj.Length != 14)
            {
                return false;
            }

            int[] cnpj = new int[14];

            for (int i = 0; i < 14; i++)
            {
                cnpj[i] = int.Parse(rawCnpj[i].ToString());
            }

            int[] cnpjSub = cnpj.Skip(0).Take(12).ToArray();
            int[] multiplier = new int[12] {5,4,3,2,9,8,7,6,5,4,3,2};

            for (int i = 0; i < 11; i++)
            {
                multiplier[i] = cnpjSub[i] * multiplier[i];
            }

            int summation = multiplier.Sum();
            int remnant = (summation % 11);

            if (remnant < 2 && cnpj[12] != 0)
            {
                return false;
            }

            remnant = 11 - remnant;

            if (cnpj[12] != remnant)
            {
                return false;
            }

            cnpjSub = cnpj.Skip(0).Take(13).ToArray();
            multiplier = new int[] {6,5,4,3,2,9,8,7,6,5,4,3,2};

            for (int i = 0; i < 13; i++)
            {
                multiplier[i] = cnpjSub[i] * multiplier[i];
            }

            summation = multiplier.Sum();
            remnant = (summation % 11);

            if (remnant < 2 && cnpj[13] != 0)
            {
                return false;
            }

            remnant = 11 - remnant;

            if (cnpj[13] != remnant)
            {
                return false;
            }

            return true;

        }

        public static bool JsonIsValidCPF<Model>(Model model, string cpf) where Model : class
        {
            cpf = RemoveNonNumeric(cpf);
            if (cpf.Length != 11)
            {
                return false;
            }

            bool repeated = true;

            for (int i = 1; i < cpf.Length; i++)
            {
                if (cpf[i] != cpf[0])
                {
                    repeated = false;
                    break;
                }
            }

            if (repeated || cpf == "12345678909")
            {
                return false;
            }

            int[] numbers = new int[11];

            for (int i = 0; i < cpf.Length; i++)
            {
                numbers[i] = int.Parse(cpf[i].ToString());
            }

            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                sum += numbers[i] * (10 - i);
            }

            int remnant = (sum * 10) % 11;

            if (remnant == 10 && numbers[9] != 0)
            {
                return false;
            }

            else if (remnant != 10 && remnant != numbers[9])
            {
                return false;
            }

            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum += numbers[i] * (11 - i);
            }

            remnant = (sum * 10) % 11;

            if (remnant == 10 && numbers[10] != 0)
            {
                return false;
            }

            else if (remnant != 10 && remnant != numbers[10])
            {
                return false;
            }


            return true;
        }

        public static bool IsValidCPF(string cpf)
        {
            cpf = RemoveNonNumeric(cpf);
            if (cpf.Length != 11)
            {
                return false;
            }

            bool repeated = true;

            for (int i = 1; i < cpf.Length; i++)
            {
                if (cpf[i] != cpf[0])
                {
                    repeated = false;
                    break;
                }
            }

            if (repeated || cpf == "12345678909")
            {
                return false;
            }

            int[] numbers = new int[11];

            for (int i = 0; i < cpf.Length; i++)
            {
                numbers[i] = int.Parse(cpf[i].ToString());
            }

            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                sum += numbers[i] * (10 - i);
            }

            int remnant = (sum * 10) % 11;

            if (remnant == 10 && numbers[9] != 0)
            {
                return false;
            }

            else if (remnant != 10 && remnant != numbers[9])
            {
                return false;
            }

            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum += numbers[i] * (11 - i);
            }

            remnant = (sum * 10) % 11;

            if (remnant == 10 && numbers[10] != 0)
            {
                return false;
            }

            else if (remnant != 10 && remnant != numbers[10])
            {
                return false;
            }


            return true;
        }
    }
}

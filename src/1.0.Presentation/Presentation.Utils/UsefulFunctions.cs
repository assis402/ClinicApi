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

        public static bool IsValidCNPJ(string cnpj)
        {
            cnpj = RemoveNonNumeric(cnpj);
            
            if (cnpj.Length != 14)
            {
                return false;
            }

            string cnpjSub = cnpj.Substring(0,12);
            int[] multiplier = new int[12] {5,4,3,2,9,8,7,6,5,4,3,2};

            for (int i = 0; i < cnpjSub.Length; i++)
            {
                multiplier[i] = cnpjSub[i] * multiplier[i];
            }

            int summation = multiplier.Sum();
            int remnant = (summation % 11);

            if (!(remnant < 2 && cnpjSub[13] == 0))
            {
                return false;
            }

            remnant = 11 - remnant;

            if (!(remnant >= 2 && cnpjSub[13] == remnant))
            {
                return false;
            }

            cnpjSub = cnpj.Substring(0,13);
            multiplier = new int[13] {6,5,4,3,2,9,8,7,6,5,4,3,2};

            for (int i = 0; i < cnpjSub.Length; i++)
            {
                multiplier[i] = cnpjSub[i] * multiplier[i];
            }

            summation = multiplier.Sum();
            remnant = (summation % 11);

            if (!(remnant < 2 && cnpjSub[14] == 0))
            {
                return false;
            }

            remnant = 11 - remnant;

            if (!(remnant >= 2 && cnpjSub[14] == remnant))
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

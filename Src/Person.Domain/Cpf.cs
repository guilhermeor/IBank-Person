using System;

namespace Person.Domain
{
    public struct Cpf
    {
        private readonly string _value;

        private Cpf(string value) { _value = value; }

        public static Cpf Parse(string value)
        {
            if (TryParse(value, out var result))
            {
                return result;
            }
            throw new ArgumentException("Invalid Cpf number");
        }

        private static bool TryParse(string value, out Cpf cpf)
        {
            cpf = new Cpf(value);
            return ValidarCPF(value);
        }

        public override string ToString() => _value;

        private static bool ValidarCPF(string sourceCPF)
        {
            static bool VerificaTodosValoresSaoIguais(ref Span<int> input)
            {
                for (var i = 1; i < 11; i++)
                {
                    if (input[i] != input[0])
                    {
                        return false;
                    }
                }

                return true;
            }

            if (string.IsNullOrWhiteSpace(sourceCPF))
                return false;

            Span<int> cpfArray = stackalloc int[11];
            var count = 0;

            foreach (var c in sourceCPF)
            {
                if (char.IsDigit(c))
                {
                    if (count > 10)
                    {
                        return false;
                    }
                    cpfArray[count] = c - '0';
                    count++;
                }
            }

            if (count != 11) return false;
            if (VerificaTodosValoresSaoIguais(ref cpfArray)) return false;


            var totalDigitoI = 0;
            var totalDigitoII = 0;
            int modI;
            int modII;

            for (var posicao = 0; posicao < cpfArray.Length - 2; posicao++)
            {
                totalDigitoI += cpfArray[posicao] * (10 - posicao);
                totalDigitoII += cpfArray[posicao] * (11 - posicao);
            }

            modI = totalDigitoI % 11;
            if (modI < 2) { modI = 0; }
            else { modI = 11 - modI; }

            if (cpfArray[9] != modI)
            {
                return false;
            }

            totalDigitoII += modI * 2;

            modII = totalDigitoII % 11;
            if (modII < 2) { modII = 0; }
            else { modII = 11 - modII; }

            return cpfArray[10] == modII;
        }
    }
}
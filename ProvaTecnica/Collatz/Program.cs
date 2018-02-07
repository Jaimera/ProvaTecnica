using System;

namespace ProvaTecnica.Collatz
{
    public class Program
    {
        static void Main(string[] args)
        {
            var numeroComMaiorSequencia = Run();
            Console.WriteLine($"o numero Entre 1 e 1000000 com mais termos segundo o Problema de Collatz " +
                $"é {numeroComMaiorSequencia}");
            Console.ReadKey();
        }

        public static int Run()
        {

            int valorComMaiorSequencia = 0;
            int maiorQuantidade = 0;

            for (var i = 1; i <= 1000000; i++)
            {
                var count = Collatz(i);

                if (count > maiorQuantidade)
                {
                    valorComMaiorSequencia = i;
                    maiorQuantidade = count;
                }

            }

            //Console.Write($"Com {maiorQuantidade} termos");

            return valorComMaiorSequencia;
        }

        public static int Collatz(long value)
        {
            if (value == 0)
                return 0;

            int count = 1;

            while (value != 1)
            {
                if (value % 2 > 0)
                    value = value * 3 + 1;
                else
                    value /= 2;
                
                count++;
            }

            return count;
        }
    }
}

using System;
using System.Linq;

namespace ProvaTecnica.Impares
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] numeros = { 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144 };

            Console.Write("Todos os numeros são impares: ");
            Console.WriteLine(Run(numeros) ? "sim" : "não");

            Console.ReadKey();
        }

        public static bool Run(int[] numeros)
        {
            return numeros.All(a => a % 2 > 0);
        }
    }
}

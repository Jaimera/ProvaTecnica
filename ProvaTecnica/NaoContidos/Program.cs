using System;
using System.Linq;

namespace ProvaTecnica.NaoContidos
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] primeiroArray = { 1, 3, 7, 29, 42, 98, 234, 93 };
            int[] segundoArray = { 4, 6, 93, 7, 55, 32, 3 };

            Console.Write("Estes numeros não estão contidos no segundoArray: ");

            Console.WriteLine(string.Join(", ", Run(primeiroArray, segundoArray)));

            Console.ReadKey();
        }

        public static int[] Run(int[] primeiro, int[] segundo)
        {
            var naoContidos = primeiro.Where(s => !segundo.Contains(s));
            return naoContidos.ToArray();
        }
    }
}

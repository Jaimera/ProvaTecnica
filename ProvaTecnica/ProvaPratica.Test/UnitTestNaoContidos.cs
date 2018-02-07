using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTecnica.Test
{
    [TestClass]
    public class UnitTestNaoContidos
    {
        [TestMethod]
        public void TestNaoContidos()
        {
            int[] primeiroArray = { 1, 3, 7, 29, 42, 98, 234, 93 };
            int[] segundoArray = { 4, 6, 93, 7, 55, 32, 3 };

            int[] resultado = ProvaTecnica.NaoContidos.Program.Run(primeiroArray, segundoArray);
            
            int[] naoContidos = { 1, 29, 42, 98, 234 };
            CollectionAssert.AreEqual(resultado, naoContidos);
        }

        [TestMethod]
        public void TestNaoContidosTodos()
        {
            int[] primeiroArray = { 1, 3, 7, 29, 42, 98, 234, 93 };
            int[] segundoArray = { 98, 4, 29, 6, 93, 234, 7, 1, 55, 32, 42, 3 };

            int[] resultado = ProvaTecnica.NaoContidos.Program.Run(primeiroArray, segundoArray);

            int[] vazio = { };
            CollectionAssert.AreEqual(resultado, vazio);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTecnica.Test
{
    [TestClass]
    public class UnitTestImpares
    {
        [TestMethod]
        public void TestImpares()
        {
            int[] numeros = { 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144 };

            bool resultado = ProvaTecnica.Impares.Program.Run(numeros);

            Assert.AreEqual(resultado, false);
        }

        [TestMethod]
        public void TestImparesComPares()
        {
            int[] numeros = { 2, 8, 34, 144 };

            bool resultado = ProvaTecnica.Impares.Program.Run(numeros);

            Assert.AreEqual(resultado, false);
        }

        [TestMethod]
        public void TestImparesComImpares()
        {
            int[] numeros = { 1, 3, 5, 13, 21, 55, 89 };

            bool resultado = ProvaTecnica.Impares.Program.Run(numeros);

            Assert.AreEqual(resultado, true);
        }
    }
}

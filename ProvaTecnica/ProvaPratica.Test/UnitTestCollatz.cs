using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTecnica.Test
{
    [TestClass]
    public class UnitTestCollatz
    {
        [TestMethod]
        public void TestCollatzComTreze()
        {
            var termos = ProvaTecnica.Collatz.Program.Collatz(13);

            Assert.AreEqual(termos, 10);
        }

        [TestMethod]
        public void TestCollatzComUm()
        {
            var termos = ProvaTecnica.Collatz.Program.Collatz(1);

            Assert.AreEqual(termos, 1);
        }

        [TestMethod]
        public void TestCollatzComZero()
        {
            var termos = ProvaTecnica.Collatz.Program.Collatz(0);

            Assert.AreEqual(termos, 0);
        }

        [TestMethod]
        public void TestCollatzMaiorNumeroEmUmMilhao()
        {
            var numeroComMaiorSequencia = ProvaTecnica.Collatz.Program.Run();

            Assert.AreEqual(numeroComMaiorSequencia, 837799);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckTypeReturn()
        {
            var blib = new testenginterview.bigramlib();
            string empty = "";
            Assert.IsInstanceOfType(blib.biGrams(empty), typeof(List<string>));
        }

        [TestMethod]
        public void IgnoreEmpty()
        {
            var blib = new testenginterview.bigramlib();
            string empty = "";
            Assert.AreEqual(blib.biGrams(empty).Count, 0);
        }

        [TestMethod]
        public void IgnoreOneWord()
        {
            var blib = new testenginterview.bigramlib();
            string oneword = "the";
            Assert.AreEqual(blib.biGrams(oneword).Count, 0);
        }

        [TestMethod]
        public void IgnoreGarbage()
        {
            var blib = new testenginterview.bigramlib();
            string garbage = "~!@#$%^&*()_+{}|[]\\:\";'<>?,./ ~!@#$%^&*()_+{}|[]\\:\";'<>?,./";
            Assert.AreEqual(blib.biGrams(garbage).Count, 0);
        }

        [TestMethod]
        public void CountIncludingDuplicates()
        {
            var blib = new testenginterview.bigramlib();
            Assert.AreEqual(blib.biGrams("“The quick brown fox and the quick blue hare.”").Count,8);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace testenginterview_tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DirectCallWithNullOrEmpty()
        {
            // Tests that we expect to return false.
            string[] words = { string.Empty, null };
            foreach (var word in words)
            {
                bool result = bigramnamespace.biGrams(word);
                Assert.IsFalse(result,
                       String.Format("Expected for '{0}': false; Actual: {1}",
                                     word == null ? "<null>" : word, result));
            }
        }
    }
}

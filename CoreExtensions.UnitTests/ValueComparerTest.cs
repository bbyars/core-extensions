using NUnit.Framework;

namespace CoreExtensions.UnitTests
{
    [TestFixture]
    public class ValueComparerTest
    {
        [Test]
        public void EmptyEnumerables()
        {
            Assert.IsTrue(new int[0].ValueEquals(new int[0]));
        }
    }
}
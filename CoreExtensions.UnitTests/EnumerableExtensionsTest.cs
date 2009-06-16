using System.Collections;
using NUnit.Framework;

namespace CoreExtensions.UnitTests
{
    [TestFixture]
    public class EnumerableExtensionsTest
    {
        [Test]
        public void MapEmptyCollection()
        {
            Assert.AreEqual(new int[0], new int[0].Map(item => item));
        }

        [Test]
        public void IdentityMap()
        {
            Assert.AreEqual(new[] {1, 2, 3}, new[] {1, 2, 3}.Map(item => item));
        }

        [Test]
        public void IncrementMap()
        {
            Assert.AreEqual(new[] {2, 3, 4}, new[] {1, 2, 3}.Map(item => item + 1));
        }

        [Test]
        public void MapAsICollection()
        {
            var collection = new[] {1, 2, 3} as ICollection;
            Assert.AreEqual(new[] {"1", "2", "3"}, collection.Map(item => item.ToString()));
        }
    }
}
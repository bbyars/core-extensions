using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace CoreExtensions.UnitTests
{
    [TestFixture]
    public class PrettyPrintExtensionsTest
    {
        [Test]
        public void EmptyString()
        {
            Assert.AreEqual("\"\"", "".PrettyPrint());
        }

        [Test]
        public void NonEmptyString()
        {
            Assert.AreEqual("\"text\"", "text".PrettyPrint());
        }

        [Test]
        public void StringWithEmbeddedQuotes()
        {
            Assert.AreEqual("\"\"text\"\"", "\"text\"".PrettyPrint());
        }

        [Test]
        public void NullString()
        {
            Assert.AreEqual("<NULL>", ((string)null).PrettyPrint());
        }

        [Test]
        public void ObjectGivesToString()
        {
            Assert.AreEqual("1", 1.PrettyPrint());
        }

        [Test]
        public void NullObject()
        {
            Assert.AreEqual("<NULL>", ((object)null).PrettyPrint());
        }

        [Test]
        public void ObjectOverloadCanDelegateToStringOverload()
        {
            Assert.AreEqual("\"test\"", ((object)"test").PrettyPrint());
        }

        [Test]
        public void EmptyCollection()
        {
            Assert.AreEqual("[]", new string[0].PrettyPrint());
        }

        [Test]
        public void SingleItemCollection()
        {
            Assert.AreEqual("[\"item\"]", new [] {"item"}.PrettyPrint());
        }

        [Test]
        public void MultipleObjectCollection()
        {
            Assert.AreEqual("[1, 2, 3]", new[] {1, 2, 3}.PrettyPrint());
        }

        [Test]
        public void ObjectOverloadCanDelegateToCollectionOverload()
        {
            Assert.AreEqual("[]", ((object)new int[0]).PrettyPrint());
        }

        [Test]
        public void EmptyDictionary()
        {
            Assert.AreEqual("{}", new Hashtable().PrettyPrint());
        }

        [Test]
        public void DictionaryWithStringKey()
        {
            var hashtable = new Hashtable {{"key", 1}};
            Assert.AreEqual("{\"key\" => 1}", hashtable.PrettyPrint());
        }

        [Test]
        public void MultipleKeys()
        {
            // Dictionary<K,T> appears to maintain insertion order, unlike hashtables
            var hashtable = new Dictionary<object, object> {{1, "one"}, {"two", 2}};
            Assert.AreEqual("{1 => \"one\", \"two\" => 2}", hashtable.PrettyPrint());
        }

        [Test]
        public void ObjectOverloadCanDelegateToDictionaryOverload()
        {
            Assert.AreEqual("{}", ((object)new Hashtable()).PrettyPrint());
        }
    }
}
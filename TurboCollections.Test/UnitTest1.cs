using System;
using NUnit.Framework;

namespace TurboCollections.Test
{
    public class TurboListTests
    {
        [Test]
        public void NewListIsEmpty()
        {
            var list = new TurboList<int>();
            Assert.Zero(list.Count);
        }

        [Test]
        public void AddShouldIncreaseCountToOne()
        {
            var list = new TurboList<int>();
            list.Add(5);
            Assert.AreEqual(1, list.Count);
        }

        [Test]
        public void GetWithValidIndexShouldReturnItem()
        {
            var list = new TurboList<int>();
            list.Add(1);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(5);
            var find = list.Get(4);
            Assert.AreEqual(5, find);
        }

        [Test]
        public void GetWithInvalidIndexShouldThrowException()
        {
            var list = new TurboList<int>();
            list.Add(1);
            Assert.Throws<IndexOutOfRangeException>(delegate { list.Get(10); });
        }
    }
}
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

        [Test]
        public void ClearShouldEmptyList()
        {
            var list = new TurboList<int>();
            list.Add(1);
            list.Add(1);
            list.Add(2);
            list.Clear();
            Assert.Zero(list.Count); // Actually wanted to use Assert.IsEmpty()
        }

        [Test]
        public void RemoveAtStartWithValidIndexShouldChangeItemIndex()
        {
            var list = new TurboList<int>();
            list.Add(3);
            list.Add(2);
            list.Add(1);
            list.RemoveAt(0);
            Assert.AreEqual(list.Get(0), 2);
            Assert.AreEqual(list.Get(1), 1);
        }
        
        [Test]
        public void RemoveAtMiddleWithValidIndexShouldChangeItemIndex()
        {
            var list = new TurboList<int>();
            list.Add(3);
            list.Add(2);
            list.Add(1);
            list.RemoveAt(1);
            Assert.AreEqual(list.Get(0), 3);
            Assert.AreEqual(list.Get(1), 1);
        }
        
        [Test]
        public void RemoveAtEndWithValidIndexShouldChangeItemIndex()
        {
            var list = new TurboList<int>();
            list.Add(3);
            list.Add(2);
            list.Add(1);
            list.RemoveAt(2);
            Assert.AreEqual(list.Get(0), 3);
            Assert.AreEqual(list.Get(1), 2);
        }

        [Test]
        public void RemoveAtWithInvalidIndexShouldChangeItemIndex()
        {
            var list = new TurboList<int>();
            list.Add(3);
            list.Add(2);
            list.Add(1);
            Assert.Throws<IndexOutOfRangeException>(delegate { list.RemoveAt(5); });
        }
    }
}
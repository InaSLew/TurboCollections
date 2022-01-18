using System;
using System.Collections;
using System.Collections.Generic;
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
        public void SetWithValidIndexShouldWork()
        {
            var list = new TurboList<int>();
            list.Add(100);
            list.Set(0, 666);
            Assert.AreEqual(1, list.Count);
            Assert.IsFalse(list.Contains(100));
            Assert.IsTrue(list.Contains(666));
        }
        
        [Test]
        public void SetWithInvalidIndexShouldWork()
        {
            var list = new TurboList<int>();
            list.Add(100);
            Assert.Throws<IndexOutOfRangeException>(delegate { list.Set(5, 666); });
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

        [Test]
        public void ContainShouldReturnTrueWhenFindExist()
        {
            var list = new TurboList<int>();
            list.Add(-1);
            list.Add(500);
            list.Add(3);
            list.Add(50);
            Assert.IsTrue(list.Contains(3));
        }
        
        [Test]
        public void ContainShouldReturnFalseWhenFindNotExist()
        {
            var list = new TurboList<int>();
            list.Add(6);
            Assert.IsFalse(list.Contains(100));
        }

        [Test]
        public void IndexOfWithValidItemShouldReturnCorrectIndex()
        {
            var list = new TurboList<int>();
            list.Add(-1);
            list.Add(500);
            list.Add(3);
            list.Add(50);
            Assert.AreEqual(1, list.IndexOf(500));
        }
        
        [Test]
        public void IndexOfWithInvalidItemShouldReturnNonMinus1()
        {
            var list = new TurboList<int>();
            list.Add(-1);
            list.Add(500);
            list.Add(3);
            list.Add(50);
            Assert.AreEqual(-1, list.IndexOf(666));
        }

        [Test]
        public void RemoveWithValidItemShouldRemove()
        {
            var list = new TurboList<int>();
            list.Add(-1);
            list.Add(500);
            list.Add(3);
            list.Add(50);
            
            list.Remove(3);
            
            Assert.AreEqual(3, list.Count); // length of list should one short
            Assert.IsFalse(list.Contains(3)); // should no longer contain the removed item
        }
        
        [Test]
        public void RemoveWithInvalidItemShouldThrowException()
        {
            var list = new TurboList<int>();
            list.Add(-1);
            list.Add(500);
            list.Add(3);
            list.Add(50);

            Assert.Throws<InvalidOperationException>(delegate { list.Remove(666); });
        }

        [Test]
        public void AddRangeMultipleShouldWork()
        {
            IEnumerable<int> itemsToAdd = new[] {1, 2, 3};
            var list = new TurboList<int>();
            list.Add(3);
            list.Add(2);
            list.Add(1);
            list.AddRange(itemsToAdd);
            
            Assert.AreEqual(6, list.Count);
        }
        
        [Test]
        public void AddRangeSingleShouldWork()
        {
            IEnumerable<int> itemsToAdd = new[] {666};
            var list = new TurboList<int>();
            list.Add(3);
            list.Add(2);
            list.Add(1);
            list.AddRange(itemsToAdd);
            
            Assert.AreEqual(4, list.Count);
            Assert.IsTrue(list.Contains(666));
        }
    }
}
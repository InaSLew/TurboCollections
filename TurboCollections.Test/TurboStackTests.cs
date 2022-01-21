using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TurboCollections.Test
{
    [TestFixture]
    public class TurboStackTests
    {
        [Test]
        public void HasEmptyConstructor()
        {
            Console.WriteLine("HasEmptyConstructor fires");
            new TurboStack<int>();
        } 

        [Test]
        public void CountShouldReturn0RightAfterInitialization()
        {
            var stack = new TurboStack<int>();
            Assert.Zero(stack.Count);
        }

        [Test]
        public void PushShouldIncrementCountBy1()
        {
            var stack = new TurboStack<int>();
            stack.Push(666);
            Assert.AreEqual(1, stack.Count);
        }

        [Test]
        public void PushAfterPopShouldWork()
        {
            var stack = new TurboStack<int>();
            stack.Push(666);
            
            var pop = stack.Pop();
            stack.Push(777);

            Assert.AreEqual(pop, 666);
            Assert.AreEqual(1, stack.Count);
        }

        [Test]
        public void PeekShouldGetLatestPush()
        {
            var stack = new TurboStack<int>();
            stack.Push(66);
            stack.Push(666);
            Assert.AreEqual(666, stack.Peek());
        }

        [Test]
        public void PopShouldReturnLatestPush()
        {
            var stack = new TurboStack<int>();
            stack.Push(66);
            stack.Push(666);
            Assert.AreEqual(666, stack.Pop());
        }

        [Test]
        public void PopShouldRemoveLatestPush()
        {
            var stack = new TurboStack<int>();
            stack.Push(66);
            stack.Push(666);
            Assert.AreEqual(666, stack.Pop());
            Assert.AreEqual(1, stack.Count);
        }

    }
}
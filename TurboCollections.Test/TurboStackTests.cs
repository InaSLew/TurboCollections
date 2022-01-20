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
    }
}
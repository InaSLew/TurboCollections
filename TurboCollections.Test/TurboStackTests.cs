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
    }
}
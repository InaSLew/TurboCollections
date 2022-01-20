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
    }
}

using System;

namespace TurboCollections
{
    public class TurboStack<T>
    {
        static readonly int MAX = 1000; // Capacity of the stack
        private T[] items;

        public TurboStack()
        {
            items = new T[MAX];
        }
        // returns the current amount of items contained in the stack.
        public int Count { get; private set; }

        // adds one item on top of the stack.
        public void Push(T item)
        {
            EnsureCountWithinMax();
            items[Count++] = item;
        }

        private void EnsureCountWithinMax()
        {
            if (Count + 1 >= MAX) throw new Exception("Stack is full");
        }

        // returns the item on top of the stack without removing it.
        // T Peek();
        // returns the item on top of the stack and removes it at the same time.
        // T Pop();
        // removes all items from the stack.
        // void Clear();
        // --------------- optional ---------------
        // gets the iterator for this collection. Used by IEnumerable<T>-Interface to support foreach.
        // IEnumerator<T> IEnumerable<T>.GetEnumerator();

    }
}

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
            if (Count + 1 >= MAX) throw new StackOverflowException();
        }

        // returns the item on top of the stack without removing it.
        public T Peek() => IsEmpty ? default(T) : items[Count - 1];

        private bool IsEmpty => Count == 0;

        // returns the item on top of the stack and removes it at the same time.
        public T Pop()
        {
            var result = Peek();
            if (!IsEmpty) items[--Count] = default(T);
            return result;
        }
        
        // removes all items from the stack.
        public void Clear()
        {
            if (IsEmpty) return;
            for (int i = 0; i < Count - 1; i++)
            {
                items[i] = default(T);
            }
            Count = default;
        }
        
        // --------------- optional ---------------
        // gets the iterator for this collection. Used by IEnumerable<T>-Interface to support foreach.
        // IEnumerator<T> IEnumerable<T>.GetEnumerator();

    }
}

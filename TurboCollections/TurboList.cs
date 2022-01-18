using System;
using System.Collections.Generic;

namespace TurboCollections
{
    public class TurboList<T>
    {
        private T[] items;
        public static readonly int BufferSize = 4;
        
        public int Count { get; private set; }
        public int Length => items.Length;

        // adds one item to the end of the list.
        public void Add(T item)
        {
            EnsureSize(Count + 1);
            items[Count++] = item;
        }

        // gets the item at the specified index. If the index is outside the correct range, an exception is thrown.
        public T Get(int index)
        {
            if (IsIndexOutOfRange(index)) throw new IndexOutOfRangeException();
            return items[index];
        }
        
        // replaces the item at the specified index. If the index is outside the correct range, an exception is thrown.
        public void Set(int index, T value)
        {
            if (IsIndexOutOfRange(index)) throw new IndexOutOfRangeException();
            items[index] = value;
        }
        
        // removes all items from the list.
        public void Clear()
        {
            Array.Clear(items, 0, Count);
        }

        // removes one item from the list. If the 4th item is removed, then the 5th item becomes the 4th, the 6th becomes the 5th and so on.
        public void RemoveAt(int index)
        {
            if (IsIndexOutOfRange(index)) throw new IndexOutOfRangeException();
            var newItems = new T[Count - 1];
            for (var i = 0; i < items.Length; i++)
            {
                if (i < index) newItems[i] = items[i];
                else if (i == index) continue;
                else newItems[i - 1] = items[i];
            }

            items = newItems;
        }
        
        // returns true, if the given item can be found in the list, else false.
        public bool Contains(T item)
        {
            var result = false;
            foreach (var t in items)
            {
                result = t.Equals(item);
                if (result) break;
            }
            return result;
        }
        
        // returns the index of the given item if it is in the list, else -1.
        public int IndexOf(T item)
        {
            var result = -1;
            for (var i = 0; i < items.Length; i++)
            {
                if (!items[i].Equals(item)) continue;
                result = i;
                break;
            }
            return result;
        }

        // removes the specified item from the list, if it can be found.
        public void Remove(T item)
        {
            if (!Contains(item)) throw new InvalidOperationException();
            var indexToRemove = IndexOf(item);
            RemoveAt(indexToRemove);
        }
        
        // adds multiple items to this list at once.
        public void AddRange(IEnumerable<T> itemsToAdd)
        {
            using var enumerator = itemsToAdd.GetEnumerator();
            while (enumerator.MoveNext()) Add(enumerator.Current);
        }
        
        // gets the iterator for this collection. Used by IEnumerator to support foreach.
        // IEnumerator<T>.GetEnumerator();

        /// <summary>
        /// The method looks ahead and checks for over-indexing;
        /// it doubles the array size upon detection.
        /// </summary>
        /// <param name="count">The next index after the current index</param>
        private void EnsureSize(int count)
        {
            if (count < items.Length) return;
            Array.Resize(ref items, items.Length + BufferSize);
        }
        private bool IsIndexOutOfRange(int x) => (Count == 0 || x < 0 || x > Length - 1);
        
        public TurboList()
        {
            items = new T[BufferSize];
        }
    }
}

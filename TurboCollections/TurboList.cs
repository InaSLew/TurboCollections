using System;

namespace TurboCollections
{
    public class TurboList<T>
    {
        private T[] items;
        
        // returns the current amount of items contained in the list.
        public int Count => items.Length;
        
        // adds one item to the end of the list.
        public void Add(T item)
        {
            // Need to re-write this using the re-populating method
            Array.Resize(ref items, Count + 1);
            items[Count - 1] = item;
        }
        
        // gets the item at the specified index. If the index is outside the correct range, an exception is thrown.
        public T Get(int index)
        {
            if (IsIndexOutOfRange(index)) throw new IndexOutOfRangeException();
            return items[index];
        }
        
        // removes all items from the list.
        public void Clear() => items = Array.Empty<T>();

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
        
        // // returns true, if the given item can be found in the list, else false.
        // bool Contains(T item);
        
        // // returns the index of the given item if it is in the list, else -1.
        // int IndexOf(T item);
        
        // // removes the specified item from the list, if it can be found.
        // void Remove(T item);
        
        // // adds multiple items to this list at once.
        // void AddRange(IEnumerable<T> items);
        
        // // gets the iterator for this collection. Used by IEnumerator to support foreach.
        // IEnumerator<T>.GetEnumerator();

        private bool IsIndexOutOfRange(int x) => (Count == 0 || x < 0 || x > Count - 1);
        
        public TurboList()
        {
            Console.WriteLine("Hello Turbo!");
            items = Array.Empty<T>();
        }
    }
}

using System;
using System.Collections.Generic;


namespace Monoxhunder.Collections
{
    public class PriorityQueue<T> where T : IComparable
    {
        public bool SmallFirst = true;
        private T[] collection;

        public PriorityQueue()
        {
            collection = [];
        }

        public PriorityQueue(T[] values)
        {
            collection = values;
        }

        public void Add(T item)
        {
            T[] newCollection = new T[collection.LongLength + 1];
            int placeAt = collection.Length;
            //search insert point
            for (int i = 0; i < collection.Length; i++)
            {
                if (item.CompareTo(collection[i]) < 0)
                {
                    placeAt = i;
                    break;
                }
                newCollection[i] = collection[i];
            }
            //shuffle to right
            for (int i = placeAt + 1; i < newCollection.Length; i++)
            {
                newCollection[i] = collection[i - 1];
            }
            newCollection[placeAt] = item;
            collection = newCollection;
        }

        public T Peek() => SmallFirst ? collection[0] : collection[collection.Length];

        public T Dequeue()
        {
            T result = Peek();
            T[] newCollection = new T[collection.Length];
            for (int i = 0; i < collection.Length - 1; i++)
            {
                newCollection[i] = collection[i + (SmallFirst ? 1 : 0)];
            }
            collection = newCollection;
            return result;
        }

        public override string ToString()
        {
            string result = "[";
            for (int i = 0; i < collection.Length; i++)
            {
                result += collection[i].ToString();
                if (i != collection.Length - 1)
                {
                    result += ", ";
                }
            }
            result += "]";
            return result;
        }
    }
}
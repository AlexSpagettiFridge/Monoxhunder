using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using Monoxhunder.Collections.Pathfinding;

namespace Monoxhunder.Collections
{
    public class ValueGridMap<T> : IEnumerable
    {
        public delegate N EntryConversion<N>(T entry);
        private T[,] map;
        public int Width => map.GetLength(0);
        public int Height => map.GetLength(1);

        public ValueGridMap(int width, int height, T defaultValue)
        {
            map = new T[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    map[x, y] = defaultValue;
                }
            }
        }

        public ValueGridMap(int width, int height)
        {
            map = new T[width, height];
        }

        public T this[int x, int y] { get => map[x, y]; set => map[x, y] = value; }
        public T this[IntVector2 vector] { get => map[vector.X, vector.Y]; set => map[vector.X, vector.Y] = value; }

        public IEnumerator GetEnumerator() => new ValueGridMapEnumerator<T>(this);

        public ValueGridMapPainter<T> GetPainter() => new(this);

        public bool Contains(int x, int y) => Contains(new(x, y));
        public bool Contains(IntVector2 vector)
        {
            return vector.X >= 0 && vector.Y >= 0 && vector.X < Width && vector.Y < Height;
        }

        public ValueGridMap<N> ConvertToNewMap<N>(EntryConversion<N> entryConversion)
        {
            ValueGridMap<N> result = new(Width, Height);
            foreach (ValueGridMapEnumeratorEntry<T> entry in this)
            {
                result[entry.Position] = entryConversion.Invoke(entry.Value);
            }
            return result;
        }
    }
}
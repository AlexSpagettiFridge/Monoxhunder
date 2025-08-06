using System.Collections;
using System.Diagnostics.Contracts;

namespace Monoxhunder.Collections
{
    public class ValueGridMap<T> : IEnumerable
    {
        private T[,] map;
        public int Width => map.GetLength(0);
        public int Height => map.GetLength(1);

        public ValueGridMap(int width, int height, T defaultValue)
        {
            map = new T[width,height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    map[x, y] = defaultValue;
                }
            }
        }

        public T this[int x, int y] { get => map[x, y]; set => map[x, y] = value; }
        public T this[IntVector2 vector] { get => map[vector.X, vector.Y]; set => map[vector.X, vector.Y] = value; }

        public IEnumerator GetEnumerator() => new ValueGridMapEnumerator<T>(this);

        public ValueGridMapPainter<T> GetPainter() => new ValueGridMapPainter<T>(this);
    }
}
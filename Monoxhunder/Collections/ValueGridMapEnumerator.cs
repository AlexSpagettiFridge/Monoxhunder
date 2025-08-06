using System.Collections;
using System.Collections.Generic;

namespace Monoxhunder.Collections
{
    internal class ValueGridMapEnumerator<T>(ValueGridMap<T> _source) : IEnumerator<ValueGridMapEnumeratorEntry<T>>
    {
        private readonly ValueGridMap<T> source = _source;
        private int x = -1, y = 0;

        public ValueGridMapEnumeratorEntry<T> Current => new(source[x, y], x, y);

        object IEnumerator.Current => Current;

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            x++;
            if (x >= source.Width)
            {
                x = 0;
                y++;
            }
            return y < source.Height;
        }

        public void Reset()
        {
            x = -1;
            y = 0;
        }
    }
}
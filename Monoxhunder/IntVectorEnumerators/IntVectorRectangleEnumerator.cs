using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Monoxhunder.IntVectorEnumerators
{
    public class IntVectorRectangleEnumerator(Rectangle source) : IEnumerator<IntVector2>
    {
        private Rectangle source = source;
        private int x = source.Left, y = source.Top;

        public IntVector2 Current => new(x,y);

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            x++;
            if (x > source.Right)
            {
                x = source.Left;
                y++;
            }
            return y <= source.Bottom;
        }

        public void Reset()
        {
            x = source.Left;
            y = source.Top;
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Monoxhunder.IntVectorEnumerators
{
    /// <summary>
    /// Enumerates through all integer vectors in  a line by using Bresenham's line algorithm.
    /// </summary>
    public class IntVectorLineEnumerator : IEnumerator<IntVector2>
    {
        private bool xForward;
        private readonly IntVector2 delta, start, end, difference;
        private IntVector2 current;
        private int d;

        public IntVectorLineEnumerator(IntVector2 start, IntVector2 end)
        {
            difference = end - start;
            this.start = start;
            this.end = end;
            current = start;

            xForward = Math.Abs(difference.X) > Math.Abs(difference.Y);
            delta = difference.Sign();

            d = (2 * difference.Y) - difference.Y;
        }

        public IntVector2 Current => current;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (xForward)
            {
                current.X += delta.X;
                if (d > 0)
                {
                    current.Y += delta.Y;
                    d += 2 * (difference.Y - difference.X);
                }
                else
                {
                    d += 2 * difference.Y;
                }
                return delta.X == end.X;
            }
            else
            {
                current.Y += delta.Y;
                if (d > 0)
                {
                    current.X += delta.X;
                    d += 2 * (difference.X - difference.Y);
                }
                else
                {
                    d += 2 * difference.X;
                }
                return delta.Y == end.Y;
            }
        }

        public void Reset()
        {
            current = start;
        }
    }
}
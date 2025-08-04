using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Monoxhunder.IntVectorEnumerators
{
    public class IntVectorEnumeratorFactory
    {
        public static IEnumerator<IntVector2> Create(object source)
        {
            if (source is Rectangle rectangle) { return new IntVectorRectangleEnumerator(rectangle); }
            throw new ArgumentException($"IntVectorEnumeratorFactory is unable to process an Argument of type {source.GetType()}");
        }

        public static IntVectorLineEnumerator FromLine(IntVector2 start, IntVector2 end)
        {
            return new IntVectorLineEnumerator(start, end);
        }
    }
}
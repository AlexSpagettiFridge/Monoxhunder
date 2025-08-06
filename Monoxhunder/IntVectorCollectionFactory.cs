using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Monoxhunder
{
    public class IntVectorCollectionFactory
    {
        public static List<IntVector2> FromRectangle(Rectangle source)
        {
            List<IntVector2> result = [];
            for (int x = source.Left; x <= source.Right; x++)
            {
                for (int y = source.Left; y <= source.Right; y++)
                {
                    result.Add(new IntVector2(x, y));
                }
            }
            return result;
        }

        public static List<IntVector2> FromLine(IntVector2 start, IntVector2 end)
        {
            IntVector2 difference = end - start;
            IntVector2 current = start;
            IntVector2 delta = difference.Sign();
            int d;
            List<IntVector2> result = [start];

            if (Math.Abs(difference.X) >= Math.Abs(difference.Y))
            {
                difference.Y = Math.Abs(difference.Y);
                d = (2 * difference.Y) - difference.X;
                while (true)
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
                    result.Add(current);
                    if (current.X == end.X) { break; }
                }
            }
            else
            {
                d = (2 * difference.X) - difference.Y;
                difference.X = Math.Abs(difference.X);
                while (true)
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
                    result.Add(current);
                    if (current.Y == end.Y) { break; }
                }
            }
            return result;
        }
    }
}
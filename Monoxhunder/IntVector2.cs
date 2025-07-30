using System;
using Microsoft.Xna.Framework;

namespace Monoxhunder
{
    public struct IntVector2
    {
        public int X = 0, Y = 0;

        public IntVector2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public IntVector2(Vector2 vector)
        {
            X = (int)Math.Floor(vector.X);
            Y = (int)Math.Floor(vector.Y);
        }
    }
}
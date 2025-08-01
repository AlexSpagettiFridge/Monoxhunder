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

        public static IntVector2 operator +(IntVector2 a, IntVector2 b)
        {
            return new IntVector2(a.X + b.X, a.Y + b.Y);
        }

        public static IntVector2 operator -(IntVector2 a, IntVector2 b)
        {
            return new IntVector2(a.X - b.X, a.Y - b.Y);
        }

        public static IntVector2 operator *(IntVector2 a, IntVector2 b)
        {
            return new IntVector2(a.X * b.X, a.Y * b.Y);
        }

        public static Vector2 operator /(IntVector2 a, IntVector2 b)
        {
            return new Vector2(a.X / b.X, a.Y / b.Y);
        }

        public static IntVector2 operator *(IntVector2 a, int b)
        {
            return new IntVector2(a.X * b, a.Y * b);
        }

        public static Vector2 operator /(IntVector2 a, int b)
        {
            return new Vector2(a.X / b, a.Y / b);
        }
    }
}
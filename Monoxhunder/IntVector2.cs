using System;
using System.Collections.ObjectModel;
using System.Reflection.Metadata.Ecma335;
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

        public IntVector2(Point point)
        {
            X = point.X;
            Y = point.Y;
        }

        public override readonly string ToString()
        {
            return $"[{X}:{Y}]";
        }

        /// <summary>
        /// Returns all adjancent vectors.
        /// </summary>
        /// <param name="diagonals">Wheter or not diagonal neighbours should be included.</param>
        /// <returns></returns>
        public readonly IntVector2[] GetNeighbours(bool diagonals)
        {
            
            IntVector2[] result = new IntVector2[diagonals ? 8 : 4];
            IntVector2 modifier = new(-2, -1);
            for (int i = 0;i < result.Length;)
            {
                modifier.X++;
                if (modifier.X == 0 && modifier.Y == 0) { continue; } //skip yourself
                if (modifier.X > 1)
                {
                    modifier.X = -1;
                    modifier.Y++;
                }
                if (!diagonals)
                {
                    if (Math.Abs(modifier.X) == Math.Abs(modifier.Y)) { continue; } //skip diagonals
                }
                result[i] = this + modifier;
                i++;
            }
            return result;
        }

        #region operators
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

        public static Vector2 operator !(IntVector2 a)
        {
            return new Vector2(-a.X, -a.Y);
        }

        public static bool operator ==(IntVector2 a, IntVector2 b)
        {
            return a.X == b.X && a.Y == b.Y;
        }

        public static bool operator !=(IntVector2 a, IntVector2 b)
        {
            return a.X != b.X || a.Y != b.Y;
        }

        public static implicit operator Vector2(IntVector2 a) => new(a.X, a.Y);
        public static explicit operator IntVector2(Vector2 a) => new(a);

        public static implicit operator Point(IntVector2 a) => new(a.X, a.Y);
        public static explicit operator IntVector2(Point a) => new(a);
        #endregion

        #region Math Functions
        public readonly IntVector2 Sign() => new(Math.Sign(X), Math.Sign(Y));
        #endregion
    }
}
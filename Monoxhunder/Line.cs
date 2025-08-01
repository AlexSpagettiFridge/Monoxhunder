using System;
using Microsoft.Xna.Framework;

namespace Monoxhunder
{
    public struct Line(Vector2 start, Vector2 end)
    {
        public Vector2 Start = start, End = end;
        public float Lenght
        {
            get
            {
                Vector2 difference = Start - End;
                return (float)Math.Sqrt(Math.Pow(difference.X, 2) + Math.Pow(difference.Y, 2));
            }
        }
    }
}
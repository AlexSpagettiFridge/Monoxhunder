using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;

namespace Monoxhunder.Collections
{
    public class ValueGridMapPainter<T>(ValueGridMap<T> canvas)
    {
        private readonly ValueGridMap<T> canvas = canvas;
        private List<IntVector2> affectedCoordinates = [];



        private bool AddIfNew(int x, int y) => AddIfNew(new IntVector2(x, y));

        private bool AddIfNew(IntVector2 vector)
        {
            if (affectedCoordinates.Contains(vector))
            {
                affectedCoordinates.Add(vector);
                return true;
            }
            return false;
        }



        public void Add(Rectangle rectangle)
        {
            for (int x = rectangle.Left; x < rectangle.Right; x++)
            {
                for (int y = rectangle.Top; y < rectangle.Bottom; y++)
                {
                    AddIfNew(x, y);
                }
            }
        }

        /// <summary>
        /// Sets all Values inside the <see cref="ValueGridMap"/> at the Added vectors to <paramref name="value"/>.
        /// </summary>
        /// <param name="value"></param>
        public void Paint(T value)
        {
            foreach (IntVector2 vector in affectedCoordinates)
            {
                canvas[vector] = value;
            }
        }
    }
}
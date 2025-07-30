using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;

namespace Monoxhunder.Collections
{
    public class ValueGridMapPainter<T>(ValueGridMap<T> canvas)
    {
        private readonly ValueGridMap<T> canvas = canvas;
        private List<Vector2> affectedCoordinates = [];



        private bool AddIfNew(int x, int y) => AddIfNew(new Vector2(x, y));

        private bool AddIfNew(Vector2 vector)
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
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Xna.Framework;

namespace Monoxhunder.Collections
{
    public class ValueGridMapPainter<T>(ValueGridMap<T> canvas)
    {
        private readonly ValueGridMap<T> canvas = canvas;
        private readonly List<IntVector2> affectedCoordinates = [];



        private bool AddIfNew(int x, int y) => AddIfNew(new IntVector2(x, y));

        private bool AddIfNew(IntVector2 vector)
        {
            if (!affectedCoordinates.Contains(vector))
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

        public void Add(Collection<IntVector2> vectors)
        {
            foreach (IntVector2 vector in vectors)
            {
                AddIfNew(vector);
            }
        }

        public void GrowSelection(int size, params T[] stopValues)
        {
            List<IntVector2> edgeVectors = affectedCoordinates;
            for (; size > 0; size--)
            {
                List<IntVector2> newEdgeVectors = [];
                foreach (IntVector2 vector in edgeVectors)
                {
                    foreach (IntVector2 neighbour in vector.GetNeighbours(false))
                    {
                        if (stopValues.Contains(canvas[neighbour])) { continue; } //skip over stopValues
                        if (AddIfNew(neighbour))
                        {
                            //Only add to edgeVectors if actually new
                            newEdgeVectors.Add(neighbour);
                        }
                    }
                }
                edgeVectors = newEdgeVectors;
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
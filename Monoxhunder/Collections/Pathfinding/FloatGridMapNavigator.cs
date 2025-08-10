using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Monoxhunder.Collections.Pathfinding
{
    public class FloatGridMapNavigator(ValueGridMap<float> map, bool diagonal = false)
    {
        /// <summary>
        /// 
        /// </summary>
        public ValueGridMap<float> WeightMap = map;
        /// <summary>
        /// Detemines by which factor the weight of diagonal paths will be modified.
        /// Diagonal paths will be ignored when this value is 0 or less.
        /// </summary>
        public float DiagonalModifier = diagonal ? MathF.Sqrt(2) : 0;


        public List<IntVector2> GetAStarPath(IntVector2 start, IntVector2 end)
        {
            return GetAStarPath(start, end, out float a);
        }

        public List<IntVector2> GetAStarPath(IntVector2 start, IntVector2 end, out float totalWeight)
        {
            if (start == end)
            {
                totalWeight = 0;
                return [start];
            }
            Collection<IntVector2> checkedTiles = [start];
            PriorityQueue<AStarPath> possiblePaths = new();
            possiblePaths.Add(new AStarPath(start, 0));
            while (!possiblePaths.IsEmpty)
            {
                AStarPath currentPath = possiblePaths.Dequeue();
                
                
                foreach (IntVector2 neighbour in currentPath.Last.GetNeighbours(DiagonalModifier > 0))
                {
                    //Check if inside map and not already visited
                    if (checkedTiles.Contains(neighbour) || !WeightMap.Contains(neighbour)) { continue; }
                    checkedTiles.Add(neighbour);
                    //Calculate movement weight of new tile
                    bool isDiagonal = Math.Abs(neighbour.X-currentPath.Last.X)==Math.Abs(neighbour.Y-currentPath.Last.Y);
                    float addedWeight = WeightMap[neighbour] * (isDiagonal ? DiagonalModifier : 1);
                    if (addedWeight <= 0) { continue; }

                    AStarPath newPath = new(currentPath, neighbour, addedWeight);
                    if (neighbour == end)
                    {
                        //End found -> return path
                        totalWeight = newPath.TotalWeight;
                        List<IntVector2> result = [];
                        result.AddRange(newPath.Path);
                        return result;
                    }
                    possiblePaths.Add(newPath);
                }
            }
            totalWeight = float.PositiveInfinity;
            return null;
        }

    }
}
using System;

namespace Monoxhunder.Collections.Pathfinding
{
    internal readonly struct AStarPath : IComparable
    {
        public readonly IntVector2[] Path;
        public readonly float TotalWeight;
        public readonly IntVector2 Last => Path[^1];

        public AStarPath(IntVector2 entry, float startWeight = 0)
        {
            Path = [entry];
            TotalWeight = startWeight;
        }

        public AStarPath(IntVector2[] path, float totalWeight)
        {
            Path = path;
            TotalWeight = totalWeight;
        }

        public AStarPath(AStarPath clone, IntVector2 additionalTile, float addedWeight)
        {
            Path = new IntVector2[clone.Path.LongLength + 1];
            for (int i = 0; i <= clone.Path.Length; i++)
            {
                Path[i] = clone.Path[i];
            }
        }

        public readonly int CompareTo(object obj)
        {
            if (obj is AStarPath other)
            {
                return Math.Sign(TotalWeight - other.TotalWeight);
            }
            return 0;
        }
    }
}
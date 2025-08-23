using Microsoft.Xna.Framework;
using Monoxhunder;
using Monoxhunder.Collections;
using Monoxhunder.Collections.Pathfinding;

namespace MonoxhunderTest
{
    public class TestUtil()
    {
        private static void WriteNewTestLine(string line)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(line);
            Console.ResetColor();
        }

        private static void WriteOutputLine(string line, bool isSuccess)
        {
            Console.ForegroundColor = isSuccess ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine(line);
            Console.ResetColor();
        }

        public static bool TestLineGeneration(IntVector2 start, IntVector2 end, List<IntVector2> expectedOutcome)
        {
            WriteNewTestLine($"Testing Line from {start} to {end}...");
            List<IntVector2> result = IntVectorCollectionFactory.FromLine(start, end);
            Console.Write("Result: ");
            for (int i = 0; i < result.Count; i++)
            {
                if (i == result.Count - 1)
                {
                    Console.WriteLine(result[i]);
                }
                else
                {
                    Console.Write($"{result[i]} ,");
                }
            }

            IEnumerable<IntVector2> comparisonA = result.Except(expectedOutcome);
            IEnumerable<IntVector2> comparisonB = expectedOutcome.Except(result);
            bool success = !comparisonA.Any() && !comparisonB.Any();

            if (success)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("✓ Result matches expected outcome.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("X Result doesn't match expected outcome.");
            }
            Console.ResetColor();
            return success;
        }

        public static bool TestPriorityQueue(params float[] rightOrderValues)
        {
            WriteNewTestLine("Testing Priority Queue...");
            PriorityQueue<float> priorityQueue = new();
            List<float> values = new(rightOrderValues);
            Random rr = new();
            while (values.Count > 0)
            {
                int randomIndex = rr.Next(values.Count - 1);
                priorityQueue.Add(values[randomIndex]);
                values.Remove(values[randomIndex]);
            }
            Console.WriteLine(priorityQueue.ToString());
            for (int i = 0; i < rightOrderValues.Length; i++)
            {
                if (priorityQueue.IsEmpty)
                {
                    WriteOutputLine("X PriorityQueue is shorter than expected entries.", false);
                    return false;
                }
                if (priorityQueue.Dequeue() != rightOrderValues[i])
                {
                    WriteOutputLine("X Entry incorrect.", false);
                    return false;
                }
            }
            if (!priorityQueue.IsEmpty)
            {
                WriteOutputLine("X PriorityQueue is longer than expected entries.", false);
                return false;
            }
            WriteOutputLine("✓ Result matches expected outcome.", true);
            return true;
        }

        public static void TestNavigation()
        {
            WriteNewTestLine("Testing AStar Navigation...");
            ValueGridMap<float> map = new(3, 3, 1);
            FloatGridMapNavigator navigator = new(map, false);
            Console.WriteLine(":" + navigator.GetAStarPath(new(0, 0), new(2, 2)));
        }

        public static void TestValueGridMapPainting()
        {
            WriteNewTestLine("Testing Grid Map Painting");
            ValueGridMap<int> map = new(5, 5, 0);
            ValueGridMapPainter<int> painter = map.GetPainter();
            painter.Add(new Rectangle(1, 1, 3, 3));
            painter.Paint(1);
            for (int y = 0; y < map.Height; y++)
            {
                Console.Write($"{y + 1}#");
                foreach (int value in map.GetRow(y))
                {
                    Console.Write(value);
                }
                Console.WriteLine();
            }
            
        }
    }
}
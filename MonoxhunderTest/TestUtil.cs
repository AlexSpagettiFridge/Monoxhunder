using Monoxhunder;

namespace MonoxhunderTest
{
    public class TestUtil()
    {
        public static bool TestLineGeneration(IntVector2 start, IntVector2 end, List<IntVector2> expectedOutcome)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"Testing Line from {start} to {end}...");
            Console.ResetColor();

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
    }
}
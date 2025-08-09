using Monoxhunder;
using Monoxhunder.Collections;
using MonoxhunderTest;

Console.WriteLine("Starting Test");
TestUtil.TestLineGeneration(new IntVector2(0, 0), new IntVector2(4, 4), [new(0, 0), new(1, 1), new(2, 2), new(3, 3), new(4, 4)]);
TestUtil.TestLineGeneration(new IntVector2(4, 4), new IntVector2(0, 0), [new(4, 4), new(3, 3), new(2, 2), new(1, 1), new(0, 0)]);
TestUtil.TestLineGeneration(new IntVector2(0, 0), new IntVector2(5, 2), [new(0, 0), new(1, 0), new(2, 1), new(3, 1), new(4, 2),new(5, 2)]);

TestUtil.TestLineGeneration(new IntVector2(4, 0), new IntVector2(0, 4), [new(4, 0), new(3, 1), new(2, 2), new(1, 3), new(0, 4)]);
TestUtil.TestLineGeneration(new IntVector2(0, 4), new IntVector2(4, 0), [new(0, 4), new(1, 3), new(2, 2), new(3, 1), new(4, 0)]);

PriorityQueue<float> priorityQueue = new();
priorityQueue.Add(100);
priorityQueue.Add(3);
priorityQueue.Add(20);
priorityQueue.Add(-4);
priorityQueue.Add(0.3f);

Console.WriteLine(priorityQueue.ToString());
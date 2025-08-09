namespace Monoxhunder.Collections
{
    public readonly struct ValueGridMapEnumeratorEntry<T>(T value, int x, int y)
    {
        public readonly T Value = value;
        public readonly int X => Position.X;
        public readonly int Y => Position.Y;
        public readonly IntVector2 Position = new(x, y);
    }
}
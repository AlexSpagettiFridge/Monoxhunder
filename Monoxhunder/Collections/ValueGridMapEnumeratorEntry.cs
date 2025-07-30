namespace Monoxhunder.Collections
{
    public struct ValueGridMapEnumeratorEntry<T>(T value, int x, int y)
    {
        public T Value = value;
        public int X = x, Y = y;
    }
}
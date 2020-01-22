namespace Repro
{
    public readonly partial struct Foo<TComparer>
    {
        public int Bar(string left, string right) => Comparer.Compare(left, right);
    }
}

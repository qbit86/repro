namespace Repro
{
    public interface IMonoid<T>
    {
        T Identity { get; }
        T Combine(T left, T right);
    }

    internal readonly struct AdditiveInt32Monoid : IMonoid<int>
    {
        public int Identity => 0;
        public int Combine(int left, int right) => left + right;
    }

    internal readonly struct MultiplicativeDecimalMonoid : IMonoid<decimal>
    {
        public decimal Identity => 1m;
        public decimal Combine(decimal left, decimal right) => left * right;
    }
}

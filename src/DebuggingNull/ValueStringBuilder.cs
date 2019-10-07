#nullable enable

using System.Buffers;
using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace

namespace System.Text
{
    internal ref struct ValueStringBuilder
    {
        private char[]? _arrayToReturnToPool;

        public ValueStringBuilder(int initialCapacity)
        {
            _arrayToReturnToPool = ArrayPool<char>.Shared.Rent(initialCapacity);
        }

        internal char[]? UnsafeArray => _arrayToReturnToPool;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose()
        {
            char[]? toReturn = _arrayToReturnToPool;
            this = default;
            if (toReturn != null)
            {
                ArrayPool<char>.Shared.Return(toReturn);
            }
        }
    }
}

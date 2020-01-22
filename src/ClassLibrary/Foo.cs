using System;
using System.Collections.Generic;

namespace Repro
{
    public readonly partial struct Foo<TComparer>
        where TComparer : IComparer<string>
    {
        private TComparer Comparer { get; }

        public Foo(TComparer comparer)
        {
            Comparer = comparer ?? throw new ArgumentNullException(nameof(comparer));
        }
    }
}

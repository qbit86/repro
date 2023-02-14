// ReSharper disable RedundantUsingDirective

using System;
using System.Collections.Generic;

namespace Repro;

#if NETSTANDARD2_1_OR_GREATER
using MyEnumerator = ArraySegment<int>.Enumerator;
#else
using MyEnumerator = IEnumerator<int>;
#endif

public static class OddEmptyLine { }

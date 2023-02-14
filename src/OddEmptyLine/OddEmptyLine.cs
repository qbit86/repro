namespace Repro;

#if NETSTANDARD2_1_OR_GREATER
using MyEnumerator = System.ArraySegment<int>.Enumerator;
#else
using MyEnumerator = System.Collections.Generic.IEnumerator<int>;
#endif

public static class OddEmptyLine { }

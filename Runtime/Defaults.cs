using UnityEngine;

namespace NonAllocPhysicsWrapper
{
    static class Defaults
    {
#if UNITY_EDITOR
        internal static readonly ILogger defaultLogger = Debug.unityLogger;
#else
        internal static readonly ILogger defaultLogger = null;
#endif
        internal const int defaultResultsBufferSize = 64;
    }
}

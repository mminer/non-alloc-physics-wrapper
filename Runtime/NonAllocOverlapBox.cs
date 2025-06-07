#if USE_PHYSICS

using System;
using UnityEngine;

namespace NonAllocPhysicsWrapper
{
    /// <summary>
    /// Wraps UnityEngine.Physics.OverlapBoxNonAlloc.
    /// </summary>
    public class NonAllocOverlapBox : NonAllocBase<Collider>
    {
        public NonAllocOverlapBox(Collider[] resultsBuffer) : base(resultsBuffer)
        {
        }

        public NonAllocOverlapBox(int resultsBufferSize = Defaults.defaultResultsBufferSize) : base(resultsBufferSize)
        {
        }

        public ReadOnlySpan<Collider> OverlapBox(
            Vector3 center,
            Vector3 halfExtents,
            Quaternion? orientation = null,
            int layerMask = Physics.AllLayers,
            QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
        {
            var resultsCount = Physics.OverlapBoxNonAlloc(
                center,
                halfExtents,
                resultsBuffer,
                orientation ?? Quaternion.identity,
                layerMask,
                queryTriggerInteraction);

            return ResultsBufferToSpan(resultsCount);
        }
    }
}

#endif

#if USE_PHYSICS

using System;
using UnityEngine;

namespace NonAllocPhysicsWrapper
{
    /// <summary>
    /// Wraps UnityEngine.Physics.OverlapCapsuleNonAlloc.
    /// </summary>
    public class NonAllocOverlapCapsule : NonAllocBase<Collider>
    {
        public NonAllocOverlapCapsule(Collider[] resultsBuffer) : base(resultsBuffer)
        {
        }

        public NonAllocOverlapCapsule(int resultsBufferSize = Defaults.defaultResultsBufferSize) : base(resultsBufferSize)
        {
        }

        public ReadOnlySpan<Collider> OverlapCapsule(
            Vector3 point0,
            Vector3 point1,
            float radius,
            int layerMask = Physics.AllLayers,
            QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
        {
            var resultsCount = Physics.OverlapCapsuleNonAlloc(
                point0,
                point1,
                radius,
                resultsBuffer,
                layerMask,
                queryTriggerInteraction);

            return ResultsBufferToSpan(resultsCount);
        }
    }
}

#endif

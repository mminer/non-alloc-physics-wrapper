#if USE_PHYSICS

using System;
using UnityEngine;

namespace NonAllocPhysicsWrapper
{
    /// <summary>
    /// Wraps UnityEnigne.Physics.CapsuleCastNonAlloc.
    /// </summary>
    public class NonAllocCapsuleCast : NonAllocBase<RaycastHit>
    {
        public NonAllocCapsuleCast(RaycastHit[] resultsBuffer) : base(resultsBuffer)
        {
        }

        public NonAllocCapsuleCast(int resultsBufferSize = Defaults.defaultResultsBufferSize) : base(resultsBufferSize)
        {
        }

        public ReadOnlySpan<RaycastHit> CapsuleCastAll(
            Vector3 point1,
            Vector3 point2,
            float radius,
            Vector3 direction,
            float maxDistance = Mathf.Infinity,
            int layerMask = Physics.DefaultRaycastLayers,
            QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
        {
            var resultsCount = Physics.CapsuleCastNonAlloc(
                point1,
                point2,
                radius,
                direction,
                resultsBuffer,
                maxDistance,
                layerMask,
                queryTriggerInteraction);

            return ResultsBufferToSpan(resultsCount);
        }
    }
}

#endif

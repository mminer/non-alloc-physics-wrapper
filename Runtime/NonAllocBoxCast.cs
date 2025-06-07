#if USE_PHYSICS

using System;
using UnityEngine;

namespace NonAllocPhysicsWrapper
{
    /// <summary>
    /// Wraps UnityEngine.Physics.BoxCastNonAlloc.
    /// </summary>
    public class NonAllocBoxCast : NonAllocBase<RaycastHit>
    {
        public NonAllocBoxCast(RaycastHit[] resultsBuffer) : base(resultsBuffer)
        {
        }

        public NonAllocBoxCast(int resultsBufferSize = Defaults.defaultResultsBufferSize) : base(resultsBufferSize)
        {
        }

        public ReadOnlySpan<RaycastHit> BoxCastAll(
            Vector3 center,
            Vector3 halfExtents,
            Vector3 direction,
            Quaternion? orientation = null,
            float maxDistance = Mathf.Infinity,
            int layerMask = Physics.DefaultRaycastLayers,
            QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
        {
            var resultsCount = Physics.BoxCastNonAlloc(
                center,
                halfExtents,
                direction,
                resultsBuffer,
                orientation ?? Quaternion.identity,
                maxDistance,
                layerMask,
                queryTriggerInteraction);

            return ResultsBufferToSpan(resultsCount);
        }
    }
}

#endif

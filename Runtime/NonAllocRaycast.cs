#if USE_PHYSICS

using System;
using UnityEngine;

namespace NonAllocPhysicsWrapper
{
    /// <summary>
    /// Wraps UnityEngine.Physics.RaycastNonAlloc.
    /// </summary>
    public class NonAllocRaycast : NonAllocBase<RaycastHit>
    {
        public NonAllocRaycast(RaycastHit[] resultsBuffer) : base(resultsBuffer)
        {
        }

        public NonAllocRaycast(int resultsBufferSize = Defaults.defaultResultsBufferSize) : base(resultsBufferSize)
        {
        }

        public ReadOnlySpan<RaycastHit> RaycastAll(
            Ray ray,
            float maxDistance = Mathf.Infinity,
            int layerMask = Physics.DefaultRaycastLayers,
            QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
        {
            var resultsCount = Physics.RaycastNonAlloc(
                ray,
                resultsBuffer,
                maxDistance,
                layerMask,
                queryTriggerInteraction);

            return ResultsBufferToSpan(resultsCount);
        }

        public ReadOnlySpan<RaycastHit> RaycastAll(
            Vector3 origin,
            Vector3 direction,
            float maxDistance = Mathf.Infinity,
            int layerMask = Physics.DefaultRaycastLayers,
            QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
        {
            var resultsCount = Physics.RaycastNonAlloc(
                origin,
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

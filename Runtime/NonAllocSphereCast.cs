#if USE_PHYSICS

using System;
using UnityEngine;

namespace NonAllocPhysicsWrapper
{
    /// <summary>
    /// Wraps UnityEngine.Physics.SphereCastNonAlloc.
    /// </summary>
    public class NonAllocSphereCast : NonAllocBase<RaycastHit>
    {
        public NonAllocSphereCast(RaycastHit[] resultsBuffer) : base(resultsBuffer)
        {
        }

        public NonAllocSphereCast(int resultsBufferSize = Defaults.defaultResultsBufferSize) : base(resultsBufferSize)
        {
        }

        public ReadOnlySpan<RaycastHit> SphereCastAll(
            Ray ray,
            float radius,
            float maxDistance = Mathf.Infinity,
            int layerMask = Physics.DefaultRaycastLayers,
            QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
        {
            var resultsCount = Physics.SphereCastNonAlloc(
                ray,
                radius,
                resultsBuffer,
                maxDistance,
                layerMask,
                queryTriggerInteraction);

            return ResultsBufferToSpan(resultsCount);
        }

        public ReadOnlySpan<RaycastHit> SphereCastAll(
            Vector3 origin,
            float radius,
            Vector3 direction,
            float maxDistance = Mathf.Infinity,
            int layerMask = Physics.DefaultRaycastLayers,
            QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
        {
            var resultsCount = Physics.SphereCastNonAlloc(
                origin,
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

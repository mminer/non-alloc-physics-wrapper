#if USE_PHYSICS

using System;
using UnityEngine;

namespace NonAllocPhysicsWrapper
{
    /// <summary>
    /// Wraps UnityEngine.Physics.OverlapSphereNonAlloc.
    /// </summary>
    public class NonAllocOverlapSphere : NonAllocBase<Collider>
    {
        public NonAllocOverlapSphere(Collider[] resultsBuffer) : base(resultsBuffer)
        {
        }

        public NonAllocOverlapSphere(int resultsBufferSize = Defaults.defaultResultsBufferSize) : base(resultsBufferSize)
        {
        }

        public ReadOnlySpan<Collider> OverlapSphere(
            Vector3 position,
            float radius,
            int layerMask = Physics.AllLayers,
            QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
        {
            var resultsCount = Physics.OverlapSphereNonAlloc(
                position,
                radius,
                resultsBuffer,
                layerMask,
                queryTriggerInteraction);

            return ResultsBufferToSpan(resultsCount);
        }
    }
}

#endif

#if USE_PHYSICS_2D

using System;
using UnityEngine;

namespace NonAllocPhysicsWrapper
{
    /// <summary>
    /// Wraps UnityEngine.Physics2D.GetRayIntersectionNonAlloc.
    /// </summary>
    public class NonAllocGetRayIntersection : NonAllocBase<RaycastHit2D>
    {
        public NonAllocGetRayIntersection(RaycastHit2D[] resultsBuffer) : base(resultsBuffer)
        {
        }

        public NonAllocGetRayIntersection(int resultsBufferSize = Defaults.defaultResultsBufferSize) : base(resultsBufferSize)
        {
        }

        public ReadOnlySpan<RaycastHit2D> GetRayIntersectionAll(
            Ray ray,
            float distance = Mathf.Infinity,
            int layerMask = Physics2D.DefaultRaycastLayers)
        {
            var resultsCount = Physics2D.GetRayIntersectionNonAlloc(
                ray,
                resultsBuffer,
                distance,
                layerMask);

            return ResultsBufferToSpan(resultsCount);
        }
    }
}

#endif

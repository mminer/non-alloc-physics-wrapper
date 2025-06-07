#if USE_PHYSICS_2D

using System;
using UnityEngine;

namespace NonAllocPhysicsWrapper
{
    public static class NonAllocPhysics2D
    {
        public static ILogger logger { private get; set; } = Defaults.defaultLogger;
        public static int resultsBufferSize { private get; set; } = Defaults.defaultResultsBufferSize;

        static RaycastHit2D[] raycastHit2DBuffer => _raycastHit2DBuffer ??= new RaycastHit2D[resultsBufferSize];

        static NonAllocGetRayIntersection nonAllocGetRayIntersection => _nonAllocGetRayIntersection ??= new NonAllocGetRayIntersection(raycastHit2DBuffer) { logger = logger };

        static RaycastHit2D[] _raycastHit2DBuffer;

        static NonAllocGetRayIntersection _nonAllocGetRayIntersection;

        public static ReadOnlySpan<RaycastHit2D> GetRayIntersectionAll(
            Ray ray,
            float distance = Mathf.Infinity,
            int layerMask = Physics2D.DefaultRaycastLayers)
        {
            return nonAllocGetRayIntersection.GetRayIntersectionAll(ray, distance, layerMask);
        }
    }
}

#endif

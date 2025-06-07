#if USE_PHYSICS

using System;
using UnityEngine;

namespace NonAllocPhysicsWrapper
{
    public static class NonAllocPhysics
    {
        public static ILogger logger { private get; set; } = Defaults.defaultLogger;
        public static int resultsBufferSize { private get; set; } = Defaults.defaultResultsBufferSize;

        static Collider[] colliderBuffer => _colliderBuffer ??= new Collider[resultsBufferSize];
        static RaycastHit[] raycastHitBuffer => _raycastHitBuffer ??= new RaycastHit[resultsBufferSize];

        static NonAllocBoxCast nonAllocBoxCast => _nonAllocBoxCast ??= new NonAllocBoxCast(raycastHitBuffer) { logger = logger };
        static NonAllocCapsuleCast nonAllocCapsuleCast => _nonAllocCapsuleCast ??= new NonAllocCapsuleCast(raycastHitBuffer) { logger = logger };
        static NonAllocOverlapBox nonAllocOverlapBox => _nonAllocOverlapBox ??= new NonAllocOverlapBox(colliderBuffer) { logger = logger };
        static NonAllocOverlapCapsule nonAllocOverlapCapsule => _nonAllocOverlapCapsule ??= new NonAllocOverlapCapsule(colliderBuffer) { logger = logger };
        static NonAllocOverlapSphere nonAllocOverlapSphere => _nonAllocOverlapSphere ??= new NonAllocOverlapSphere(colliderBuffer) { logger = logger };
        static NonAllocRaycast nonAllocRaycast => _nonAllocRaycast ??= new NonAllocRaycast(raycastHitBuffer) { logger = logger };
        static NonAllocSphereCast nonAllocSphereCast => _nonAllocSphereCast ??= new NonAllocSphereCast(raycastHitBuffer) { logger = logger };

        static Collider[] _colliderBuffer;
        static RaycastHit[] _raycastHitBuffer;

        static NonAllocBoxCast _nonAllocBoxCast;
        static NonAllocCapsuleCast _nonAllocCapsuleCast;
        static NonAllocOverlapBox _nonAllocOverlapBox;
        static NonAllocOverlapCapsule _nonAllocOverlapCapsule;
        static NonAllocOverlapSphere _nonAllocOverlapSphere;
        static NonAllocRaycast _nonAllocRaycast;
        static NonAllocSphereCast _nonAllocSphereCast;

        public static ReadOnlySpan<RaycastHit> BoxCastAll(
            Vector3 center,
            Vector3 halfExtents,
            Vector3 direction,
            Quaternion? orientation = null,
            float maxDistance = Mathf.Infinity,
            int layerMask = Physics.DefaultRaycastLayers,
            QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
        {
            return nonAllocBoxCast.BoxCastAll(center, halfExtents, direction, orientation, maxDistance, layerMask, queryTriggerInteraction);
        }

        public static ReadOnlySpan<RaycastHit> CapsuleCastAll(
            Vector3 point1,
            Vector3 point2,
            float radius,
            Vector3 direction,
            float maxDistance = Mathf.Infinity,
            int layerMask = Physics.DefaultRaycastLayers,
            QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
        {
            return nonAllocCapsuleCast.CapsuleCastAll(point1, point2, radius, direction, maxDistance, layerMask, queryTriggerInteraction);
        }

        public static ReadOnlySpan<Collider> OverlapBox(
            Vector3 center,
            Vector3 halfExtents,
            Quaternion? orientation = null,
            int layerMask = Physics.AllLayers,
            QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
        {
            return nonAllocOverlapBox.OverlapBox(center, halfExtents, orientation, layerMask, queryTriggerInteraction);
        }

        public static ReadOnlySpan<Collider> OverlapCapsule(
            Vector3 point0,
            Vector3 point1,
            float radius,
            int layerMask = Physics.AllLayers,
            QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
        {
            return nonAllocOverlapCapsule.OverlapCapsule(point0, point1, radius, layerMask, queryTriggerInteraction);
        }

        public static ReadOnlySpan<Collider> OverlapSphere(
            Vector3 position,
            float radius,
            int layerMask = Physics.AllLayers,
            QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
        {
            return nonAllocOverlapSphere.OverlapSphere(position, radius, layerMask, queryTriggerInteraction);
        }

        public static ReadOnlySpan<RaycastHit> RaycastAll(
            Ray ray,
            float maxDistance = Mathf.Infinity,
            int layerMask = Physics.DefaultRaycastLayers,
            QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
        {
            return nonAllocRaycast.RaycastAll(ray, maxDistance, layerMask, queryTriggerInteraction);
        }

        public static ReadOnlySpan<RaycastHit> RaycastAll(
            Vector3 origin,
            Vector3 direction,
            float maxDistance = Mathf.Infinity,
            int layerMask = Physics.DefaultRaycastLayers,
            QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
        {
            return nonAllocRaycast.RaycastAll(origin, direction, maxDistance, layerMask, queryTriggerInteraction);
        }

        public static ReadOnlySpan<RaycastHit> SphereCastAll(
            Ray ray,
            float radius,
            float maxDistance = Mathf.Infinity,
            int layerMask = Physics.DefaultRaycastLayers,
            QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
        {
            return nonAllocSphereCast.SphereCastAll(ray, radius, maxDistance, layerMask, queryTriggerInteraction);
        }

        public static ReadOnlySpan<RaycastHit> SphereCastAll(
            Vector3 origin,
            float radius,
            Vector3 direction,
            float maxDistance = Mathf.Infinity,
            int layerMask = Physics.DefaultRaycastLayers,
            QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
        {
            return nonAllocSphereCast.SphereCastAll(origin, radius, direction, maxDistance, layerMask, queryTriggerInteraction);
        }
    }
}

#endif

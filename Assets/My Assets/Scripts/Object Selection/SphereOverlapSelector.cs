using System;
using System.Collections.Generic;
using UnityEngine;

namespace GD.Selection
{
    /// <summary>
    /// Casts a sphere at a specified position and checks for objects inside its radius.
    /// This approach is effective at checking an area for selectables.
    /// The object closest to the sphere's origin is the one that is selected.
    /// </summary>
    public class SphereOverlapSelector : BaseCastSelector
    {
        [Header("Debug Gizmo Properties")]
        [SerializeField]
        [ColorUsage(false)]
        protected Color sphereColor = Color.yellow;

        [SerializeField]
        [Range(0.1f, 4)]
        [Tooltip("Define the sensitivity radius of the sphere to allow selection")]
        private float sphereRadius = 0.5f;

        private Vector3 lastPosition;

        public void CheckAt(Vector3 position)
        {
            selection = null;
            lastPosition = position;

            Collider[] colliders = new Collider[5];
            int count = Physics.OverlapSphereNonAlloc(position, sphereRadius, colliders, layerMask);

            if (count == 0)
            {
                return;
            }

            List<Collider> overlaps = new();
            for (int i = 0; i < count; i++)
            {
                overlaps.Add(colliders[i]);
            }

            // Sort based on distance from the origin
            overlaps.Sort((a, b) =>
            {
                float aDistance = Vector3.Distance(position, a.transform.position);
                float bDistance = Vector3.Distance(position, b.transform.position);

                return aDistance.CompareTo(bDistance);
            });

            // Select the closest object
            var currentSelection = overlaps[0].transform;
            if (currentSelection.CompareTag(selectableTag))
            {
                selection = currentSelection;
            }
            
        }

        // Implement this OnDrawGizmos if you want to draw gizmos that are also pickable and always drawn
        private void OnDrawGizmos()
        {
            Gizmos.color = sphereColor;
            Vector3 pointOnRay = lastPosition + ray.direction * maxDistance;
            Gizmos.DrawWireSphere(pointOnRay, sphereRadius);
        }
    }
}

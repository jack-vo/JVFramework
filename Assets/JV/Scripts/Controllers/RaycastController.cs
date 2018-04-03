using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JV {
    public class RaycastController : MonoBehaviour {

        public const float skinWidth = .015f;

        [HideInInspector]
        protected Collider2D collider;
        [HideInInspector]
        protected Rigidbody2D rigidbody;


        public int horizontalRayCount = 4;



        protected RaycastOrigins raycastOrigins;
        protected const float rayLength = 0.08f;
        protected float horizontalRaySpacing;


        // Use this for initialization
        public virtual void Start () {
            collider = GetComponent<Collider2D> ();
            rigidbody = GetComponent<Rigidbody2D> ();

            ComputeRays ();
        }

        void ComputeRays () {
            Bounds bounds = collider.bounds;

            horizontalRayCount = Mathf.Clamp (horizontalRayCount, 2, int.MaxValue);
            horizontalRaySpacing = bounds.size.x / (horizontalRayCount - 1);
        }

        protected void UpdateRaycastOrigins () {
            Bounds bounds = collider.bounds;
            bounds.Expand (skinWidth * -2); // srink 2 sides by skinWidth

            raycastOrigins.bottomLeft = new Vector2 (bounds.min.x, bounds.min.y);
            raycastOrigins.topLeft = new Vector2 (bounds.min.x, bounds.max.y);
            raycastOrigins.bottomRight = new Vector2 (bounds.max.x, bounds.min.y);
            raycastOrigins.topRight = new Vector2 (bounds.max.x, bounds.max.y);
        }

        protected RaycastHit2D VerticalRayHit (LayerMask layerMask) {
            UpdateRaycastOrigins ();
            RaycastHit2D hit = new RaycastHit2D ();

            for (int i = 0; i < horizontalRayCount; i++) {
                // check where the next ray should start from, bottom left or bottom right
                Vector2 rayOrigin = raycastOrigins.bottomLeft;

                // move the rayOrigin to the right location based on its current index
                rayOrigin += Vector2.right * horizontalRaySpacing * i;

                // DEBUG - draw all the ray casts
                Debug.DrawRay (rayOrigin, -Vector2.up * rayLength, Color.red);

                // Create raycast
                hit = Physics2D.Raycast (rayOrigin, -Vector2.up, rayLength, layerMask);

                if (hit) {
                    return hit;
                }
            }

            return hit;
        }

        public struct RaycastOrigins {
            public Vector2 topLeft, topRight;
            public Vector2 bottomLeft, bottomRight;
        }
    }
}

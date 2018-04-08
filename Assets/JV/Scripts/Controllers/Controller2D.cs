using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JV {
    [RequireComponent(typeof (Rigidbody2D))]
    public class Controller2D : EventEmitterController {
        public LayerMask collisionLayerMask;

        [HideInInspector]
        public AgentInfo agentInfo;

        public Animator anim;

        public Transform groundCheck;
        public float groundCheckRadius = .3f;
        public Transform wallCheck;
        public float wallCheckRadius = .3f;
        public Transform edgeCheck;
        public float edgeCheckRadius = .3f;


        protected Collider2D collider;
        protected Rigidbody2D rigidbody;

        public bool debugEnabled = false;

        float _storedGravity;

        public virtual void Start () {
            collider = GetComponent<Collider2D> ();
            rigidbody = GetComponent<Rigidbody2D> ();
            anim = GetComponent<Animator> ();
        }

        public virtual void Update () {
            Bounds bounds = collider.bounds;

            if (groundCheck) {
                agentInfo.grounded = Physics2D.OverlapCircle (
                    groundCheck.position,
                    groundCheckRadius,
                    collisionLayerMask
                );
            }

            if (wallCheck) {
                agentInfo.hittingWall = Physics2D.OverlapCircle (
                    wallCheck.position,
                    wallCheckRadius,
                    collisionLayerMask
                    );
            }

            if (edgeCheck) {
                agentInfo.atEdge = !Physics2D.OverlapCircle (
                    edgeCheck.position,
                    edgeCheckRadius,
                    collisionLayerMask
                    );
            }
        }

        public void Move(Vector2 newVelocity) {      
            rigidbody.velocity = newVelocity;
        }

        public void SetEnabled (bool value) {
            if (!value) {
                _storedGravity = rigidbody.gravityScale;
                rigidbody.gravityScale = 0f;
            } else {
                rigidbody.gravityScale = _storedGravity;
            }

            rigidbody.velocity = Vector2.zero;
            
            enabled = value;
            GetComponent<Renderer> ().enabled = value;
        }

        public Vector2 Velocity {
            get {
                return rigidbody.velocity;
            }
        }

        public struct AgentInfo {
            public bool grounded;
            public bool hittingWall;
            public bool atEdge;
        }


        void OnDrawGizmosSelected () {
            if (!debugEnabled) {
                return;
            }

            if (groundCheck) {
                Gizmos.color = Color.red;
                Gizmos.DrawSphere (groundCheck.position, groundCheckRadius);
            }

            if (wallCheck) {
                Gizmos.color = Color.yellow;
                Gizmos.DrawSphere (wallCheck.position, wallCheckRadius);
            }

            if (edgeCheck) {
                Gizmos.color = Color.blue;
                Gizmos.DrawSphere (edgeCheck.position, edgeCheckRadius);
            }
        }
    }
}

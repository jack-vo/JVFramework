using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JV {
    public class Movement : BaseBehavior {
        public float moveSpeed = 10;

        // Update is called once per frame
        public override void UpdateBehavior () {
            Vector2 newVelocity = Velocity;

            // Horizontal
            if (Input.GetButton("left")) {
                newVelocity.x = -moveSpeed;
                controller.Move (newVelocity);
            }

            if (Input.GetButton ("right")) {
                newVelocity.x = moveSpeed;
                controller.Move (newVelocity);
            }

            controller.anim.SetFloat ("Speed", Mathf.Abs (Velocity.x));

            if (Velocity.x > 0) {
                transform.localScale = new Vector3 (1f, 1f, 1f);
            } else if (Velocity.x < -.1f) {
                transform.localScale = new Vector3 (-1f, 1f, 1f);
            }
        }
    }
}

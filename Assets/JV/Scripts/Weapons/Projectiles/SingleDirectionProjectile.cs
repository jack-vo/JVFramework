using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JV {
    public class SingleDirectionProjectile : Projectile {
        public override void Update () {
            rigidbody.velocity = new Vector2 (speed, rigidbody.velocity.y);

            if (rotationSpeed != 0) {
                rigidbody.angularVelocity = rotationSpeed;
            }

            base.Update ();
        }
    }
}


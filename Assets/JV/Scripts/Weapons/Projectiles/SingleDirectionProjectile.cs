using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JV {
    public class SingleDirectionProjectile : Projectile {
        public override void Update () {
            projectileRigidbody.velocity = new Vector2 (speed, projectileRigidbody.velocity.y);

            if (!JVUtil.AboutEqual(rotationSpeed, 0f)) {
                projectileRigidbody.angularVelocity = rotationSpeed;
            }

            base.Update ();
        }
    }
}


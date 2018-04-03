using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JV {
    public class SingleDirectionProjectile : Projectile {
        void Update () {
            rigidbody.velocity = new Vector2 (speed, rigidbody.velocity.y);
        }
    }
}


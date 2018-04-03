using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JV {
    public class HandleProjectileWeapon : BaseBehavior {
        public Transform firePoint;
        public GameObject projectile;


        public override void UpdateBehavior () {
            if (Input.GetButtonDown("shoot")) {
                Instantiate (projectile, firePoint.position, firePoint.rotation);
            }
        }
    }
}


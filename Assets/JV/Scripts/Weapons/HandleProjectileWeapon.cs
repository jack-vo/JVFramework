using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JV {
    public class HandleProjectileWeapon : BaseBehavior {
        public Transform firePoint;
        public GameObject projectile;
        public float shotDelay = .5f;

        private float shotDelayCounter;


        public override void UpdateBehavior () {

            if (shotDelayCounter > 0) {
                shotDelayCounter -= Time.deltaTime;
            }

            if (Input.GetButton("shoot") && shotDelayCounter <= 0) {
                Instantiate (projectile, firePoint.position, firePoint.rotation);
                shotDelayCounter = shotDelay;
            }
        }
    }
}


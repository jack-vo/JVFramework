using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JV {
    public class EnemyHurtPlayerOnContact : BaseBehavior {
        public int damage = 1;

        // Update is called once per frame
        public override void UpdateBehavior () {

        }

        private void OnTriggerEnter2D (Collider2D other) {
            if (other.tag == "Player") {
                PlayerHealth playerHealth = other.GetComponent<PlayerHealth> ();

                if (playerHealth != null) {
                    playerHealth.TakeDamage (damage);
                }
            }
        }
    }
}


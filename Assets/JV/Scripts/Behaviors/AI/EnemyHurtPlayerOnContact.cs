using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JV {
    public class EnemyHurtPlayerOnContact : BaseBehavior {
        public int damage = 1;

        public override void Start () {
            base.Start ();
            // the code below is used to ignore the collision b/w player and the main collider,
            // collider that is used to trigger event still works
            //Physics2D.IgnoreCollision (GetComponent<Collider2D> (), FindObjectOfType<PlayerController> ().GetComponent<Collider2D>());
        }

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


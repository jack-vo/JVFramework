using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JV {
    public class DamageOnContact : MonoBehaviour {
        public int damage = 1;
        public float bounceOnEnemy = 15f;

        Controller2D controller;

        void Start () {
            controller = transform.parent.GetComponent<Controller2D> ();
        }

        void OnTriggerEnter2D (Collider2D other) {
            if (other.tag == "Enemy") {
                Health enemyHealth = other.GetComponent<Health> ();

                if (enemyHealth) {
                    if (controller) {
                        controller.Move (new Vector2 (controller.Velocity.x, bounceOnEnemy));
                    }
                    
                    enemyHealth.TakeDamage (damage);
                }
            }
        }
    }
}


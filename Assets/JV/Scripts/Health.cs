using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JV {
    public class Health : MonoBehaviour {
        public int maxHealth = 1;
        public int health = 1;
        public GameObject deathEffect;

		AudioSource audioSource;

        public virtual void Start () {
            if (health <= 0) {
                health = 1;
            }

            if (maxHealth < health) {
                maxHealth = health;
            }

			audioSource = GetComponent<AudioSource> ();
        }

        public virtual void Update () {
            if (health <= 0) {
                if (deathEffect) {
                    Instantiate (deathEffect, transform.position, transform.rotation);
                }

                Destroy (gameObject);
            }
        }

        public virtual void TakeDamage(int damageToTake) {
            health -= damageToTake;

			if (audioSource) {
				audioSource.Play ();
			}
        }

        public virtual void AddHealthPoints(int healthPoints) {
            health += healthPoints;

            if (health > maxHealth) {
                health = maxHealth;
            }
        }
    }
}


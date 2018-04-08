using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JV {
    public class Health : MonoBehaviour {
        public int maxHealth = 1;
        public int health = 1;
        public GameObject deathEffect;

        public AudioClip takeDamageAudioClip;
        public AudioClip recoverHealthAudioClip;

        protected AudioSource audioSource;
        protected Controller2D controller;

        public virtual void Start () {
            if (health <= 0) {
                health = 1;
            }

            if (maxHealth < health) {
                maxHealth = health;
            }

            if (takeDamageAudioClip || recoverHealthAudioClip) {
                audioSource = AudioManager.AudioSourceInstance;
            }

            controller = GetComponent<Controller2D> ();
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

			if (audioSource && takeDamageAudioClip) {
				audioSource.PlayOneShot (takeDamageAudioClip);
			}

            if (controller) {
                Hashtable hashtable = new Hashtable ();
                hashtable.Add ("HealthPoints", health);
                hashtable.Add ("HealthPointsDecreased", damageToTake);

                controller.TriggerEvent ("Health:Decreased", hashtable);
            }
        }

        public virtual void RecoverHealth(int healthPoints) {
            health += healthPoints;

            if (health > maxHealth) {
                health = maxHealth;
            }

            if (audioSource && recoverHealthAudioClip) {
                audioSource.PlayOneShot (recoverHealthAudioClip);
            }

            if (controller) {
                Hashtable hashtable = new Hashtable ();
                hashtable.Add ("HealthPoints", health);
                hashtable.Add ("HealthPointsIncreased", healthPoints);

                controller.TriggerEvent ("Health:Increased", hashtable);
            }
        }
    }
}


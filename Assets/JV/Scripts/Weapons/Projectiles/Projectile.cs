using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JV {
    public class Projectile : MonoBehaviour {
        public float speed = 10f;
        public float rotationSpeed;
        public float lifeTime = 1f;

        protected Rigidbody2D rigidbody;

        public GameObject enemyDeathEffect;
        public GameObject impactEffect;
        public int pointsForKill;
        public int damage = 1;

        PlayerController player;
        float lifeTimeCounter;

        // Use this for initialization
        void Start () {
            player = FindObjectOfType<PlayerController> ();
            rigidbody = GetComponent<Rigidbody2D> ();

            if (player.transform.localScale.x < 0) {
                speed = -speed;
                rotationSpeed = -rotationSpeed;
            }
        }

        public virtual void Update () {
            lifeTime -= Time.deltaTime;

            if (lifeTime <= 0) {
                SelfDestroy ();
            }
        }

        void OnTriggerEnter2D (Collider2D other) {
            if (other.tag == "Enemy") {
                //Instantiate (enemyDeathEffect, other.transform.position, other.transform.rotation);
                //Destroy (other.gameObject);
                //ScoreManager.AddPoints (pointsForKill);

                other.GetComponent<Health> ().TakeDamage (damage);
            }

            SelfDestroy ();
        }

        void SelfDestroy () {
            Instantiate (impactEffect, transform.position, transform.rotation);
            Destroy (gameObject);
        }
    }
}


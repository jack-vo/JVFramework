using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JV {
    public class PlayerHealth : Health {

        public static int playerHealth;

        public override void Start () {
            base.Start ();

            NotifyHealthChanged ();
        }

        public override void Update () {
            if (health <= 0) {
                health = 0;
                NotifyHealthChanged ();
                LevelManager.Instance.RespawnPlayer ();
            }
        }

        public override void TakeDamage (int damageToTake) {
            base.TakeDamage (damageToTake);
            NotifyHealthChanged ();
        }

        public override void RecoverHealth (int healthPoints) {
            base.RecoverHealth (healthPoints);
            NotifyHealthChanged ();
        }

        public void FullHealth () {
            health = maxHealth;
            NotifyHealthChanged ();
        }

        private void NotifyHealthChanged () {
            playerHealth = health;
        }
    }
}


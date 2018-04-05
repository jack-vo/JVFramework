using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JV {
    public class EnemyHealth : Health {

        public int pointsOnDeath = 500;

        // Update is called once per frame
        public override void Update () {
            base.Update ();

            if (health <= 0) {
                ScoreManager.AddPoints (pointsOnDeath);
            }
        }
    }
}


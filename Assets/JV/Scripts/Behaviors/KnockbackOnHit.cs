using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace JV {
    public class KnockbackOnHit : BaseBehavior {
        public float knockback = 1f;
        public float knockbackLength;
        public float knockbackCount;
        public bool knockbackRight;

        UnityAction<Hashtable> healthDecreasedEvent;

        public override void Start () {
            base.Start ();

            healthDecreasedEvent = new UnityAction<Hashtable> (OnHealthDecreased);

            controller.StartListening ("Health:Decreased", healthDecreasedEvent);
        }

        void OnHealthDecreased(Hashtable eventData) {
            Debug.Log ("Knock back");
            if (knockbackRight) {
                controller.Move (new Vector2 (-knockback, knockback));
            } else {
                controller.Move (new Vector2 (knockback, knockback));
            }
        }

        public override void UpdateBehavior () {
            
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JV {
    public abstract class BaseEffect : MonoBehaviour {
        public bool effectEnabled;

        protected bool isMoving;

        Vector3 oldPosition;

        void Start () {
            isMoving = false;
            oldPosition = transform.position;
        }

        // Update is called once per frame
        void Update () {
            if (effectEnabled) {
                UpdateEffect ();
            }

            Vector3 currentPosition = transform.position;

            if (oldPosition.x != currentPosition.x || oldPosition.y != currentPosition.y) {
                isMoving = true;
            } else {
                isMoving = false;
            }

            oldPosition = transform.position;
        }

        public abstract void UpdateEffect ();
    }
}


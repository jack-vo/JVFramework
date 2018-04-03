﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JV {
    public abstract class BaseBehavior : MonoBehaviour {

        protected Controller2D controller;

        // Use this for initialization
        public virtual void Start () {
            controller = GetComponent<Controller2D> ();
        }

        public virtual void Update () {
            if (!controller.enabled) {
                return;
            }

            UpdateBehavior ();
        }

        public abstract void UpdateBehavior ();

        public Vector2 Velocity {
            get {
                return controller.Velocity;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JV {
    public class DestroyFinishedParticle : MonoBehaviour {

        ParticleSystem particleSystem;

        void Start () {
            particleSystem = GetComponent<ParticleSystem> ();
        }

        void Update () {
            if (particleSystem.isPlaying) {
                return;
            }

            Destroy (gameObject);
        }

        void OnBecameInvisible () {
            Destroy (gameObject);
        }
    }
}


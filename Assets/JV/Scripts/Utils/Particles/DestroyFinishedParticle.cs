using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JV {
    public class DestroyFinishedParticle : MonoBehaviour {

        ParticleSystem particle;

        void Start () {
            particle = GetComponent<ParticleSystem> ();
        }

        void Update () {
            if (particle.isPlaying) {
                return;
            }

            Destroy (gameObject);
        }

        void OnBecameInvisible () {
            Destroy (gameObject);
        }
    }
}


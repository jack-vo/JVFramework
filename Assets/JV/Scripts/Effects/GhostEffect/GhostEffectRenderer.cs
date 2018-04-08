using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JV {
    public class GhostEffectRenderer : MonoBehaviour {

        float lifeTime = 1f;

        public void Init (SpriteRenderer referenceSpriteRenderer, Transform targetTransform, Color color, float lifeTime = 1f) {
            this.lifeTime = lifeTime;

            transform.position = targetTransform.position;
            transform.localScale = targetTransform.localScale;

            SpriteRenderer sprite = GetComponent<SpriteRenderer> ();

            sprite.sprite = referenceSpriteRenderer.sprite;
            sprite.color = color;
        }

        // Update is called once per frame
        void Update () {
            lifeTime -= Time.deltaTime;

            if (lifeTime <= 0) {
                Destroy (gameObject);
            }
        }
    }
}

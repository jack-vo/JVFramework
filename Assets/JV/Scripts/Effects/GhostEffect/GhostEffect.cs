using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JV {
    public class GhostEffect : BaseEffect {
        public float maxNumberOfGhostSprites = 5;
        public float timeBetweenEachGhost = 0.2f;
        public float lifeTime = 1f;
        public Color color = new Color(50f, 50f, 50f, .5f);

        // do not override this Prefabs if not necesasry
        public GameObject Renderer;

        float visibleGhosts;
        float ghostCreationCoolDown;

        public override void UpdateEffect () {
            if (isMoving &&
                visibleGhosts < maxNumberOfGhostSprites &&
                (ghostCreationCoolDown == 0 || ghostCreationCoolDown >= timeBetweenEachGhost) ) {
                StartCoroutine ("CreateGhost");
            }

            ghostCreationCoolDown += Time.deltaTime;

            if (ghostCreationCoolDown >= timeBetweenEachGhost) {
                ghostCreationCoolDown = 0;
            }
        }

        IEnumerator CreateGhost () {
            visibleGhosts++;

            GameObject renderer = Instantiate (Renderer, transform.position, transform.rotation);
            renderer
                .GetComponent<GhostEffectRenderer> ()
                .Init (GetComponent<SpriteRenderer> (), transform, color, lifeTime);

            yield return new WaitForSeconds (lifeTime);
            visibleGhosts--;
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JV {
    public class EnemyPatrol : BaseBehavior {

        public float moveSpeed = 3f;
        public bool moveRight;

        public override void UpdateBehavior () {
            if (controller.agentInfo.hittingWall || controller.agentInfo.atEdge) {
                moveRight = !moveRight;
            }

            Vector3 _localScale = controller.transform.localScale;

            if (moveRight) {
                controller.Move (new Vector2 (moveSpeed, Velocity.y));
                controller.transform.localScale = new Vector3 (-1f, _localScale.y, _localScale.z);
            } else {
                controller.Move (new Vector2 (-moveSpeed, Velocity.y));
                controller.transform.localScale = new Vector3 (1f, _localScale.y, _localScale.z);
            }
        }
    }                                                           
}


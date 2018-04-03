using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JV {
    public class Jump : BaseBehavior {
        public float jumpHeight = 20;
        public float minJumpHeight = 10;
        public int airborneJumpCount = 1;

        [Range (.1f, 1f)]
        public float airborneJumpHeight = .8f;

        public float fallMultiplier = 2.5f;
        public float lowJumpMultiplier = 2f;


        float currentJumpHeight = 0;
        int currentNumberAirborneJump = 0;

        public override void UpdateBehavior () {
            Vector2 newVelocity = Velocity;
            bool grounded = controller.agentInfo.grounded;

            if (grounded) {
                currentNumberAirborneJump = 0;
            }

            controller.anim.SetBool ("Grounded", grounded);

            if (Input.GetButtonDown ("jump")) {
                if (grounded) {
                    currentJumpHeight = minJumpHeight;
                    newVelocity.y = minJumpHeight;
                    controller.Move (newVelocity);
                } else if (currentNumberAirborneJump < airborneJumpCount) {
                    newVelocity.y = airborneJumpHeight * jumpHeight;
                    currentNumberAirborneJump++;
                    controller.Move (newVelocity);
                }
            }

            if (Input.GetButtonUp ("jump") || currentJumpHeight >= jumpHeight) {
                currentJumpHeight = 0;
            }

            if (currentJumpHeight > 0) {
                currentJumpHeight += 1;
                newVelocity.y = currentJumpHeight;
                controller.Move (newVelocity);
            }
        }
    }
}


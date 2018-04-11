using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JV {
    public class HandleMeleeWeapon : BaseBehavior {

		public override void UpdateBehavior () {
            if (controller.anim.GetBool("Melee")) {
                controller.anim.SetBool ("Melee", false);
            }

            if (Input.GetButtonDown("melee")) {
                controller.anim.SetBool ("Melee", true);
            }
		}
	}

}

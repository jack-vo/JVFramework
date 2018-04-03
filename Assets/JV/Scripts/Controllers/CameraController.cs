using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JV {
    public class CameraController : MonoBehaviour {

        private Controller2D player;
        public bool isFollowing;

        public float xOffset;
        public float yOffset;

        // Use this for initialization
        void Start () {
            player = FindObjectOfType<PlayerController> ();

            isFollowing = true;
        }

        // Update is called once per frame
        void Update () {
            Vector3 playerPosition = player.transform.position;

            if (isFollowing) {
                transform.position = new Vector3 (playerPosition.x + xOffset, playerPosition.y + yOffset, transform.position.z);
            }
        }
    }
}


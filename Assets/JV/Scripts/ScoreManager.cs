﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JV {
    public class ScoreManager : MonoBehaviour {

        public static int score;

        // Use this for initialization
        void Start () {
            score = 0;
        }

        // Update is called once per frame
        void Update () {
            if (score < 0) {
                score = 0;
            }
        }

        public static void AddPoints (int pointsToAdd) {
            score += pointsToAdd;
        }

        public static void Reset () {
            score = 0;
        }
    }
}

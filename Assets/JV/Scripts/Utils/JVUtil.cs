using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JVUtil : MonoBehaviour {
    public static bool AboutEqual (float x, float y) {
        double epsilon = Mathf.Max (Mathf.Abs (x), Mathf.Abs (y)) * 1E-15;

        return Mathf.Abs (x - y) <= epsilon;
    }

    public static bool IsTargetOnTheLeft (Transform target, Transform destination) {
        return target.position.x < destination.position.x;
    }
}

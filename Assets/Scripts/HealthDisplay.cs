using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using JV;

public class HealthDisplay : MonoBehaviour {

    private Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text> ();
        text.text = "" + PlayerHealth.playerHealth;
	}

    void Update () {
        text.text = "" + PlayerHealth.playerHealth;
    }
}

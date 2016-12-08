using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyController : MonoBehaviour {

    private int pullTimer;
	// Use this for initialization
	void Start () {
        pullTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        pullTimer++;

        if(pullTimer > 1000)
        {
            pullTimer = 0;


        }
	}
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Camera.main.projectionMatrix = Matrix4x4.Ortho(-5.0f * 1.6f, 5.0f * 1.6f, -5.0f, 0.5f, 0.3f, 1000f);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

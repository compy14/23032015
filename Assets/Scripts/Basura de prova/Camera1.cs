﻿using UnityEngine;
using System.Collections;

public class Camera1 : MonoBehaviour {
	
	Transform player;
	
	float offsetX;
	
	// Use this for initialization
	void Start () {
		
		GameObject player_go = GameObject.FindGameObjectWithTag("Player");
		
		if (player_go == null) {
			Debug.LogError ("No va" );
			return;
			
		}
		player = player_go.transform;
		
		offsetX = transform.position.x - player.position.x;
	}
	// Update is called once per frame
	void Update () {
		if (player != null) { //per si mor el personatge
			Vector3 pos = transform.position;//la meva posicio
			pos.x = player.position.x + offsetX;
			transform.position = pos;
		}
	}
}

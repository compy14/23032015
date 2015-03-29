using UnityEngine;
using System.Collections;

public class grab : MonoBehaviour {

	public bool agafat;
	// Use this for initialization
	void Start () {
		agafat = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D coll) {
		if (coll.gameObject.name == "Grabobject") {
			if (Input.GetKeyUp (KeyCode.E)){

				agafat = true;
				Debug.Log ("entra a dins, eso dijo ella");
			}
			else {agafat = false;}
		
		}

	}
}

using UnityEngine;
using System.Collections;

public class caure : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionStay2D(Collision2D other){//per detectar la plataforma si entra en col·lisio amb un fa alguna cosa
		if(other.gameObject.tag == "Player"){
			Physics2D.gravity = new Vector3(0, -1.0F, 0);
			Debug.LogError ("funciona");
		}
		
	}

}

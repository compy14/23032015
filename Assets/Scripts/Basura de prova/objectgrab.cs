using UnityEngine;
using System.Collections;

public class objectgrab : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


	}

	void OnCollisionStay2D (Collision2D coll){
		if (coll.gameObject.tag == "Aki") {
			Debug.Log ("funciona");
			Player p = GameObject.Find("Player").GetComponent<Player>();
			if (p.agafat){
				//posicio personatge
				transform.parent = p.transform;
				Debug.Log ("entra a dins");
			}
			else if (!p.agafat){
				//perd posiciio personatge
				transform.parent = null;
				Debug.Log ("no entra dins");
			}
		}
	}
}

using UnityEngine;
using System.Collections;

public class seguimentplayer : MonoBehaviour {
	public GameObject target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
			transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
		}
	}
}

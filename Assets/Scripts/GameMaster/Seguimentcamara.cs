using UnityEngine;
using System.Collections;

public class Seguimentcamara : MonoBehaviour {	
	public GameObject target;
	public float separacionx = 4.0f;
	public float separacionz = -1f;
	public bool isfollowing=true;
	
	// Update is called once per frame
	void Update () {
		if (isfollowing) {
			if (target == null) {
				GameObject go = GameObject.Find("Startpoint");
				transform.position=go.transform.position;
			}
			else transform.position = new Vector3(target.transform.position.x+separacionx, target.transform.position.y+0.75f, target.transform.position.z+separacionz);
		}
		Player p = (Player)target.GetComponent("Player");
		if(p.IsDead){
			audio.Play();
		}

	}
}

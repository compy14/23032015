using UnityEngine;
using System.Collections;

public class vida : MonoBehaviour {
	public AudioClip clip;

	public int EnemyHealth;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerStay2D(Collider2D other){//per detectar quan se surt d'aquest objecte
		
		if(other.gameObject.tag == "Aki"){
			AudioSource.PlayClipAtPoint(clip, transform.position, 0.6f);
			Destroy (this.gameObject);
			
		}

	}
}

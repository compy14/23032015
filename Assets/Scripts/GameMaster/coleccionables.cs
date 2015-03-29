using UnityEngine;
using System.Collections;

public class coleccionables : MonoBehaviour {
	public AudioClip clip;
	public LvlManager lvlman;
	public int gemPoints=10;
	// Use this for initialization
	void Start () {
		lvlman = GameObject.Find("LvlManager").GetComponent<LvlManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other){
		
		if(other.tag == "Aki"){

			AudioSource.PlayClipAtPoint(clip, transform.position, 1f);
			//audio.Play();
			lvlman.AddPoints (gemPoints);
			Destroy (this.gameObject);
		}	
	}
}
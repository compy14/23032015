using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {
	public float timer = 1f;
	private Animator _anim;
	// Use this for initialization
	void Start () {
		_anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;

		if(timer <=0){
			Destroy(gameObject);
		}
	}
	void OnTriggerEnter2D(Collider2D other) {//TOTA AQUESTS SEGUITS DE IF ES PER A QUE ES DESTRUEIXIN LES BALES
		if(other.gameObject.tag == "Enemy"){
			_anim.SetBool ("explosion", true);
		}	
		if(other.gameObject.tag == "Ground"){
			_anim.SetBool ("explosion", true);
		}	
	}
	void OnTriggerStay2D(Collider2D other) {
		if(other.gameObject.tag == "Enemy"){
			Destroy(gameObject);
			_anim.SetBool ("explosion", false);
		}	
		if(other.gameObject.tag == "Ground"){
			Destroy(gameObject);
			_anim.SetBool ("explosion", false);
		}	
	}


}

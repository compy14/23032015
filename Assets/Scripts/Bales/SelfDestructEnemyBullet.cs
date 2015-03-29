using UnityEngine;
using System.Collections;

public class SelfDestructEnemyBullet : MonoBehaviour {
	public float timer = 30f;
	public Animator _anim;
	
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

	void desactivaranmi(){
		_anim.SetBool("estatic",true);

	}
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.name == "GrassWall") {
			Destroy(gameObject);
		}
	}
}

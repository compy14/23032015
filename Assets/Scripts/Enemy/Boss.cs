using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour{
	
	public int EnemyHealth;
	private Rigidbody2D _myRigidbody;
	private Animator _anim;
	private bool _facingRight = true;
	public float speed;
	private float move = 3.5f;
	protected float count;
	
	// Use this for initialization
	void Start (){
		
		/*_myRigidbody = this.rigidbody2D;
		_anim = GetComponent<Animator>();*/
	}
	
	// Update is called once per frame
	void Update (){
		
	}
	
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.name == "Bullet(Clone)") {	//PER DETECTAR LES BALES DEL JUGADOR I QUE LI RESTI VIDA				
			BossHealth eh = (BossHealth)gameObject.GetComponent ("BossHealt");
			eh.AddjustCurrentHealth (-5);
		}
	}
}
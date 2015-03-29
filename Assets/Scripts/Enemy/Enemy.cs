using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour{

	public int EnemyHealth;
	private Rigidbody2D _myRigidbody;
	private Animator _anim;
	private bool _facingRight = true;
	public float speed;
	private float move = 3.5f;
	protected float count;

	// Use this for initialization
	void Start (){
		
		_myRigidbody = this.rigidbody2D;
		_anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update (){
		 //definir la variable que quan apretis per moure es mogui horitzontalment
		_anim.SetFloat ("Speed", Mathf.Abs(move));
		count = count +	(Mathf.Abs (move*speed));
		_myRigidbody.velocity = new Vector2 (move*speed, _myRigidbody.velocity.y);//establir la veocitat de x i y

		if(_facingRight == true  && count > 150){
			count = 0;
			move=-2;
			_facingRight = false;
			transform.rotation=Quaternion.Euler (transform.rotation.x,180,transform.rotation.z);
		}

		else if (_facingRight == false  && count > 150) {
			count = 0;
			move=2;
			_facingRight= true;
			transform.rotation=Quaternion.Euler (transform.rotation.x,0,transform.rotation.z);
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
			if (coll.gameObject.name == "Bullet(Clone)") {	//PER DETECTAR LES BALES DEL JUGADOR I QUE LI RESTI VIDA				
					EnemyHealth eh = (EnemyHealth)gameObject.GetComponent ("EnemyHealth");
					eh.AddjustCurrentHealth (-5);
			}
	}
}
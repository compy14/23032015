using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {
	public GameObject target;
	public int PlayerHealth;
	public Animator _anim;
	public float attackTimer;
	public float Timers;
	public float coolDown;
	public Health health;
	public int vida=10;
	public float deteccio;
	//public GameObject personatge;

	private bool  temps = false;
	private float distance;
	// Use this for initialization
	void Start () {
		_anim = GetComponent<Animator>(); //agafa la variable(???) i la guarda a _anim
		Timers = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {

			if(attackTimer>0) attackTimer -= Time.deltaTime;
			if(attackTimer<0) attackTimer =0;
			if (Vector2.Distance(transform.position,target.transform.position)<deteccio) {	
				if(attackTimer == 0){
				    Attack();
					attackTimer=coolDown;
				}

			}
			if(attackTimer==0){Desactivar ();}
		}

	/*	if(Vector2.Distance(transform.position,personatge.transform.position)>32f) {    
			Player p = (Player)personatge.GetComponent("Player");
			p._anim.SetBool("mal", false);
		}
*/

	}
	void Attack(){
	
		//activa el canvi de sprite "PunchNow"
		//p._anim.SetBool("mal", false);

		float distance = Vector3.Distance (target.transform.position, transform.position); //calcula la distancia del jugador al target
		Vector2 dir = (target.transform.position - transform.position).normalized; 
		float direction = Vector2.Dot (dir, transform.right); //calcula si el jugador esta mirant al target, si es positiu l'esta mirant sino es negatiu
		if (distance < deteccio){ //PERMET AJUSTAR LA DISTANCIA A LA QUE ATAQUEN ELS MONSTRES, ABANS 0.5
			if (direction<0){//s'haura de canviar el sprite i girar 180 graus, abans amb distance > 0
					_anim.SetBool ("PunchNow", true); 
					Player p = (Player)target.GetComponent("Player");
					p._anim.SetBool("mal", false);
					
				}			
			}

		}

	void Desactivar(){

		Player p2 = (Player)target.GetComponent("Player");
		//p2._anim.SetBool("mal", false);
	}

	/*void OnCollisionEnter2D (Collision2D coll){

		if(coll.gameObject.tag=="Aki"){
			Player p2 = (Player)target.GetComponent("Player");
			p2._anim.SetBool("mal", true);
			//Debug.Log ("funciona");
		}
	}*/
	/*void OnCollisionExit2D (Collision2D coll){
		
		if(coll.gameObject.tag=="Aki"){
			Player p2 = (Player)target.GetComponent("Player");
			p2._anim.SetBool("mal", false);
		}
	}*/
	void mal (){
		
		float distance = Vector3.Distance (target.transform.position, transform.position); //calcula la distancia del jugador al target
		Vector2 dir = (target.transform.position - transform.position).normalized; 
		float direction = Vector2.Dot (dir, transform.right); //calcula si el jugador esta mirant al target, si es positiu l'esta mirant sino es negatiu
		if (distance < deteccio){ //PERMET AJUSTAR LA DISTANCIA A LA QUE ATAQUEN ELS MONSTRES, ABANS 0.5
			if (direction<0){

			Health h = GameObject.Find("Health").GetComponent<Health>();
			h.modifyHealth(-100);
			Player p = (Player)target.GetComponent("Player");
			p._anim.SetBool("mal", true);
			}
		}


	}
	void Desactivaranim (){
		_anim.SetBool ("PunchNow", false);
		Player p = (Player)target.GetComponent("Player");
		p.transform.Translate(0, +0.2f, 0);
	

	}
}


using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public int maxhealth=100; // la vida maxima
	public float curhealth=100; // vida actual
	private Animator _anim;
	public Texture death;
	public Health health;
	public GameObject target;
	private GameObject pl;
	public GameObject h;
	public float healthbarlenght;
	private bool mort;
	// Use this for initialization
	void Start () {
		healthbarlenght = Screen.width / 2;
		_anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		AddjustCurrentHealth (0); //crida la funcio que recalcula la mida de la barra i la vida actual
		if(curhealth<=0){
			//respawn();
			//mort del jugador
		//	_anim.SetBool("mort", true);



		}
	}

	void OnGUI(){
		if(mort){
		GUI.DrawTexture(new Rect(Screen.width/5, Screen.height/18, Screen.height, Screen.height), death, ScaleMode.ScaleToFit, true);
		}
		//GUI.Box (new Rect (10, 10, healthbarlenght, 20), curhealth + "/" + maxhealth);//dibuixa la barra de HP
	}



	public void AddjustCurrentHealth (int adj){	
		curhealth += adj;

		if (curhealth < 0) curhealth = 0; //si el ajust a la vida dona negatiu iguala a 0
		if (curhealth > maxhealth) curhealth = maxhealth; //si el ajust a la vida dona superior a la maxima vida iguala al max
		if (maxhealth < 1) maxhealth = 1;
		healthbarlenght = (Screen.width / 2) * (curhealth/(float)maxhealth);
	}
	void OnCollisionEnter2D(Collision2D other){//per detectar si es cau en algun objecte que et fagi mal
		if(other.gameObject.tag == "Hat"){
			curhealth = curhealth - 10;
			_anim.SetBool ("mal", true);//, PODRIEM FER QUE TIRES ENRRERE AQUI
			Health h = GameObject.Find("Health").GetComponent<Health>();
			h.modifyHealth(-10);
		}

		if(other.gameObject.tag == "MothGoth"){
			curhealth = curhealth - 10;
			_anim.SetBool ("mal", true);//, PODRIEM FER QUE TIRES ENRRERE AQUI
			Health h = GameObject.Find("Health").GetComponent<Health>();
			h.modifyHealth(-100);
		}
		if(other.gameObject.tag == "InstantDeath"){
			_anim.SetBool ("mal", true);//, PODRIEM FER QUE TIRES ENRRERE AQUI
			Health h = GameObject.Find("Health").GetComponent<Health>();
			h.modifyHealth(-10000);
		}


	
		
	}
	void OnCollisionStay2D(Collision2D other){//per detectar quan S'ESTA EN aquest objecte
		if(other.gameObject.tag == "Hat"){
			curhealth = curhealth - 0.1F;
			_anim.SetBool ("mal", true);
			Health h = GameObject.Find("Health").GetComponent<Health>();
			h.modifyHealth(-1);
		}

		
	}
	void OnCollisionExit2D(Collision2D other){//per detectar quan se surt d'aquest objecte
		if(other.gameObject.tag == "Hat"){

		//	_anim.SetBool ("mal", false); //PELS OBJECTES QUE ET FAN MAL
		}

	}
	void OnTriggerEnter2D(Collider2D coll){//per detectar quan s'ENTRA d'aquest objecte

		if(coll.gameObject.tag == "Health"){
			curhealth = curhealth + 10;
			//health.modifyHealth(10);
			//h = GetComponent<Health>();
			Health h = GameObject.Find("Health").GetComponent<Health>();
			h.modifyHealth(100);
		
			//PELS OBJECTES DE CURACIO 

		}
		if(coll.gameObject.name == "Fantasma"){
			Health h = GameObject.Find("Health").GetComponent<Health>();
			h.modifyHealth(-20);
			_anim.SetBool ("mal", true);
		}
		if(coll.gameObject.name == "Serpentier"){
			Health h = GameObject.Find("Health").GetComponent<Health>();
			h.modifyHealth(-20);
			_anim.SetBool ("mal", true);
		}
	/*	if (coll.gameObject.name == "Enemic_Intocable") {	
			curhealth = curhealth - 10;
			_anim.SetBool ("mal", true);
			Health h = GameObject.Find("Health").GetComponent<Health>();
			h.modifyHealth(-100);
		}
		*/
	}
	void OnTriggerStay2D(Collider2D coll){//per detectar quan s'ENTRA d'aquest objecte
		
		if(coll.gameObject.name == "Fantasma"){
			Health h = GameObject.Find("Health").GetComponent<Health>();
			h.modifyHealth(-1);
			_anim.SetBool ("mal", true);
		}
		if(coll.gameObject.name == "Serpentier"){
			Health h = GameObject.Find("Health").GetComponent<Health>();
			h.modifyHealth(-1);
			_anim.SetBool ("mal", true);
		}
		
	}
	void OnTriggerExit2D(Collider2D coll){//per detectar quan s'ENTRA d'aquest objecte
		
		/*if (coll.gameObject.name == "Enemic_Intocable") {	
			
			//_anim.SetBool ("mal", false);
		}*/
		
	}

	void youredeath () {

		mort = true;
	}
	void yourealive (){

		mort =false;

	}
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour{
		public AudioClip clip;
		public AudioClip death;
		private CharacterController _controller;
		private GameMaster gm;
		private Checkpoint ch;
		private Rigidbody2D _myRigidbody;
		private float Timer;	
		private float Timerviscos;
		private float Timerveri;
		public bool _facingRight;
		private bool flag;
		private int cont;
		private bool quiet=false;
		private float tempsmal = 0f;
		private float timeranim = 0f;
		private bool tocat= false;	
		private bool climb=false;
		private bool viscos;
		private bool veri;
		private bool landing;
		private float contador; //per al veri de la serp
		public List<Transform> serps;
		
		private Transform myTransform;
		public bool IsDead { get; private set;}
		public GameObject personatge;
		public GameObject p_trans;
		public int notrans;
		public Animator _anim;
		public float speed;
		public Transform grounder;
		public Transform electric;
		public Transform isbucleviril;
		public float radiuss;
		public LayerMask ground;
		public bool isGrounded = false;
		public bool isbucle = false;
		public Transform platform;
		public float timer = 0.1f;
		public bool agafat;
		float timebarrido=0.5f;
		
		void awake(){
			
		}



		// Use this for initialization
		void Start ()
		{
			contador=1;
			myTransform = transform;
			GameObject[] go5 = GameObject.FindGameObjectsWithTag ("Serp");
			foreach (GameObject enemy in go5)
			AddTarget (enemy.transform);
			gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();
			if(gm.DebugSpawn!= null){
				ch = GameObject.Find ("DebugSpawn").GetComponent<Checkpoint> ();
			}
			else{
				ch = GameObject.Find ("Startpoint").GetComponent<Checkpoint> ();
			}
			_myRigidbody = this.rigidbody2D;
			_anim = GetComponent<Animator>();
			agafat = false;
			Timer = 0.5f;
			notrans = 0;	
			p_trans = ch._pc_trans;
			personatge = ch._pc;
			SortTargetsByDistance();
			viscos = false;
			Timerviscos=0;
			landing = true;
	}
	
		// Update is called once per frame
		void Update ()
		{	
			if(IsDead) transform.parent = null;
			if(timeranim>0) timeranim -= Time.deltaTime;
			if(timeranim<0) timeranim =0;
			if(Timerviscos>0) Timerviscos -= Time.deltaTime;
			if(Timerviscos<0) Timerviscos =0;
			if(Timerviscos == 0){// calcula el temps que l'animacio de mal esta activa
				viscos=false;

			}
			if(Timerveri>0) Timerveri -= Time.deltaTime;
			if(Timerveri<0) Timerveri =0;
			
			//part del codi que mira en quina posicio/transformacio esta el personatge.
			if(personatge!=null){
				if(personatge.activeInHierarchy==true){
					if (personatge.transform.rotation.y == 0)
						_facingRight = true;
					if (personatge.transform.rotation.y == 1)
						_facingRight = false;
				}
				if(personatge.activeInHierarchy==false){
					if (p_trans.transform.rotation.y == 0)
						_facingRight = true;
					if (p_trans.transform.rotation.y == 1)
						_facingRight = false;
				}
			}

			if(isGrounded){
				climb=false;
			}
			
			if(personatge!=null){
				if(personatge.activeInHierarchy==true) notrans=0;
				if(personatge.activeInHierarchy==false) notrans=1;
			}
			//fi dels checks
			if(IsDead){
				_anim.SetBool("mal", false);
				_anim.SetBool("Jump", false);
				_anim.SetFloat("Speed", 0);
			}
			if(!IsDead){
					if(veri) {
						if(Timerveri==0){
							Health h = GameObject.Find("Health").GetComponent<Health>();
							h.modifyHealth(-5);
							transform.Translate(0, -0.1f, 0);
							Timerveri=1;
							contador++;
						}
						if(contador==10){
							veri=false;
							contador=1;
						}
					}
					float move = Input.GetAxisRaw("Horizontal");
	
					
					if(viscos==true){
						move=move/3;

					}
					if(_anim.GetBool("PunchRun") == true){
						move=move*1.4f;
					}
					if(_anim.GetBool ("PunchJump")==true){
						_anim.SetFloat ("Speed", 0);
					}
					else{
						_anim.SetFloat ("Speed", Mathf.Abs(move));
					}
					
					if(isGrounded){
						_anim.SetBool ("PunchJump", false);
						_anim.SetBool ("Climb", false);
					}
					if(!quiet){
						 //definir la variable que quan apretis per moure es mogui horitzontalment
						
						//if(!Input.GetButton("Fire1")) {
							//_anim.SetBool ("Jump", false);
						_myRigidbody.velocity = new Vector2 (move*speed, _myRigidbody.velocity.y);
					}	//establir la veocitat de x i y
					//}
					if(_facingRight == true && move < 0){ //tot aquest codi es per a que el personatge es mogui cap a la dreta i a l'esquerra i roti 180 graus
						transform.rotation=Quaternion.Euler (transform.rotation.x,180,transform.rotation.z);
						}
					else if (_facingRight == false && move > 0) {
						transform.rotation=Quaternion.Euler (transform.rotation.x,0,transform.rotation.z);
						}
					// aqui fem una rodona, amb overlapcircle, que al colisionar amb el terra fica a true la variable is grounded i junt si apreten espai el personatge salti
					//llavors amb la linia de punch now == false fa que s'activi l'animacio, aixo es fa sobretot pel salt + atac
					isGrounded = Physics2D.OverlapCircle (grounder.transform.position, radiuss, ground);
					isbucle = Physics2D.OverlapCircle (isbucleviril.transform.position, radiuss*2, ground);
					if (_anim.GetBool ("PunchJump")==false && !climb ){//linia que fa que nomes es fagi l'animacio de salt si hi ha el punch desactivat, per veure l'atac en el salt
						_anim.SetBool ("Jump", !isGrounded);
						}
					if(climb){
						_anim.SetBool ("Jump", false);
						_anim.SetFloat ("Speed", 0);
					}	
					if(isGrounded){
						if(landing){
							GameObject land = Resources.Load("landing") as GameObject;
							Instantiate(land, grounder.transform.position, grounder.transform.rotation);
							landing=false;
						}
					}
					if(!isGrounded)landing=true;
					//per a que si fa alguna cosa el salt sigui false, TOT AQUEST SEGUIT DE CONDICIONS ESTAN FETES JA QUE ERA LA UNICA MANERA QUE NO ES CLAVES DE TANT EN TANT
					if(_anim.GetBool ("Shoot") == true || _anim.GetBool ("PunchNow") == true || _anim.GetBool ("mal") == true || _anim.GetBool ("Climb") == true){
						_anim.SetBool ("Jump", false);
					
					}
					if(isbucle == true && _anim.GetBool("Jump")==true){ //linies de codi que serveixen per evitar que el personatge entri en bucle 
						//Debug.Log ("entra mes a fons");
						_myRigidbody.velocity = new Vector2 (0, _myRigidbody.velocity.y-0.01f);
						
					}
					if(_anim.GetBool ("mal")==true ){
						_anim.SetBool ("PunchRun", false);
					}
					if(Input.GetKeyDown (KeyCode.Space) && isGrounded == true)//si el jugador apreta espai pot saltar amunt
					{
						if(_anim.GetBool ("mal")==false ){
							if(viscos==false){
								_myRigidbody.velocity = new Vector2(_myRigidbody.velocity.x,9.5f);
							}
							else if(viscos==true){//fem que si esta viscos es limiti el salt
								_myRigidbody.velocity = new Vector2(_myRigidbody.velocity.x,8f);	
							} 
						}

					}
					if (Input.GetKeyUp (KeyCode.R) && notrans == 1) {
						p_trans.SetActive(false);//aixo es el que fa que transformi d'un model a un altre
						personatge.transform.position = p_trans.transform.position;
						personatge.transform.rotation = p_trans.transform.rotation;
						personatge.SetActive(true);
					}
					else if (Input.GetKeyUp (KeyCode.R) && notrans == 0) {
						personatge.SetActive (false);
						p_trans.transform.position = personatge.transform.position;
						p_trans.transform.rotation = personatge.transform.rotation;
						p_trans.SetActive (true);
					}

					if (_anim.GetBool ("mal") == true){//per a quan et fan mal que es desactivi la puta animacio
						if(Timer>0) Timer -= Time.deltaTime;
						if(Timer<0) Timer =0;
						if(Timer == 0){// calcula el temps que l'animacio de mal esta activa
							_anim.SetBool ("mal", false);
							Timer = 0.5f;
						}

					}
					if (Input.GetKeyDown (KeyCode.E)){
						
						agafat = true;
						Debug.Log ("funciona l'sgaafs");
					}
					else {agafat = false;
					}
		}

	}
		void OnCollisionEnter2D(Collision2D other){//per detectar la plataforma si entra en col·lisio amb un fa alguna cosa
			if(other.gameObject.tag == "Platform"){
				transform.parent = other.transform;
			}

		
		}

		void OnCollisionExit2D(Collision2D other){
			if(other.gameObject.tag == "Platform"){//per quan surtis de la plataforma no es mantingui la posicio de la plataforma
				transform.parent = null;
			}

			if(other.gameObject.tag == "Ladder"){
				_anim.SetBool ("Climb", false);
			}

		}

		void OnTriggerEnter2D(Collider2D coll){

			if (coll.gameObject.name == "BulletSerpentier(Clone)") {	//quan entri amb contacte amb les bales dels monstres aquest li treguin vida	
				GameObject go = Resources.Load("veri") as GameObject;
				Health h = GameObject.Find("Health").GetComponent<Health>();
				h.modifyHealth(-20);
				serps.Clear();
				GameObject[] go5 = GameObject.FindGameObjectsWithTag ("Serp");
				foreach (GameObject enemy in go5)
				AddTarget (enemy.transform);
				SortTargetsByDistance();
				_anim.SetBool ("mal", true);
				//Debug.Log (serps);
				SortTargetsByDistance();
				Serp ser = serps[0].GetComponent<Serp>();
				if(Timerveri==0){
					Instantiate(go, transform.position, transform.rotation);
				}
				if(ser.right==true){
					if(_facingRight){
						transform.Translate(+0.3f, 0, 0);
					}
					else{
						transform.Translate(-0.3f, 0, 0);
					}
				}
				else {
					if(_facingRight){
						transform.Translate(-0.3f, 0, 0);
					}
					else{
						transform.Translate(+0.3f, 0, 0);
					}
				}
				veri= true;
				Timerveri=1f;
				Destroy(coll.gameObject);
			}


			if (coll.gameObject.name == "BulleteStalactopus(Clone)") {	//quan entri amb contacte amb les bales dels monstres aquest li treguin vida				
				Health h = GameObject.Find("Health").GetComponent<Health>();
				h.modifyHealth(-50);
				_anim.SetBool ("mal", true);
				//	Instantiate(bloodPrefab, bloodPoint.transform.position, bloodPoint.transform.rotation);
				transform.Translate(0, +0.2f, 0);
				viscos=true;
				Timerviscos = 3f;
				Destroy(coll.gameObject);
			}
			if (coll.gameObject.name == "BulleteyeGear(Clone)") {	//quan entri amb contacte amb les bales dels monstres aquest li treguin vida				
				Health h = GameObject.Find("Health").GetComponent<Health>();
				h.modifyHealth(-50);
				_anim.SetBool ("mal", true);
				GameObject elec = Resources.Load("electricity") as GameObject;
				Instantiate(elec, electric.transform.position, electric.transform.rotation);
				//	Instantiate(bloodPrefab, bloodPoint.transform.position, bloodPoint.transform.rotation);	
				transform.Translate(0, +0.2f, 0);
				Destroy(coll.gameObject);
			}
			if (coll.gameObject.name == "BulletCano(Clone)") {	//quan entri amb contacte amb les bales dels monstres aquest li treguin vida				
				Health h = GameObject.Find("Health").GetComponent<Health>();
				h.modifyHealth(-50);
				transform.Translate(0, -0.2f, 0);
				if(_anim.GetBool("Climb")==false){

					_anim.SetBool ("mal",true);
				}
				Destroy(coll.gameObject);
			}
			if (coll.gameObject.name == "BulletCanoFast(Clone)") {	//quan entri amb contacte amb les bales dels monstres aquest li treguin vida				
				Health h = GameObject.Find("Health").GetComponent<Health>();
				h.modifyHealth(-50);
				transform.Translate(0, -0.02f, 0);
				if(_anim.GetBool("Climb")==false){
					
					_anim.SetBool ("mal",true);
				}
				Destroy(coll.gameObject);
			}

			if (coll.gameObject.name == "BulletCanoMiddle(Clone)") {	//quan entri amb contacte amb les bales dels monstres aquest li treguin vida				
				Health h = GameObject.Find("Health").GetComponent<Health>();
				h.modifyHealth(-50);
				transform.Translate(0, -0.02f, 0);
				if(_anim.GetBool("Climb")==false){
					
					_anim.SetBool ("mal",true);
				}
				Destroy(coll.gameObject);
			}
				
				
		if (coll.gameObject.name == "Power(Clone)") {	//quan entri amb contacte amb les bales dels monstres aquest li treguin vida				
				Health h = GameObject.Find("Health").GetComponent<Health>();
				h.modifyHealth(-200);
				transform.parent = coll.transform;
				quiet=true;

                  }
			if (coll.gameObject.name == "Deathpit") { //detecta el nom del objecta amb el cual collisiona si es Deathpit,
				//respawn(gm._checkpoints[gm._currentCheckpointIndex]);
				Health h = GameObject.Find("Health").GetComponent<Health>();
				h.modifyHealth(-1000);// la funcio respawn
			}

		}
		void OnTriggerStay2D(Collider2D coll){//per lo de les escales en entrar en contacte amb elles pots pujar amunt
			if (coll.gameObject.tag == "Ladder") {					
					if(!IsDead){
						float moveup = Input.GetAxisRaw("Vertical");
						//_anim.speed = 1;
							if(Input.GetAxisRaw("Horizontal")!=0){
							_anim.speed = 1;
						
							}
							if(Input.GetAxisRaw("Vertical")!=0){
							timeranim = 0.3f;
							moveup = moveup *3;
							climb=true;
							float estatic = Mathf.Abs(moveup);
							if(_anim.GetBool ("mal")==false){
								_anim.SetBool ("Climb", true);
							}
							_anim.speed=1;
							_myRigidbody.velocity = new Vector2 (_myRigidbody.velocity.x, moveup+0.5f);
						}else if(climb){
							_anim.SetBool("Jump", false);
							moveup=0;
						if(_anim.GetBool("mal")==false && _anim.GetBool ("Climb")==true && _anim.GetBool ("Jump")==false && _anim.GetFloat ("Speed") == 0){
									if(!isGrounded){
										if(timeranim==0){
											_anim.speed=0;
										}
									}
								}
							_anim.SetBool ("Climb", true);
							_myRigidbody.velocity = new Vector2 (_myRigidbody.velocity.x, moveup+0.5f);
						}
				}
				if(IsDead){
					
					_myRigidbody.velocity = new Vector2 (_myRigidbody.velocity.x, -1.5f);
					_anim.SetBool ("Climb", false);
					_anim.SetBool ("mal", false);
					_anim.speed  = 1;
				}


			}
			if (coll.gameObject.name == "Power(Clone)") {	//quan entri amb contacte amb les bales dels monstres aquest li treguin vida				

				quiet=false;
			}
		}
		void OnTriggerExit2D(Collider2D coll){ //quant surt de l'escala
		if (coll.gameObject.tag == "Ladder") {					

			_anim.SetBool ("Climb", false);
			_anim.speed=1;
			climb=false;
			
			}
		if (coll.gameObject.name == "Power(Clone)") {	//quan entri amb contacte amb les bales dels monstres aquest li treguin vida				

				transform.parent = null;
		
				quiet=false;
		 }
	}
	public void Kill(){
		//_controller.detectCollisions = false;
		//AQUI ANIRIA L'ANIMACIO DE MUERTE MUY MUERTO
	//	collider2D.enabled = false;
		_anim.SetBool ("death", true);
		_anim.SetBool ("mal", false);
		IsDead = true;
		transform.parent = null;
		gm.lifes -= 1;
		veri=false;
		viscos=false;
		AudioSource.PlayClipAtPoint(death, transform.position, 1.5f);

	}
	
	public void respawn(Checkpoint checkpoint){
		Checkpoint go = checkpoint;		
		/*if (go == null) {
			go = new GameObject("Startpoint");
			go.transform.position= Vector3.zero;
		}*/
		IsDead = false;
		_anim.SetBool("mal", false);
		//_controller.detectCollisions = true;
		collider2D.enabled = true;
		if (GameObject.Find ("Player") != null) {
			GameObject pl = GameObject.Find ("Player");
			pl.transform.position = go.transform.position; //mou el pj al punt de inici	
		}
		if (GameObject.Find ("Player_trans") != null) {
			GameObject pl = GameObject.Find ("Player_trans");
			pl.transform.position = go.transform.position; //mou el pj al punt de inici
		}
		//mou el pj al punt de inici
	}

	public Transform ReturnActivePlayer(){
		if(notrans==0)
			return personatge.transform;
		if (notrans == 1)
			return p_trans.transform;
		else
			return null;
	}
	private void SortTargetsByDistance(){ //Ordena la llista de targets segons la distancia amb el jugador
		serps.Sort(delegate(Transform t1, Transform t2){
			return Vector2.Distance(t1.position, myTransform.position).CompareTo(Vector2.Distance(t2.position, myTransform.position));
		});	
	}
	public void AddTarget(Transform enemy){ //afegeix els enemics a la llista de targets
		serps.Add (enemy);
	}

	public void desactivedeath () {
		_anim.SetBool ("death", false);

	}
}
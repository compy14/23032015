using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	public AudioClip clip;
	public GameObject target;
	public int EnemyHealth;
	public Animator _anim;
	private float distance;
	public float attackTimer;
	public float attackTimerRUN;
	public float attackTimerJUMP;
	public float tempsanim;
	public float reinicicombo;
	public float coolDown;
	public int statatac;
	public bool atac=false;
	public float mesdistancia;
	// Use this for initialization
	void Start () {
		_anim = GetComponent<Animator>(); //agafa la variable(???) i la guarda a _anim
		attackTimer = 0;
		attackTimerRUN = 0;
		attackTimerJUMP = 0;
		tempsanim=0.45f;
		reinicicombo=2.0f;
		coolDown = 0.35f;
		statatac=1;
	}
	
	// Update is called once per frame
	void Update () {
		if(attackTimer>0) attackTimer -= Time.deltaTime;
		if(attackTimerRUN>0) attackTimerRUN -= Time.deltaTime;
		if(attackTimerJUMP>0) attackTimerJUMP -= Time.deltaTime;
		if(tempsanim>0) tempsanim -= Time.deltaTime;
		if(reinicicombo>0)reinicicombo -= Time.deltaTime;
		if(attackTimer<0) attackTimer =0;
		if(attackTimerRUN<0) attackTimerRUN =0;
		if(attackTimerJUMP<0) attackTimerJUMP =0;
		if(reinicicombo<0)reinicicombo=0;
		if(reinicicombo==0) statatac=1;
		//if(attackTimer<0.01f) _anim.SetBool ("PunchNow", false); //amb aixo podem establir el temps que duri l'animacio d'atac
		if(_anim.GetBool("mal")==false && _anim.GetBool("Jump")==false){
			if (Input.GetKeyUp (KeyCode.F) && statatac==1) {//sistema de combos practicament inmillorable, funciona per stats
				if(attackTimer == 0){
					//Attack();
					attackTimer=coolDown;
					_anim.SetBool ("PunchNow", true);
					//_anim.SetBool ("atac3", false);
					statatac=2;
					reinicicombo=2.0f;//temps que es tarda a reiniciar el sitema de combos
				}
			}
			else if (Input.GetKeyUp (KeyCode.F) && statatac==2){
				if(attackTimer == 0){
					//Attack();
					attackTimer=coolDown;
					_anim.SetBool ("atac2", true);
				//	_anim.SetBool ("PunchNow", false);
					statatac=3;
					reinicicombo=2.0f;
				}

			}
			else if (Input.GetKeyUp (KeyCode.F) && statatac==3){
				if(attackTimer == 0){
				//	Attack();
					attackTimer=coolDown;
					_anim.SetBool ("atac3", true);
					//_anim.SetBool ("atac2", false);
					statatac=1;
					reinicicombo=2.0f;

				}
			}

		}
		Player p = GetComponent<Player>();
		if(!p.isGrounded){
			if (Input.GetKeyUp (KeyCode.F)){
				if(attackTimerJUMP==0){
					//Attack();
					//attackTimerJUMP=coolDown*3;
					attackTimer=0.45f;
					_anim.SetBool ("PunchJump", true);
					_anim.SetBool ("Jump", false);
				}
			}

		}
	
		if(p.isGrounded && _anim.GetFloat ("Speed")>0.1){
		//if(p.isGrounded && Input.GetAxisRaw("Horizontal")==true){
		
				if (Input.GetKeyUp (KeyCode.F)){
					if(attackTimerRUN==0){
						//Attack();
						attackTimerRUN=0.9f;
						attackTimer = 1;
						_anim.SetBool ("PunchRun", true);
						tempsanim=0.60f;
						
					}

			}
		}
	
	}
	private void Attack(){
		//_anim.SetBool ("PunchNow", true); //activa el canvi de sprite "PunchNow"
		if(_anim.GetBool ("PunchRun")==false && _anim.GetBool ("PunchJump")==false){
			AudioSource.PlayClipAtPoint(clip, transform.position);
		}
		EnemyHealth eh = (EnemyHealth)target.GetComponent ("EnemyHealth");
		GameObject go = Resources.Load("Danyenemy") as GameObject;
		BossHealth bh = (BossHealth)target.GetComponent ("BossHealth");
		Fantasma ef = (Fantasma)target.GetComponent ("Fantasma");
		float distance = Vector3.Distance (target.transform.position, transform.position); //calcula la distancia del jugador al target

		Vector2 dir = (target.transform.position - transform.position).normalized; 
		if (target.tag == "Spindula"){
			mesdistancia=1;

		}
		else {mesdistancia=0;}
		if(_anim.GetBool("PunchJump")==true){
			mesdistancia = 1;
		}
		else {mesdistancia=0;}
		float direction = Vector2.Dot (dir, transform.right); //calcula si el jugador esta mirant al target, si es positiu l'esta mirant sino es negatiu
		if(_anim.GetBool("mal")==false){
			if (distance < 1.1f+mesdistancia){ //abans era 0.5f
				if (direction>0){
							if(target.tag=="Enemy"){
								eh.AddjustCurrentHealth (-10);
								eh.transform.Translate(+0.5f, 0, 0); 
								//eh.dany();
								Instantiate(go, eh.transform.position, transform.rotation);
							}
							if(target.tag=="MothGoth"){
								eh.AddjustCurrentHealth (-10); 
								//eh.dany();
								Instantiate(go, eh.transform.position, transform.rotation);
							}
							if(target.tag=="Serp"){
								eh.AddjustCurrentHealth (-10);
								Instantiate(go, eh.transform.position, transform.rotation);
								
							}
							if(target.tag=="Objectedes"){
								eh.AddjustCurrentHealth (-10);
								Instantiate(go, eh.transform.position, transform.rotation);
							}
							if(target.tag=="Boss"){
								bh.AddjustCurrentHealth (-10);
							}
					//eh.transform.Translate(-0.5f, 0, 0); //per a que el monstre es tiri enrrere
							if(target.tag=="Fantasma"){
								eh.AddjustCurrentHealth (-10);
								Instantiate(go, ef.transform.position, transform.rotation);
								if (eh.curhealth>0){//si el fantasma encara esta viu
									ef.transform.Translate(-1.8f, 0, 0);//es mou el fantasma quant ho l'ataques
								}
								
							}
							if(target.tag=="Spindula"){
								eh.AddjustCurrentHealth (-10); 
								//eh.dany();
								Instantiate(go, eh.transform.position, transform.rotation);
							}

				}
			}
		}
	}
	

	public void desactivajump(){
		_anim.SetBool ("PunchJump", false);
	}

	public void desactivarrun(){
		_anim.SetBool ("PunchRun", false);
		_anim.SetBool ("PunchNow", false);
		_anim.SetBool ("atac2", false);
		_anim.SetBool ("atac3", false);
	}
	public void desactivaratac1(){
		_anim.SetBool ("PunchNow", false);

	}
	public void desactivaratac2(){
		_anim.SetBool ("atac2", false);
		
	}
	public void desactivaratac3(){
		_anim.SetBool ("atac3", false);
		
	}

}
using UnityEngine;
using System.Collections;

public class Spindula : MonoBehaviour{
	public GameObject target;
	public float speed = 3f;
	private float alfa = 0.000005f;
	private float posiciox;
	public bool _facingRight;
	public Animator _anim;
	public bool punch;
	private float timer=1f;
	public float deteccio;
	
	void Start(){
		_anim = GetComponent<Animator>();
	}
	
	void Update() {
		if(target !=null){
			posiciox = transform.position.x; //ES QUEDA AMB LA POSICIO DE X
			if (Vector2.Distance(transform.position,target.transform.position)<deteccio ) {
				//	_anim.SetFloat ("Speed", 1);
				
				transform.position=((1-alfa)*transform.position+alfa*target.transform.position);
				//per a que giri el personatge si x actual menys la x es negatiu, osigui menor de 0 
				//canvii a cap a l'esquerra sino cap a la dreta
				// per fer-ho em guardo la posicio de x abans que canvii i la comparo un cop ha canviat
				if((posiciox-transform.position.x)<=0){ // SI HI HA UN CANVI DE POSICIO GIRARA CAP A UN COSTAT O CAP A UN ALTRE
					//cap a l'esquerra
					_facingRight=true;
					
					
				}
				else {
					_facingRight=false;
					
					// cap a la dreta
				}
				if(_facingRight == true){ //tot aquest codi es per a que el personatge es mogui cap a la dreta i a l'esquerra i roti 180 graus
					_facingRight = false;
					transform.rotation=Quaternion.Euler (transform.rotation.x,0,transform.rotation.z);
				}
				else if (_facingRight == false) {
					_facingRight= true;
					transform.rotation=Quaternion.Euler (transform.rotation.x,180,transform.rotation.z);
				}
			}
			
			
			
			
		}
	}
	
}
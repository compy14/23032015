using UnityEngine;
using System.Collections;

public class Serp : MonoBehaviour{
	public GameObject target;
	public float speed = 3f;
	private float alfa = 0.00005f;
	public float posiciox;
	public bool _facingRight;
	public Animator _anim;
	public bool punch;
	private float timer=1f;
	public bool right;
	
	void Start(){
		_anim = GetComponent<Animator>();
	
	}
	
	void Update() {
		if(target !=null){
			 //ES QUEDA AMB LA POSICIO DE X
			if (Vector2.Distance(transform.position,target.transform.position)<5f ) {
			//	_anim.SetFloat ("Speed", 1);
				
				transform.position=((1-alfa)*transform.position+alfa*target.transform.position);
				
				//per a que giri el personatge si x actual menys la x es negatiu, osigui menor de 0 
				//canvii a cap a l'esquerra sino cap a la dreta
				// per fer-ho em guardo la posicio de x abans que canvii i la comparo un cop ha canviat
				if(transform.position.x-target.transform.position.x<=0){ // SI HI HA UN CANVI DE POSICIO GIRARA CAP A UN COSTAT O CAP A UN ALTRE
					//cap a l'esquerra
					_facingRight=true;
					right=true;
					posiciox=transform.position.x;
				 //tot aquest codi es per a que el personatge es mogui cap a la dreta i a l'esquerra i roti 180 graus
						
						transform.rotation=Quaternion.Euler (transform.rotation.x,0,transform.rotation.z);
		
		
						
				
				}
				else {
					_facingRight=false;
					right=false;
					posiciox=transform.position.x;
					// cap a la dreta
					transform.rotation=Quaternion.Euler (transform.rotation.x,180,transform.rotation.z);

				}
			
			}
		
			
			
			
		}
	}
	
}
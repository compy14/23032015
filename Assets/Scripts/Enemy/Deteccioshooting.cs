using UnityEngine;
using System.Collections;

public class Deteccioshooting : MonoBehaviour {
	
	public GameObject target;
	public Transform ShootingPoint;
	public GameObject bulletPrefab;
	public float deteccio;
	public float speed = 3f;
	private Animator _anim;
	
	public float fireDelay;
	float cooldownTimer=0;
	
	// Use this for initialization
	void Start () {
		_anim = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
		if(target !=null){
			cooldownTimer -= Time.deltaTime;
			// get the angle
			
			if (Vector2.Distance(transform.position,target.transform.position)<deteccio) { //DETECTA LA DISTANCIA A LA QUE ES TROBA AMB EL JUGADOR
				if ( cooldownTimer <=0){
					//SHOOT!!
					cooldownTimer = fireDelay;
					_anim.SetBool("shoot", true);
					//Instantiate(bulletPrefab, ShootingPoint.transform.position, ShootingPoint.transform.rotation);//crea el sprite de bullet a la posicio ShootingPoint
				}
				
			}
			else{
				_anim.SetBool("shoot", false);
			}
		}
	}
	
	public void shootikana(){
		cooldownTimer = fireDelay;
		Instantiate(bulletPrefab, ShootingPoint.transform.position, ShootingPoint.transform.rotation);
		_anim.SetBool ("shoot", false);
	}
}
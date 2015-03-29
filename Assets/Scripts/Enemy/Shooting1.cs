using UnityEngine;
using System.Collections;

public class Shooting1 : MonoBehaviour {
	
	public Transform ShootingPoint;
	public GameObject bulletPrefab;
	public GameObject Power;
	public float fireDelay;
	float cooldownTimer=0;
	float timebarrido=10;
	public Animator _anim;
	
	// Use this for initialization
	void Start () {
		_anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		cooldownTimer -= Time.deltaTime;
		timebarrido -= Time.deltaTime;;
		if ( cooldownTimer <=0){
			//SHOOT!
			_anim.SetBool("shoot",true);


			//_anim.SetBool ("Shoot", true);
			
			//Instantiate(bulletPrefab, ShootingPoint.transform.position, ShootingPoint.transform.rotation);//crea el sprite de bullet a la posicio ShootingPoint
		}
		/*	if(timebarrido <=0){

			Instantiate(Power, ShootingPoint.transform.position, ShootingPoint.transform.rotation);
		}
*/
	}
	
	public void shootStalactopus(){
		
		Instantiate(bulletPrefab, ShootingPoint.transform.position, ShootingPoint.transform.rotation);

	}

	public void desactivastalactopus(){

		_anim.SetBool ("shoot",false);
		cooldownTimer = fireDelay;
	}
	
	
}


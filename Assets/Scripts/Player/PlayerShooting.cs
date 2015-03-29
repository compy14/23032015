using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	public Transform ShootingPoint;
	public GameObject bulletPrefab;
	private Animator _anim;

	public float fireDelay = 0.25f;
	float cooldownTimer=0;

	// Use this for initialization
	void Start () {
		_anim = GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {
		cooldownTimer -= Time.deltaTime;
		if(_anim.GetBool("Climb")==false){

			if (Input.GetButton("Fire1") && cooldownTimer <=0){
				//SHOOT!
				
				cooldownTimer = fireDelay;
				_anim.SetBool ("Shoot", true);

				Instantiate(bulletPrefab, ShootingPoint.transform.position, ShootingPoint.transform.rotation);//crea el sprite de bullet a la posicio ShootingPoint
			}
			else if(cooldownTimer <=0){_anim.SetBool ("Shoot", false);}
		}
	}
}

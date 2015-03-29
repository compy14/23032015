using UnityEngine;
using System.Collections;

public class EyeGear : MonoBehaviour {
	
	public GameObject target;
	public Transform ShootingPoint;
	public GameObject bulletPrefab;
	public float deteccio;
	public float speed = 3f;
	//private Animator _anim;
	
	public float fireDelay = 0.25f;
	public Animator _anim;
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
				//transform.LookAt(target.transform);
				//				if ( cooldownTimer <=0){
				//					//SHOOT!!
				//					cooldownTimer = fireDelay;
				//					Instantiate(bulletPrefab, ShootingPoint.transform.position, ShootingPoint.transform.rotation);//crea el sprite de bullet a la posicio ShootingPoint
				//				}
				_anim.SetBool("shooteye",true);
				
			}
			else{_anim.SetBool("shooteye",false);}
			if(Vector2.Distance(transform.position,target.transform.position)<4f) { 
				Vector3 norTar = (target.transform.position-transform.position).normalized;
				float angle = Mathf.Atan2(norTar.y,norTar.x)*Mathf.Rad2Deg;
				// rotate to angle
				Quaternion rotation = new Quaternion ();
				rotation.eulerAngles = new Vector3(0,0,angle-180f);
				transform.rotation = rotation;
			}
		}
	}
	
	public void shootEyeGear(){
		
		Instantiate(bulletPrefab, ShootingPoint.transform.position, ShootingPoint.transform.rotation);
	}
}
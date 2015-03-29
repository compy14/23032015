
using UnityEngine;
using System.Collections;
	
	public class AtacBoss : MonoBehaviour {
		
		public Transform ShootingPoint;
		public GameObject bulletPrefab;
		public float fireDelay = 0.25f;
		float cooldownTimer=0;
		float timebarrido=10f;
		
		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			timebarrido -= Time.deltaTime;

				if(timebarrido <=0){

					Instantiate(bulletPrefab, ShootingPoint.transform.position, ShootingPoint.transform.rotation);
					timebarrido=10f;
				}

		}
	}
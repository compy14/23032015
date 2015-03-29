using UnityEngine;
using System.Collections;

public class rotacio : MonoBehaviour {

	public float contador;
	public float graus;
	public GameObject target;
	// Use this for initialization
	void Start () {
		contador = 0;
	}
	
	// Update is called once per frame
	void Update () {
			
		contador ++;
		if(contador >= 250f){
			if (Vector2.Distance(transform.position,target.transform.position)>5f) { 
				transform.rotation=Quaternion.Euler (transform.rotation.x,transform.rotation.y,transform.rotation.z+graus);
			}
			contador = 0;
			graus = graus + 80;
		}
	
	}
}

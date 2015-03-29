using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	public int maxhealth=100; // la vida maxima
	public int curhealth=100; // vida actual
	public float healthbarlenght;
	
	private ObjectGenerator og;
	// Use this for initialization
	void Start () {
		og = GameObject.Find("GameMaster").GetComponent<ObjectGenerator>();
		//healthbarlenght = Screen.width / 2;
	}
	
	// Update is called once per frame
	void Update () {
		AddjustCurrentHealth (0); //crida la funcio que recalcula la mida de la barra i la vida actual
		if (curhealth == 0) {
			GameObject go = gameObject;
			Destroy (gameObject);
			if(this.tag!="Objectedes")
				og.GenerateItemRNG(go);
		}
	}
	
	/*void OnGUI(){
		GUI.Box (new Rect (10, 70, healthbarlenght, 20), curhealth + "/" + maxhealth); //dibuixa la barra de HP
	}*/
	
	public void AddjustCurrentHealth (int adj){	
		curhealth += adj;
		//Instantiate(bulletPrefab, transform.position, transform.rotation);
		
		
		if (curhealth < 0) curhealth = 0; //si el ajust a la vida dona negatiu iguala a 0
		if (curhealth > maxhealth) curhealth = maxhealth; //si el ajust a la vida dona superior a la maxima vida iguala al max
		if (maxhealth < 1) maxhealth = 1;
		//healthbarlenght = (Screen.width / 2) * (curhealth/(float)maxhealth);
	}
	
	public void dany(){
		GameObject go = Resources.Load("Danyenemy") as GameObject;
		Instantiate(go, transform.position, transform.rotation);
	}
	
}
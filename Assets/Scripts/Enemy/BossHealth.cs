using UnityEngine;
using System.Collections;

public class BossHealth : MonoBehaviour {
	public int maxhealth=200; // la vida maxima
	public int curhealth=200; // vida actual
	public GameObject target;
	private int score_n;
	private LvlManager lm;
	
	public float healthbarlenght;
	// Use this for initialization
	void Start () {
		healthbarlenght = Screen.width / 2;
		//agafa el score aconseguir i restar-li al total de la vida (que començi amb 1000)
		lm = GameObject.Find("LvlManager").GetComponent<LvlManager>();
		score_n=lm.score;
		maxhealth=maxhealth-score_n;
		curhealth=curhealth-score_n;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(curhealth);
		AddjustCurrentHealth (0); //crida la funcio que recalcula la mida de la barra i la vida actual
		if (curhealth == 0) Destroy (gameObject);
	}
	
	void OnGUI(){
		GUI.Box (new Rect (10, 70, healthbarlenght, 20), curhealth + "/" + maxhealth); //dibuixa la barra de HP
	}
	
	public void AddjustCurrentHealth (int adj){	
		curhealth += adj;
		
		if (curhealth < 0) curhealth = 0; //si el ajust a la vida dona negatiu iguala a 0
		if (curhealth > maxhealth) curhealth = maxhealth; //si el ajust a la vida dona superior a la maxima vida iguala al max
		if (maxhealth < 1) maxhealth = 1;
		healthbarlenght = (Screen.width / 2) * (curhealth/(float)maxhealth);
	}
	
	/*void restarvida(){

		curhealth=curhealth-10;
		maxhealth=maxhealth-10;

	}*/
}
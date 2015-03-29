using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Targetting1 : MonoBehaviour {
	//public List<Transform> target; //llista de target
	public Transform selectedTarget;//target selecionat.
	public bool flag;
	
	private Player pl;
	// Use this for initialization
	void Start () {
		//target = new List<Transform> ();
		selectedTarget = null;
		
		//AddPlayer();
	}
	
	/*public void AddPlayer(){ //afegeix tots els objectes amb el tag "Enemy" de l'escena a la llista cridant a la funcio addTarget
		GameObject[] go = GameObject.FindGameObjectsWithTag ("Aki");
		
		foreach (GameObject player in go)
			AddTarget (player.transform);
	}
	
	public void AddTarget(Transform player){ //afegeix els enemics a la llista de targets
		target.Add (player);
	}*/
	
	private void TargetPlayer(){ //la funcio principal que s'encarrega de targetejar enemics.
		if (GameObject.Find ("Player") != null) {
			pl = GameObject.Find ("Player").GetComponent<Player> ();
			if(pl.notrans==0){ 
				selectedTarget=pl.personatge.transform;
			}
		}
		if (GameObject.Find ("Player_trans") != null) {
			pl = GameObject.Find ("Player_trans").GetComponent<Player> ();
			if (pl.notrans == 1) {
				selectedTarget = pl.p_trans.transform;
			}
		}
		SelectTarget();
	}

	private void SelectTarget(){//Fica el target com a target del script enemy attack
		if (selectedTarget != null) {
			EnemyAttack ea = (EnemyAttack)GetComponent ("EnemyAttack");
			if(ea!=null){
				ea.target = selectedTarget.gameObject;
			}
			Deteccioshooting ds = (Deteccioshooting)GetComponent ("Deteccioshooting");
			if(ds!=null){
				ds.target = selectedTarget.gameObject;
			}
			EnemyFollower ef = (EnemyFollower)GetComponent ("EnemyFollower");
			if(ef!=null){
				ef.target = selectedTarget.gameObject;
			}
			Fantasma f = (Fantasma)GetComponent ("Fantasma");
			if(f!=null){
				f.target = selectedTarget.gameObject;
			}
			Seguimentcamara sc = (Seguimentcamara)GetComponent ("Seguimentcamara");
			if(sc!=null){
				sc.target = selectedTarget.gameObject;
			}
			seguimentplayer spa = (seguimentplayer)GetComponent ("seguimentplayer");
			if(spa!=null){
				spa.target = selectedTarget.gameObject;
			}
			Serp s = (Serp)GetComponent ("Serp");
			if(s!=null){
				s.target = selectedTarget.gameObject;
			}
			BossHealth bh = (BossHealth)GetComponent ("BossHealth");
			if(bh!=null){
				bh.target = selectedTarget.gameObject;
			}
			rotacio r = (rotacio)GetComponent ("rotacio");
			if(r!=null){
				r.target = selectedTarget.gameObject;
			}
			EyeGear eg = (EyeGear)GetComponent ("EyeGear");
			if(eg!=null){
				eg.target = selectedTarget.gameObject;
			}
			Spindula sp = (Spindula)GetComponent ("Spindula");
			if(eg!=null){
				eg.target = selectedTarget.gameObject;
			}
		}
	}
	
	
	private void DeselectTarget(){ //"deselcciona" el target anterior,
		selectedTarget = null;
	}
	// Update is called once per frame
	void Update () {
		TargetPlayer ();
	}
}
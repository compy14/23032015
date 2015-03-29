using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/*
Esta tot be fins a arribar a la funcio DedMobs() no acaba de actualitzar be el array de mobs morts
ja que mirem si el eyegear te fills y sempre tindra el fill del path. Seria possible reutilizar-ho pero
s'hauria de canviar el prefab de tots els monstres. Prefereixo fer una funcio senzilla i cridar-la cuan el monstre
es mori.
 */
public class ObjectGenerator_old : MonoBehaviour {

	public enum State{
		Idle,
		Initialize,
		Setup,
		SpawnOb
	}
	public int timespawn=120;
	public float distancespawn=1f;
	public GameObject[] obPrefabs;
	public GameObject[] mobs;
	public State state; 
	public List<Transform> targets;

	private bool nospawn=false;
	private Transform _pc;
	private Player pl;
	private int timer = 0;

	void Awake(){
		Debug.Log("HIHIH");
		AddAllEnemies ();
		state = State.Initialize;
	}
	// Use this for initialization
	IEnumerator Start () {
		while (true) {
			switch(state){
			case State.Initialize:
				Initialize();
				break;
			case State.Setup:
				Setup();
				break;
			case State.SpawnOb:
				SpawnOb();
				break;
			case State.Idle:
				Idle();
				break;
			}
			yield return 0;
		}
	}

	private void Initialize(){
		if (!CheckForObPrefabs())
			return;
		if (!MobsExist())
			return;
		
		Debug.Log("HA MORT UN MONSTRE");
		state = State.Setup;
	}

	private void Setup(){
		state = State.SpawnOb;
	}

	private void SpawnOb(){
		Transform[] trns = DedMobs ();
	//	Debug.Log (gos);
		for (int cnt =0; cnt< trns.Length; cnt++) {
			GameObject go = Instantiate(obPrefabs[Random.Range(0, obPrefabs.Length)],
			                            trns[cnt].transform.position,
			                            Quaternion.identity
			                            ) as GameObject;
			go.transform.parent= trns[cnt].transform; 
		}
		state = State.Idle;
	}

	private void Idle(){
		if (GameObject.Find ("Player") != null) {
			pl = GameObject.Find ("Player").GetComponent<Player> ();
			if(pl.notrans==0){ 
				_pc=pl.personatge.transform;
			}
		}
		if (GameObject.Find ("Player_trans") != null) {
			pl = GameObject.Find ("Player_trans").GetComponent<Player> ();
			if (pl.notrans == 1) {
				_pc = pl.p_trans.transform;
			}
		}
		Transform[] gos = DedMobs ();
		if (gos.Length != 0) {
			timer++;
			for (int cnt =0; cnt< gos.Length; cnt++) {
				if(gos[cnt].transform.position.x-distancespawn < _pc.transform.position.x && _pc.transform.position.x<gos[cnt].transform.position.x+distancespawn)
					nospawn=true;
				else nospawn=false;
			}
			if(timer > timespawn && !nospawn){
				timer=0;
				state = State.Initialize;
			}
		}
	}

	private bool CheckForObPrefabs(){
		if (obPrefabs.Length > 0)
			return true;
		else
			return false;
	}

	private bool MobsExist(){
		Transform[] gos = DedMobs ();
		Debug.Log(gos);
		if (gos.Length > 0)
			return true;
		else
			return false;
	}

	private Transform[] DedMobs(){
		List<Transform> trans = new List<Transform> ();
		Debug.Log("--------------");
		for (int cnt=0; cnt <targets.Count; cnt++) {
			if(targets[cnt].transform.childCount==0){
				trans.Add(targets[cnt]);
				targets.RemoveAt(cnt);
			}
		}
		Debug.Log(trans);
		Debug.Log("--------------");
		return trans.ToArray();
	}

	public void AddTarget(GameObject enemy){ //afegeix els enemics a la llista de targets
		targets.Add (enemy.transform.parent);
	}

	public void AddAllEnemies(){ //afegeix tots els objectes amb el tag "Enemy" de l'escena a la llista cridant a la funcio addTarget
		GameObject[] go = GameObject.FindGameObjectsWithTag ("Enemy");
		GameObject[] go3 = GameObject.FindGameObjectsWithTag ("Fantasma");
		GameObject[] go4 = GameObject.FindGameObjectsWithTag ("Boss");
		GameObject[] go5 = GameObject.FindGameObjectsWithTag ("Serp");
		GameObject[] go6 = GameObject.FindGameObjectsWithTag ("MothGoth");
		GameObject[] go7 = GameObject.FindGameObjectsWithTag ("Spindula");
		foreach (GameObject enemy in go)
			AddTarget (enemy);
		foreach (GameObject enemy in go3)
			AddTarget (enemy);
		foreach (GameObject enemy in go4)
			AddTarget (enemy);
		foreach (GameObject enemy in go5)
			AddTarget (enemy);
		foreach (GameObject enemy in go6)
			AddTarget (enemy);
		foreach (GameObject enemy in go7)
			AddTarget (enemy);
	}
}

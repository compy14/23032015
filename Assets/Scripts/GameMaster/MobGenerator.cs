using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MobGenerator : MonoBehaviour {
	public enum State{
		Idle,
		Initialize,
		Setup,
		SpawnMob
	}
	public int timespawn=120;
	public float distancespawn=1f;
	public GameObject[] mobPrefabs;
	public GameObject[] spawnPoints;
	public State state; 

	private bool nospawn=false;
	private Transform _pc;
	private Player pl;
	private int timer = 0;
	void Awake(){
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
			case State.SpawnMob:
				SpawnMob();
				break;
			case State.Idle:
				Idle();
				break;
			}

			yield return 0;
		}
	}

	private void Initialize(){
		if (!CheckForMobPrefabs())
			return;
		if (!CheckForSpawnPoints())
			return;


		state = State.Setup;
	}

	private void Setup(){
		state = State.SpawnMob;
	}

	private void SpawnMob(){
		GameObject[] gos = AvaliableSpawnPoints ();
	//	Debug.Log (gos);
		for (int cnt =0; cnt< gos.Length; cnt++) {
			GameObject go = Instantiate(mobPrefabs[Random.Range(0, mobPrefabs.Length)],
			                            gos[cnt].transform.position,
			                            Quaternion.identity
			                            ) as GameObject;
			go.transform.parent= gos[cnt].transform; 
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
		GameObject[] gos = AvaliableSpawnPoints ();
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

	private bool CheckForMobPrefabs(){
		if (mobPrefabs.Length > 0)
			return true;
		else
			return false;
	}

	private bool CheckForSpawnPoints(){
		if (spawnPoints.Length > 0)
			return true;
		else
			return false;
	}

	private GameObject[] AvaliableSpawnPoints(){
		List<GameObject> gos = new List<GameObject> ();

		for (int cnt=0; cnt <spawnPoints.Length; cnt++) {
			if(spawnPoints[cnt].transform.childCount==0){
				gos.Add(spawnPoints[cnt]);
			}
		}

		return gos.ToArray();
	}
}

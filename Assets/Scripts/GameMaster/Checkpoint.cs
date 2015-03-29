using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {
	private GameMaster gm;
	
	public GameObject _pc_trans;
	public GameObject _pc;
	public GameObject playerCharacter;
	public GameObject p_transCharacter;
	// Use this for initialization
	public void Awake(){
		gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();//per a que 
	}
	
	public void Start () {
		
	}
	
	public void PlayerHitCheckpoint(){
		
	}
	
	private IEnumerator PlayerHitCheckpointCo(int bonus){
		yield break;
	}
	
	public void PlayerLeftCheckpoint(){
		
	}
	
	public void SpawnPlayer(Checkpoint checkpoint){
		Checkpoint ch = checkpoint;
		if (gm.StartLevel) { //instancia els jugadors en cas de ser el principi de nivell
			_pc_trans = Instantiate (p_transCharacter, ch.transform.position, Quaternion.identity) as GameObject;	
			_pc = Instantiate (playerCharacter, ch.transform.position, Quaternion.identity) as GameObject; //crea el PJ
			_pc.name = "Player"; //Canvia el nom del PJ instanciat a Player
			_pc_trans.name = "Player_trans";
			_pc_trans.SetActive(false);
			gm.StartLevel=false;
		}
		else{
			if (GameObject.Find ("Player") != null) {
				Player pl = GameObject.Find ("Player").GetComponent<Player> ();
				pl.respawn(ch);
			}
			if (GameObject.Find ("Player_trans") != null) {
				Player pl = GameObject.Find ("Player_trans").GetComponent<Player> ();
				pl.respawn(ch);
			}
		}
	}
	
	public void AssignObjectToCheckpoint(){
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
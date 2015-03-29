using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameMaster : MonoBehaviour {
	public static GameMaster Instance{ get; private set;}
	public GameObject _pc;
	public GameObject _pc_trans;
	public Camera mainCamera;
	public Checkpoint DebugSpawn;
	public List<Checkpoint> _checkpoints; 
	public int _currentCheckpointIndex;
	public float distancecheck=1f;
	public bool StartLevel;
	public Health h;
	public int lifes = 3;
	public bool death;
	
	public void Awake(){
		StartLevel = true;
		Instance = this;
		
	}
	// Use this for initialization
	void Start (){
		h = GameObject.Find("Health").GetComponent<Health>();
		_currentCheckpointIndex = _checkpoints.Count > 0 ? 0 : -1; //si no hi han checkpoints posa el index a -1
		
		if(DebugSpawn!=null) //si hi ha un debugspawn es el que utilitza de spawn
			DebugSpawn.SpawnPlayer(DebugSpawn);
		
		
		else if (_currentCheckpointIndex !=-1){ //chekeja que hi hagi minim un checkpoint abans de cridara a la funcio de spawn
			_checkpoints[_currentCheckpointIndex].SpawnPlayer(_checkpoints[_currentCheckpointIndex]);
		}
	}
	
	
	// Update is called once per frame
	void Update () {
		//troba i asigna els valors del personatge a les variables.
		if (GameObject.Find ("Player") != null)
			_pc=GameObject.Find ("Player") as GameObject;
		if (GameObject.Find ("Player_trans") != null) {
			_pc_trans=GameObject.Find ("Player_trans") as GameObject;
		}
		//fi checks
		var isAtLastCheckpoint = _currentCheckpointIndex + 1 >= _checkpoints.Count;//calcula si esta al ultim checkpoint
		if (isAtLastCheckpoint)
			return;//si esta al ultim checkpoint no ejecuta la resta de codi
		var distanceToNextCheckpoint = Vector3.Distance( _checkpoints [_currentCheckpointIndex + 1].transform.position, _pc.transform.position);//aixo calcula la distancia entre el transfrom del pj i el del checkpoint
		distanceToNextCheckpoint = distanceToNextCheckpoint - distancecheck;// aqui hi afegeixo una distacia per a que no hagi de ser exactament en el pixel concret del chekpoint per a que la distancia sigui 0
		if (distanceToNextCheckpoint >= 0) //si la distancia es mes gran o igual a 0 no executa la resta de codi
			return;
		_checkpoints [_currentCheckpointIndex].PlayerLeftCheckpoint ();//???
		_currentCheckpointIndex++; //augmenta el index dels chekpoints
		_checkpoints [_currentCheckpointIndex].PlayerHitCheckpoint ();//???
	}
	
	public void KillPlayer(){ //per cridar la corutina
		//	Debug.Log ("killplayer");
		StartCoroutine (KillPlayerCo ()); // aixo fa que el metode duri varis frames
	}
	
	private IEnumerator KillPlayerCo(){
		death=true;
		Seguimentcamara go = GameObject.Find ("Camera").GetComponent<Seguimentcamara> ();
		Player pl = _pc.GetComponent<Player> ();
		pl.Kill (); //crida la funcio que fa que suceixi tot el relacionat amb la mort
		//go.isfollowing = false; //la camara deixa de seguir al jugador
		
		
		yield return new WaitForSeconds (8f); //espera 2s
		if (lifes <= 0)
			Application.LoadLevel (2);

		go.isfollowing = true; //la camara seguix al jugador
		if (_currentCheckpointIndex != -1)
			_checkpoints [_currentCheckpointIndex].SpawnPlayer (_checkpoints [_currentCheckpointIndex]);
		death=false;
		h.modifyHealth(1000);
	}
	void OnGUI()
	{
		GUI.Label (new Rect (1300, 50, 500, 500), "Lifes: " + (int)(lifes));
	}
}
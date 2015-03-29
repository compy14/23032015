using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {
	
	public Texture aki;
	public Texture aki_trans;
	public Texture score;
	private GameMaster gm;
	private Checkpoint ch;
	private int notrans;
	public GameObject personatge;
	public Font MyFont;
	public GUIStyle myGUIStyle;
	public float difference = 1;
	// Use this for initialization
	void Start () {
		notrans=1;

	/*	gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();
		if(gm.DebugSpawn!= null){
			ch = GameObject.Find ("DebugSpawn").GetComponent<Checkpoint> ();
		}
		else{
			ch = GameObject.Find ("Startpoint").GetComponent<Checkpoint> ();
		}
		personatge = ch._pc;*/
	}
	
	// Update is called once per frame
	void Update () {
//		if(personatge!=null){
//			Debug.Log("entrepoc fons");
//			if(personatge.activeInHierarchy==true) {
//				notrans=0;
//				Debug.Log ("entre");
//			}
//			if(personatge.activeInHierarchy==false) notrans=1;
//		}
		difference = (Screen.width / 12.8f) /100;
		if (GameObject.Find ("Player") == null) {
			notrans=1;
		}
		if (GameObject.Find ("Player_trans") == null) {
			notrans=0;
		}
	}
	
	
	
	//
	void OnGUI()
	{

	
		//Player p = GameObject.Find("Player").GetComponent<Player>();

		// 
		if(notrans==0){
			GUI.DrawTexture(new Rect(Screen.width/25, Screen.height*0.002f, Screen.width/10, Screen.width/10), aki, ScaleMode.ScaleToFit, true);
		}
		else if(notrans==1){
			GUI.DrawTexture(new Rect(Screen.width/25, Screen.height*0.002f, Screen.width/10, Screen.width/10), aki_trans, ScaleMode.ScaleToFit, true);

		}
		GUI.DrawTexture(new Rect(1050 * difference, 50 * difference, 200 * difference, 110 * difference), score, ScaleMode.ScaleToFit, true);
		LvlManager lm = GameObject.Find("LvlManager").GetComponent<LvlManager>();
		GUI.skin.font = MyFont;
		myGUIStyle.fontSize = Screen.width/20;
		myGUIStyle.normal.textColor = Color.white;
		GUI.Label (new  Rect( 1090 * difference, 100 * difference, 100 * difference, 50 * difference), "score:" + (int) lm.score, myGUIStyle);
		//GUILayout.Label(score);
	//	GUILayout.Label("This is an sized label");


	}
	
}


//		(GameObject.Find("myTexture").getComponent(GUITexture)as GUITexture).enable = false;
//		GUI.DrawTexture(new Rect(10, 10, 60, 60), aTexture, ScaleMode.ScaleToFit, true, 10.0F);
//	
//	}
//	public Texture aTexture;
//	void OnGUI() {
//		if (!aTexture) {
//			Debug.LogError("Assign a Texture in the inspector.");
//			return;
//		}
//		GUI.DrawTexture(new Rect(10, 10, 60, 60), aTexture, ScaleMode.ScaleToFit, true, 10.0F);
//	}
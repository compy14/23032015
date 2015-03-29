using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	/*void Update () {
	
	}*/
	void OnGUI(){

		GUI.contentColor = Color.yellow;
		if(GUI.Button (new Rect(Screen.width/2-50,Screen.height/2 +100,200,80),"Retry?")){
			Application.LoadLevel(0);
		}

		if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2 +250,200,80),"Quit")){
			Application.Quit();
		}

	}
}

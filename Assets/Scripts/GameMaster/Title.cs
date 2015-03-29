using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	/*void Update () {
	
	}*/
	void OnGUI(){

		GUI.contentColor = Color.yellow;
		if(GUI.Button (new Rect(Screen.width/2-50,Screen.height/2 +200,200,80),"Start")){
			Application.LoadLevel(1);
		}

		if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2 +350,200,80),"Quit")){
			Application.Quit();
		}

	}
}

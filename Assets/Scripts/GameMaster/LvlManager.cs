using UnityEngine;
using System.Collections;

public class LvlManager : MonoBehaviour {
	public int score;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddPoints(int points)
	{
		score += points;

	}

	void OnGUI()
	{
		//GUILayout.Label (score.ToString (),  GUILayout.Width(300));
		//GUI.Box(Rect(300,300,100,25), score.ToString());
		//GUI.Label (new Rect (1300, 20, 100, 100), "Score " + (int)(score));
	}
}

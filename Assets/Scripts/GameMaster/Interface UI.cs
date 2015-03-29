using UnityEngine;
using System.Collections;

public class InterfaceUI : MonoBehaviour {

	public Texture m_texture;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}


	
	//
	void OnGUI()
	{
		// 
		//GUI.DrawTexture(new Rect(1000, Screen.width/10, 1500, 150), m_texture, ScaleMode.ScaleToFit, true);
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
using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	
	public int startHealth;
	public int healthPerHeart;
	private GameMaster gm;
	private int maxHealth;
	private int currentHealth;
	
	public Texture[] heartImages;
	public GUITexture heartGUI;
	
	private ArrayList hearts = new ArrayList();
	
	// Spacing:
	public float maxHeartsOnRow;
	private float spacingX;
	private float spacingY;
	
	void Awake(){

		gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();

	}
	void Start () {
		spacingX = heartGUI.pixelInset.width;
		spacingY = -heartGUI.pixelInset.height;
		AddHearts(startHealth/healthPerHeart);

	}
	void Update(){
		if(currentHealth<=0){
			currentHealth=maxHealth;
			gm.KillPlayer();
			//modifyHealth(1000);
		}


	}
	public void AddHearts(int n) {
		for (int i = 0; i <n; i ++) { 
			//Debug.Log ("entra");
			Transform newHeart = ((GameObject)Instantiate(heartGUI.gameObject,this.transform.position,Quaternion.identity)).transform; // Creates a new heart
		//	Debug.Log (heartGUI.gameObject);
			newHeart.parent = transform;
			
			int y = (int)(Mathf.FloorToInt(hearts.Count / maxHeartsOnRow));
			int x = (int)(hearts.Count - y * maxHeartsOnRow);
			//Debug.Log (x*spacingX);
			//Debug.Log (y);

			newHeart.GetComponent<GUITexture>().pixelInset = new Rect (Screen.width/7+x*(Screen.width/26), Screen.height-(Screen.height/13), Screen.width/30, Screen.height/20);
			newHeart.GetComponent<GUITexture>().texture = heartImages[0];
			hearts.Add(newHeart);

		}
	//	Debug.Log ("fidelfor");
		maxHealth += n * healthPerHeart;
		currentHealth = maxHealth;
		UpdateHearts();
	}

	
	public void modifyHealth(int amount) {
		if(!gm.death){
			currentHealth += amount;
			currentHealth = Mathf.Clamp(currentHealth,0,maxHealth);
			UpdateHearts();
		}
	}

	void UpdateHearts() {
		bool restAreEmpty = false;
		int i =0;
		
		foreach (Transform heart in hearts) {
			
			if (restAreEmpty) {
				heart.guiTexture.texture = heartImages[0]; // heart is empty
			}
			else {
				i += 1; // current iteration
				if (currentHealth >= i * healthPerHeart) {
					heart.guiTexture.texture = heartImages[heartImages.Length-1]; // health of current heart is full
				}
				else {
					int currentHeartHealth = (int)(healthPerHeart - (healthPerHeart * i - currentHealth));
					int healthPerImage = healthPerHeart / heartImages.Length; // how much health is there per image
					int imageIndex = currentHeartHealth / healthPerImage;

					
					if (imageIndex == 0 && currentHeartHealth > 0) {
						imageIndex = 1;
					}

					heart.guiTexture.texture = heartImages[imageIndex];
					restAreEmpty = true;
				}
			}
			
		}
	}

	void OnGUI()
	{
		//GUILayout.Label (score.ToString (),  GUILayout.Width(300));
		//GUI.Box(Rect(300,300,100,25), score.ToString());
		//GUI.Label (new Rect (100, 20, 100, 100), "Vida " + (int)(currentHealth));
	}
}

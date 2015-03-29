using UnityEngine;
using System.Collections;

public class ObjectGenerator : MonoBehaviour {
	public GameObject[] obPrefabs;
	
	void Start(){
	}
	
	void Update(){
	}
	
	public void GenerateItemRNG(GameObject go){
		Instantiate(obPrefabs[Random.Range(0,obPrefabs.Length)], go.transform.position, go.transform.rotation);
	}
	
	public void GenerateItem(GameObject go, int i){
		Instantiate(obPrefabs[i], go.transform.position, go.transform.rotation);
	}
}
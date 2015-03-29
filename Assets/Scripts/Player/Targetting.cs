

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Targetting : MonoBehaviour {
	public List<Transform> targets; //llista de targets
	public Transform selectedTarget;//target selecionat.
	private Transform lastTarget;	//ultim target selecionat.
	
	private Transform myTransform;
	// Use this for initialization
	void Start () {
		targets = new List<Transform> ();
		selectedTarget = null;
		myTransform = transform;
		
		AddAllEnemies();
	}
	
	public void AddAllEnemies(){ //afegeix tots els objectes amb el tag "Enemy" de l'escena a la llista cridant a la funcio addTarget
		GameObject[] go = GameObject.FindGameObjectsWithTag ("Enemy");
		GameObject[] go2 = GameObject.FindGameObjectsWithTag ("Objectedes");
		GameObject[] go3 = GameObject.FindGameObjectsWithTag ("Fantasma");
		GameObject[] go4 = GameObject.FindGameObjectsWithTag ("Boss");
		GameObject[] go5 = GameObject.FindGameObjectsWithTag ("Serp");
		GameObject[] go6 = GameObject.FindGameObjectsWithTag ("MothGoth");
		GameObject[] go7 = GameObject.FindGameObjectsWithTag ("Spindula");
		foreach (GameObject enemy in go)
			AddTarget (enemy.transform);
		foreach (GameObject enemy in go2)
			AddTarget (enemy.transform);
		foreach (GameObject enemy in go3)
			AddTarget (enemy.transform);
		foreach (GameObject enemy in go4)
			AddTarget (enemy.transform);
		foreach (GameObject enemy in go5)
			AddTarget (enemy.transform);
		foreach (GameObject enemy in go6)
			AddTarget (enemy.transform);
		foreach (GameObject enemy in go7)
			AddTarget (enemy.transform);
	}

	public void ClearEnemies(){
		targets.Clear ();
	}
	
	
	public void AddTarget(Transform enemy){ //afegeix els enemics a la llista de targets
		targets.Add (enemy);
	}
	
	private void SortTargetsByDistance(){ //Ordena la llista de targets segons la distancia amb el jugador
		targets.Sort(delegate(Transform t1, Transform t2){
			return Vector2.Distance(t1.position, myTransform.position).CompareTo(Vector2.Distance(t2.position, myTransform.position));
		});	
	}
	
	
	private void TargetEnemy(){ //la funcio principal que s'encarrega de targetejar enemics.
		if (selectedTarget == null) {	 //si no te cap target crida la funcio de ordenarlos i agafa el de la priemera posicio
			if (targets.Count != 0){
				if(targets[0]==null){
					targets.RemoveAt(0);//en cas de que el primer element de la llista sigui null el treu per a evitar problemes al ordenarla
					removeNulls();
				}
			}
			if (targets.Count == 0) selectedTarget = null;
			else {
				removeNulls();
				SortTargetsByDistance();
				selectedTarget = targets [0];
			}
		}
		else {								//en cas de tenir un target guarda el target actual com a anterior, crida a la funcio de ordenar i agafa el primer de la llista
			lastTarget=selectedTarget;
			removeNulls();
			SortTargetsByDistance();
			selectedTarget = targets [0];
			if (selectedTarget!=lastTarget) DeselectTarget(); //si nomes si target actual es diferent al anterior deselecciona al anterior
		}
		SelectTarget();
	}
	
	private void SelectTarget(){  //Fica el target com a target del script player attack
		if (selectedTarget != null) {
			//selectedTarget.renderer.material.color = Color.red;//canvia color al enemic selecionat
			PlayerAttack pa = (PlayerAttack)GetComponent ("PlayerAttack");
			pa.target = selectedTarget.gameObject;

		}
	}
	
	private void removeNulls(){ //recorre la llista treient els elements que siguin nulls.
		for (var i=0; i<targets.Count-1; i++) {
			if(targets[i]==null) targets.RemoveAt(i);
		}
	}
	
	private void DeselectTarget(){ //"deselcciona" el target anterior,
		//lastTarget.renderer.material.color = Color.blue;
	}
	// Update is called once per frame
	void Update () {
		ClearEnemies ();
		AddAllEnemies ();
		TargetEnemy ();
	}
}
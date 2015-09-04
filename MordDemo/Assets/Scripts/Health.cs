using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	LevelManager levelManager;

	public int fullHealth;
	private int health;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			//Debug.Log("dead");

			if(gameObject.name == "Player"){
				//both functions run at same 
				StartCoroutine("RespawnCo");
				levelManager.RespawnPlayer ();
				health = fullHealth;
			}
		}
	}

	public void giveDamage(int damage){
		Debug.Log("hit");
		health -= damage;
	}
}

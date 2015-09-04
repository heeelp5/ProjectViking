using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int health;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0)
			Destroy (gameObject);
	}

	public void giveDamage(int damage){
		Debug.Log ("hits ");
		health -= damage;
	}
}

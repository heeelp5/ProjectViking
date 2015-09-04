using UnityEngine;
using System.Collections;

public class DamageController : MonoBehaviour {

	private PlayerConroller player;

	private int damage;
	public int sideSwing;
	public int downSwing;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerConroller> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.anim.GetBool ("DownSwing"))
			damage = downSwing;

		if (player.anim.GetBool ("SideSwing"))
			damage = sideSwing;
	}

	void OnCollisionEnter2D(Collision2D other){
		//Debug.Log("Hit");
		if (other.gameObject.tag == "Enemy") {
			Debug.Log("hit");
			other.gameObject.GetComponent<EnemyHealth> ().giveDamage (damage);
		}
	}
}

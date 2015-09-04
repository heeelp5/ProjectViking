using UnityEngine;
using System.Collections;

public class StaminaBar : MonoBehaviour {

	public GameObject staminaFull;
	//public GameObject staminaEmpty;

	PlayerConroller player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerConroller> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.strafeCounter > player.strafeDelay)
			staminaFull.SetActive (true);
		else
			staminaFull.SetActive (false);
		//stuff

	}
}

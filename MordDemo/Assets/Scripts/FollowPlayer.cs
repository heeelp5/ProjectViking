using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	PlayerConroller player;
	
	private bool follow;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerConroller> ();
		follow = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (follow)
			transform.position = new Vector3 (player.transform.position.x - 10, player.transform.position.y + 5, player.transform.position.z);
	}
}

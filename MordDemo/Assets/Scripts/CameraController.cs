using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

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
			transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z - 5);
	}
}

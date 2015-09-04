using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckpoint;

	private PlayerConroller player;



	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerConroller> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void RespawnPlayer(){
		player.transform.position = currentCheckpoint.transform.position;
	}	
}

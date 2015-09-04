using UnityEngine;
using System.Collections;

public class BerserkerAI : MonoBehaviour 
{
	public float chargeTime;
	public float chargeDelay;
	public float moveSpeed;
	public float chargeSpeed;
	public float detectionDistance;
	public bool patrols;
	Rigidbody2D rBody;
	bool isChargingRight;
	bool isChargingLeft;
	bool isOnCooldown;
	float chargeStartTime;
	float chargeDelayStart;
	
	PlayerConroller player;
	
	// Use this for initialization
	void Start () 
	{
		player = FindObjectOfType<PlayerConroller> ();
		rBody = GetComponent<Rigidbody2D> ();
		isChargingRight = false;
		isChargingLeft = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!isOnCooldown) {
			if (patrols) {
				if (isChargingLeft || isChargingRight) {
					if (Time.time - chargeStartTime < chargeTime) {
						if (isChargingLeft) {
							rBody.velocity = new Vector2 (-chargeSpeed, rBody.velocity.y);
						} else if (isChargingRight) {
							rBody.velocity = new Vector2 (chargeSpeed, rBody.velocity.y);
						}
					} else {
						isChargingLeft = false;
						isChargingRight = false;
						isOnCooldown = true;
						chargeDelayStart = Time.time;
					}
				} else {
					//todo
				}
			} else {
				if (isChargingLeft || isChargingRight) {
					if (Time.time - chargeStartTime < chargeTime) {
						if (isChargingLeft) {
							rBody.velocity = new Vector2 (-chargeSpeed, rBody.velocity.y);
						} else if (isChargingRight) {
							rBody.velocity = new Vector2 (chargeSpeed, rBody.velocity.y);
						}
					} else {
						isChargingLeft = false;
						isChargingRight = false;
						isOnCooldown = true;
						chargeDelayStart = Time.time;
					}
				} else {
					rBody.velocity = new Vector2(0, rBody.velocity.y);
				}
			} 
		}
		else 
		{
			if (Time.time - chargeDelayStart < chargeDelay)
			{
				rBody.velocity = new Vector2(0, rBody.velocity.y);
			}
			else
			{
				rBody.velocity = new Vector2(0, rBody.velocity.y);
				isOnCooldown = false;
			}
		}
	}
	
	void OnTriggerStay2D(Collider2D other)
	{
		if (isChargingRight == false && isChargingLeft == false && isOnCooldown == false)
		{
			if (other.gameObject.GetComponent<PlayerConroller> () == player) 
			{
				if (player.GetComponent<Rigidbody2D> ().position.x < rBody.position.x && Mathf.Abs (player.GetComponent<Rigidbody2D> ().position.y - rBody.position.y) < 3)
				{
					isChargingLeft = true;
					chargeStartTime = Time.time;
				}
				else if (player.GetComponent<Rigidbody2D> ().position.x > rBody.position.x && Mathf.Abs (player.GetComponent<Rigidbody2D> ().position.y - rBody.position.y) < 3)
				{
					isChargingRight = true;
					chargeStartTime = Time.time;
				}
			}
		}
	}
}

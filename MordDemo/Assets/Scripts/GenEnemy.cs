using UnityEngine;
using System.Collections;

public class GenEnemy : MonoBehaviour {
	public LayerMask enemyMask;
	public float speedy;
	Rigidbody2D myBody;
	Transform myTrans;
	float myWidth, myHeight;
	
	// Use this for initialization
	void Start () {
		myTrans = this.transform;
		myBody = this.GetComponent<Rigidbody2D> ();
		SpriteRenderer mySprite = this.GetComponent<SpriteRenderer> ();
		myWidth = mySprite.bounds.extents.x;
		myHeight = mySprite.bounds.extents.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		//use this position to cast the is frounded/isblocked lines from
		Vector2 lineCastPos = myTrans.position.toVector2() - myTrans.right.toVector2() * myWidth + Vector2.up * myHeight;
		//check to see if there's a ground in front of us b4 moving forward
		Debug.DrawLine (lineCastPos, lineCastPos + Vector2.down * 2.5f);
		bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down * 2.5f, enemyMask);
		//check to see if there's a wall to turn
		Debug.DrawLine (lineCastPos, lineCastPos - Vector2.right.toVector2 () * 0.05f);
		bool isBlocked = Physics2D.Linecast(lineCastPos, lineCastPos - myTrans.right.toVector2() * 0.05f, enemyMask);
		
		
		//flip if theres no ground/wall
		if (!isGrounded || isBlocked) {
			Vector3 currRot = myTrans.eulerAngles;
			currRot.y += 180;
			myTrans.eulerAngles = currRot;
		}//*/
		
		//always move forward
		Vector2 myVel = myBody.velocity;
		myVel.x = -myTrans.right.x * speedy;
		myBody.velocity = myVel;
		
	}
}
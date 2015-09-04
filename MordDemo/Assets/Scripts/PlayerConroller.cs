using UnityEngine;
using System.Collections;

public class PlayerConroller : MonoBehaviour {

	public float moveSpeed;
	private float move;

	public float jumpHeight;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask layerGround;
	private bool onGround;
	private bool doubleJumped;

	public float strafeSpeed;
	public float strafing;
	private float strafed;
	public int strafeDelay;
	public int strafeCounter;
	public float strafeToNormalDelay;

	public GameObject staminaFull;

	public float attackDelay;
	public float swingDelay;
	
	public Animator anim;
	
	private bool swinging;

	private bool stun;

	// Use this for initialization
	void Start () {
		stun = false;
		anim = GetComponent<Animator> ();
		strafeCounter = 250;
	}

	void FixedUpdate(){
		onGround = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, layerGround);
	}
	
	// Update is called once per frame
	void Update () {
		move = 0f;
			if (!swinging) {
				Walking ();
				Jump ();
				Combat ();
				Strafe ();

				GetComponent<Rigidbody2D>().velocity = new Vector2(move, GetComponent<Rigidbody2D>().velocity.y);
			}
		}

	void Jump(){
		if (onGround)
			doubleJumped = false;

		if (Input.GetKeyDown (KeyCode.UpArrow) && onGround) {
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
		}

		if (Input.GetKeyDown (KeyCode.UpArrow) && !onGround && !doubleJumped) {
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
			doubleJumped = true;
		}
	}

	void Strafe(){
		
		if (strafeCounter > strafeDelay)
			staminaFull.SetActive (true);
		else
			staminaFull.SetActive (false);
		
		if (strafeCounter <= strafeDelay) {
			strafeCounter ++;
		}
		else {
			if (Input.GetKeyDown (KeyCode.A)){
				StartCoroutine("StrafeCo");
				anim.SetBool ("isStrafing", true);
				move = -strafeSpeed;
			}
			
			if (Input.GetKeyDown (KeyCode.D)){
				StartCoroutine("StrafeCo");
				anim.SetBool ("isStrafing", true);
				move = strafeSpeed;
			}
		}
	}

	void Walking(){

		if (GetComponent<Rigidbody2D> ().velocity.x < 0)
			transform.localScale = new Vector3 (-1f, 1f, 1f);
		else if (GetComponent<Rigidbody2D> ().velocity.x > 0)
			transform.localScale = new Vector3 (1f, 1f, 1f);

		if (Input.GetKey (KeyCode.LeftArrow)) {
			move = -moveSpeed;
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			move = moveSpeed;
		}
	}

	void Combat(){
		if (Input.GetKeyDown (KeyCode.W) && !swinging) {
			StartCoroutine("SwingingCo");
			StartCoroutine("SwingCo");
			swinging = true;
			move = 0f;
			anim.SetBool("DownSwing", true);
		} 

		if (Input.GetKeyDown (KeyCode.S) && !swinging) {
			StartCoroutine("SwingingCo");
			StartCoroutine("SwingCo");
			swinging = true;
			move = 0f;
			anim.SetBool("SideSwing", true);
		}
	}

	public IEnumerator StrafeCo(){
		yield return new WaitForSeconds(strafeToNormalDelay);
		anim.SetBool ("isStrafing", false);
		strafeCounter = 0;
	}

	public IEnumerator SwingCo(){
		yield return new WaitForSeconds(attackDelay);
		anim.SetBool ("DownSwing", false);
		anim.SetBool ("SideSwing", false);
	}

	public IEnumerator SwingingCo(){
		yield return new WaitForSeconds(swingDelay);
		swinging = false;

	}
}



























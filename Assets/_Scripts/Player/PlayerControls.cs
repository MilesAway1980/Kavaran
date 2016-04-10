using UnityEngine;
using System.Collections;

public class PlayerControls: MonoBehaviour {

	float currentForce;				
	public float acceleration;		
	public float maxAcceleration;
	public float minAcceleration;
	public float slowRate;
	public float reverseRate;

	public float[] jumpForce;
	public float jetForce;

	public float maxVelocity;

	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (rb == null) {
			return;
		}

		//float vertical = Input.GetAxis ("Vertical");
		float horizontal = Input.GetAxis ("Horizontal");
		float delta = Time.deltaTime;

		currentForce += horizontal * delta * acceleration;

		if (Mathf.Abs(horizontal) < minAcceleration) {			
			if (currentForce > 0.01) {
				currentForce -= slowRate;
			} else if (currentForce < -0.01) {
				currentForce += slowRate;
			} else {
				currentForce = 0;
			}
		}

		//Moving right but pushing left
		if (currentForce > 0 && horizontal < 0) {
			currentForce *= reverseRate;
		} else if (currentForce < 0 && horizontal > 0) {
			currentForce *= reverseRate;
		}



		if (currentForce > maxAcceleration) {
			currentForce = maxAcceleration;
		} else if (currentForce < -maxAcceleration) {
			currentForce = -maxAcceleration;
		}

		rb.velocity = new Vector2 (
			currentForce,
			rb.velocity.y
		);

		bool shoot = Input.GetButton ("Shoot");
		bool jump = Input.GetButtonDown ("Jump");
		bool jet = Input.GetButton ("Jet");
		bool onFloor = GetComponent<PlayerSurroundings> ().getOnFloor ();

		int jumpLevel = GetComponent<Player> ().getJumpLevel ();

		if (jump) {
			if (onFloor) {
				Debug.Log ("jump " + Random.Range(0, 100000));
				rb.AddForce (
					new Vector2(0, jumpForce[jumpLevel])
				);
			}
		}

		if (jet) {
			rb.AddForce (
				new Vector2(0, jetForce)
			);
		}

		if (Mathf.Abs(rb.velocity.y) > maxVelocity) {
			if (rb.velocity.y > 0) {
				rb.velocity = new Vector2 (
					rb.velocity.x,
					maxVelocity
				);
			} else {
				rb.velocity = new Vector2 (
					rb.velocity.x,
					-maxVelocity
				);
			}
		}

		if (onFloor) {
			if (rb.velocity.y < 0) {
				rb.velocity = new Vector2 (
					rb.velocity.x, 0
				);
			}
		}

		Debug.Log (rb.velocity.y);
	}
}

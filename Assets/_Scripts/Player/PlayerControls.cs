using UnityEngine;
using System.Collections;

public class PlayerControls: MonoBehaviour {

	float currentForce;				
	public float acceleration;		
	public float maxAcceleration;
	public float minAcceleration;
	public float slowRate;
	public float reverseRate;

	public float maxVelocity;

	Rigidbody2D rb;
	Facing facing;
	Pulse pulse;
	Surroundings surroundings;
	Jump jump;
	Jetpack jetpack;
	Player playerInfo;

	// Use this for initialization
	void Start () {
		facing = GetComponent<Facing> ();
		rb = GetComponent<Rigidbody2D> ();
		pulse = GetComponent<Pulse> ();
		surroundings = GetComponent<Surroundings> ();
		jump = GetComponent<Jump> ();
		jetpack = GetComponent<Jetpack> ();
		playerInfo = GetComponent<Player> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (rb == null) {
			return;
		}

		if (pulse.isActive()) {
			return;
		}

		//float vertical = Input.GetAxis ("Vertical");
		float horizontal = Input.GetAxis ("Horizontal");
		float delta = Time.deltaTime;

		currentForce += horizontal * delta * acceleration;

		facing.setFacing (horizontal);

		if (Mathf.Abs(horizontal) < minAcceleration) {			
			if (currentForce > 0.01) {
				currentForce -= slowRate;
			} else if (currentForce < -0.01) {
				currentForce += slowRate;
			} else {
				currentForce = 0;
			}
		}

		//Moving one direction but pushing the other
		if (currentForce > 0 && horizontal < 0) {
			currentForce *= reverseRate;
		} else if (currentForce < 0 && horizontal > 0) {
			currentForce *= reverseRate;
		}

		//Limit acceleration to prevent going through objects
		if (currentForce > maxAcceleration) {
			currentForce = maxAcceleration;
		} else if (currentForce < -maxAcceleration) {
			currentForce = -maxAcceleration;
		}

		//Only apply force if it is not 0
		if (currentForce != 0) {
			rb.velocity = new Vector2 (
				currentForce,
				rb.velocity.y
			);
		}

		bool shootButton = Input.GetButton ("Shoot");
		bool jumpButton = Input.GetButtonDown ("Jump");
		bool jetButton = Input.GetButton ("Jet");
		bool pulseButton = Input.GetButtonDown ("Pulse");

		int jumpLevel = playerInfo.jumpLevel;
		int jetLevel = playerInfo.jetLevel;

		if (jumpButton) {
			if (surroundings.getOnFloor()) {
				jump.initJump (jumpLevel);
			}
		}

		jetpack.setJetLevel (jetLevel);
		if (jetButton) {			
			jetpack.activate ();
		} else {
			jetpack.deactivate ();
		}

		if (pulseButton) {			
			pulse.initPulse ();
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

		//Only check if the player is on the ground if the jetpack is off
		if (!jetpack.getActive ()) {
			if (surroundings.getOnFloor ()) {
				if (rb.velocity.y < 0) {		
					rb.velocity = new Vector2 (
						rb.velocity.x, 0
					);
				}
			}
		}

		if (rb.velocity.x > 0) {
			if (surroundings.getWallRight ()) {				
				rb.velocity = new Vector2 (
					0, rb.velocity.y
				);
			}
		} else if (rb.velocity.x < 0) {
			if (surroundings.getWallLeft ()) {
				Debug.Log ("against left");
				rb.velocity = new Vector2 (
					0, rb.velocity.y
				);
			}
		}
	}
}

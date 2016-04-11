using UnityEngine;
using System.Collections;

public class Pulse : MonoBehaviour {

	public float pulseDuration;
	public float pulseRegeneration;
	public float pulseSpeed;
	float pulseTime;
	float pulseDir;

	float initialGravity;

	bool active;

	Rigidbody2D rb;
	Facing facing;

	// Use this for initialization
	void Start () {
		pulseTime = 0;
		pulseDir = 0;
		active = false;

		rb = GetComponent<Rigidbody2D> ();
		facing = GetComponent<Facing> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (rb == null) {
			return;
		}

		if (active == false) {
			pulseTime += (pulseRegeneration * Time.deltaTime);
			if (pulseTime > pulseDuration) {
				pulseTime = pulseDuration;
			}
		} else {
			pulseTime -= Time.deltaTime;
			if (pulseTime <= 0) {
				pulseTime = 0;
				active = false;
				rb.gravityScale = initialGravity;
			}
			Debug.Log (pulseDir * pulseSpeed);
			rb.velocity = new Vector2 (
				pulseDir * pulseSpeed, 0
			);
		}
	}

	public void initPulse () {
		if (active == false && pulseTime == pulseDuration) {
			pulseDir = facing.getFacing ();	
			active = true;
			initialGravity = rb.gravityScale;
			rb.gravityScale = 0;
		}

	}

	public bool isActive() {
		return active;
	}
}

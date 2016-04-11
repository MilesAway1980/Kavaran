using UnityEngine;
using System.Collections;

public class Jetpack : MonoBehaviour {

	/*public int[] jetForce;
	public float[] jetTime;
	public float[] jetRegeneration;
	public float[] maxPropulsion;*/

	public float jetForce;
	public float jetRegeneration;
	public float maxPropulsion;
	public float jetTimer;
	public float maxJetTime;

	float startDistance;
	float endDistance;
	public float distance;

	bool active;
	int jetLevel;

	Rigidbody2D rb;
	Surroundings surroundings;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		surroundings = GetComponent<Surroundings> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		makeSettings ();

		bool onFloor = surroundings.getOnFloor ();

		if (active) {
			endDistance = rb.position.y;
			if (distance < Mathf.Abs (startDistance - endDistance)) {
				distance = Mathf.Abs (startDistance - endDistance);
			}

			jetTimer -= Time.deltaTime;
			if (jetTimer > 0) {
				
				rb.AddForce (
					new Vector2 (0, jetForce)
				);

				if (rb.velocity.y > maxPropulsion) {
					rb.velocity = new Vector2 (
						rb.velocity.x, maxPropulsion
					);
				}

			} else {
				jetTimer = 0;
			}
		} else {
			if (onFloor) {
				jetTimer += jetRegeneration * Time.deltaTime;
			} else {
				jetTimer += jetRegeneration * Time.deltaTime * 0.075f;
			}

			if (jetTimer > maxJetTime) {
				jetTimer = maxJetTime;
			}

			/*float maxTime = getJetTime(jetLevel);
			if (jetTimer > maxTime) {
				jetTimer = maxTime;
			}*/


		}

		//Debug.Log ((int)(jetTimer * 1000) + " " + (int)(rb.velocity.y));
	}

	public void setJetLevel(int newJetLevel) {
		jetLevel = newJetLevel;
	}

	public void activate() {
		if (active == false) {
			startDistance = rb.position.y;
			endDistance = startDistance;
			distance = 0;
			active = true;
		}
	}

	public void deactivate() {
		if (active) {
			active = false;
		}
	}

	public bool getActive() {
		return active;
	}

	void makeSettings() {
		int level = jetLevel + 1;

		jetForce = level * 50 + 175;
		jetRegeneration = level * 0.1f + 0.65f;
		maxPropulsion = 15 + level * 0.5f;
		maxJetTime = level * 0.16f + 0.74f;
	}

	/*float getJetTime(int jetLevel) {
		if (jetLevel >= 0 && jetLevel < jetTime.Length) {
			return jetTime[jetLevel];
		} else {
			return 0;
		}
	}*/
}

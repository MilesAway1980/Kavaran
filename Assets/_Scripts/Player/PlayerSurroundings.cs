using UnityEngine;
using System.Collections;

public class PlayerSurroundings : MonoBehaviour {

	GameObject above;
	GameObject below;
	GameObject left;
	GameObject right;

	public float detectDistance;
	public float length;

	bool onFloor;

	// Use this for initialization
	void Start () {
		above = (GameObject)Instantiate (Resources.Load("Prefabs/Detector"));
		below = (GameObject)Instantiate (Resources.Load("Prefabs/Detector"));
		left = (GameObject)Instantiate (Resources.Load("Prefabs/Detector"));
		right = (GameObject)Instantiate (Resources.Load("Prefabs/Detector"));

		above.name = "Detect above";
		below.name = "Detect below";
		left.name = "Detect left";
		right.name = "Detect right";

		above.transform.localScale = new Vector2 (
			length, 1
		);

		below.transform.localScale = new Vector2 (
			length, 1
		);

		left.transform.localScale = new Vector2 (
			1, length
		);

		right.transform.localScale = new Vector2 (
			1, length
		);
	}
	
	// Update is called once per frame
	void Update () {
		above.transform.position = new Vector2 (
			transform.position.x,
			transform.position.y + detectDistance
		);

		below.transform.position = new Vector2 (
			transform.position.x,
			transform.position.y - detectDistance
		);

		left.transform.position = new Vector2 (
			transform.position.x - detectDistance, 
			transform.position.y
		);

		right.transform.position = new Vector2 (
			transform.position.x + detectDistance, 
			transform.position.y
		);

		onFloor = below.GetComponent<WallDetector> ().getContact ();		
		
	}

	public bool getOnFloor() {
		return onFloor;
	}
}

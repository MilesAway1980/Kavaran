using UnityEngine;
using System.Collections;

public class WallDetector : MonoBehaviour {

	bool contact = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col) {		
		if (col.tag == "Block") {
			contact = true;
		} 
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.tag == "Block") {
			contact = false;
		}
	}

	public bool getContact() {
		return contact;
	}
}

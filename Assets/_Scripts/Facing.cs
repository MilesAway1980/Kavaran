using UnityEngine;
using System.Collections;

public class Facing : MonoBehaviour {

	int facing = 1;
		//-1 = left
		//1 = right

	bool jumping = false;
	bool pulsing = false;

	Rigidbody2D rb;

	void Start() {
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update() {
		
	}

	public void setFacing(float newFacing) {
		if (newFacing < 0) {
			facing = -1;
		} else if (newFacing > 0) {
			facing = 1;
		}
	}

	public int getFacing() {
		return facing;
	}
}

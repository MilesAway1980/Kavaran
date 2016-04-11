using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	public int[] jumpForce;
	//bool jumping;
	//bool canJump;

	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		//jumping = false;
		//canJump = false;

		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	int getJumpForce(int jumpLevel) {
		if (jumpLevel >= 0 && jumpLevel < jumpForce.Length) {
			return jumpForce [jumpLevel];
		} else {
			return 0;
		}
	}

	public void initJump(int jumpLevel) {
		rb.AddForce (
			new Vector2(0, getJumpForce(jumpLevel))
		);
	}
}

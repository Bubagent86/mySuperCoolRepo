using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	bool jumping;
	float curJumpVel;
	float startY;

	public float jumpSpd;
	public float gravity;
	public Rigidbody2D ballRB;
	public Vector2 flyForce;
	bool thrown; 

	// Use this for initialization
	void Start () {
		startY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		DealWithInput ();
		if (jumping) {
			DealWithJumping ();
		}
	}

	void DealWithInput () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			if (jumping) {
				ThrowBall();
			} else {
				Jump();
			}
		}
	}

	void Jump () {
		jumping = true;
		curJumpVel = jumpSpd;
	}

	void ThrowBall () {
		if (!thrown) {
			ballRB.isKinematic = false;
			ballRB.transform.parent = null;
			ballRB.AddForce (flyForce, ForceMode2D.Impulse);
			thrown = true;
		}
	}


	void DealWithJumping() {
		transform.position += new Vector3 (0, curJumpVel, 0);
		curJumpVel -= gravity;
		if (transform.position.y <= startY) {
			jumping = false;
			transform.position = new Vector3 (transform.position.x, startY, 0);
		}
	}
}

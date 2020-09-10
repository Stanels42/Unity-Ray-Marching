using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

	public KeyCode keyUp;
	public KeyCode keyDown;
	public KeyCode keyLeft;
	public KeyCode keyRight;

	public float speed;

  // Start is called before the first frame update
  void Start () {
    
  }

  // Update is called once per frame
  void Update () {

		// if (Collider2D.IsTrigger) {
		// 	return;
		// }

		Vector3 direction = new Vector2(0,0);
    if (!KeysCancelOut(keyUp, keyDown)) {
			if (Input.GetKey(keyUp)) {
				direction.y = 1;
			} else if (Input.GetKey(keyDown)) {
				direction.y = -1;
			}
		}
		if (!KeysCancelOut(keyLeft, keyRight)) {
			if (Input.GetKey(keyLeft)) {
				direction.x = -1;
			} else if (Input.GetKey(keyRight)) {
				direction.x = 1;
			}
		}

		transform.position = Vector2.MoveTowards(transform.position, transform.position + direction, speed);
  }

	private bool KeysCancelOut (KeyCode keyOne, KeyCode keyTwo) {
		return Input.GetKey(keyOne) && Input.GetKey(keyTwo);
	}
}

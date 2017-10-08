using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeTest : MonoBehaviour {
	public Swipe swipeControls;
	public Transform player;
	private Vector3 desiredPosition;
	
	// Update is called once per frame
	void Update () {
		if (swipeControls.SwipeLeft) {
			desiredPosition += Vector3.left;
		}
		if (swipeControls.SwipeRight) {
			desiredPosition += Vector3.right;
		}
		if (swipeControls.SwipeUp) {
			desiredPosition += Vector3.up;
		}
		if (swipeControls.SwipeDown) {
			desiredPosition += Vector3.down;
		}

		float targetX = player.transform.position.x + swipeControls.DeltaX;
		float targetY = player.transform.position.y + swipeControls.DeltaY;
		player.transform.position = Vector3.MoveTowards (player.transform.position, desiredPosition, 5f * Time.deltaTime);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveExecution : MonoBehaviour {
	public PlayerMove swipeControls;
	public Transform player;
	private Vector3 desiredPosition;
	
	// Update is called once per frame
	void Update () {
		int diagonal = 0; 
		float moveDistance = 5f;
		//Check diagonal move
		if (swipeControls.SwipeLeft) {
			diagonal++;
		}
		if (swipeControls.SwipeRight) {
			diagonal++;
		}
		if (swipeControls.SwipeUp) {
			diagonal++;
		}
		if (swipeControls.SwipeDown) {
			diagonal++;
		}

		if (diagonal == 2) {
			moveDistance = 3.5f;
		}

		if (swipeControls.SwipeLeft) {
			desiredPosition.x -= moveDistance * swipeControls.ChargeRate;
		}
		if (swipeControls.SwipeRight) {
			desiredPosition.x += moveDistance * swipeControls.ChargeRate;
		}
		if (swipeControls.SwipeUp) {
			desiredPosition.y += moveDistance * swipeControls.ChargeRate;
		}
		if (swipeControls.SwipeDown) {
			desiredPosition.y -= moveDistance * swipeControls.ChargeRate;
		}

		float targetX = player.transform.position.x + swipeControls.DeltaX;
		float targetY = player.transform.position.y + swipeControls.DeltaY;
		player.transform.position = Vector3.MoveTowards (player.transform.position, desiredPosition, 5f * Time.deltaTime);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour {

	private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
	private float deltaX, deltaY;
	private bool isDraging = false;
	private Vector2 startTouch, swipeDelta;

	private void Update(){
		tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;

		if (Input.GetMouseButtonDown (0)) {
			tap = true;
			isDraging = true;
			startTouch = Input.mousePosition;
		} else if (Input.GetMouseButtonUp (0)) {
			isDraging = false;
			Reset ();
		}

		if (Input.touches.Length != 0) {
			if (Input.touches [0].phase == TouchPhase.Began) {
				tap = true;
				isDraging = true;
				startTouch = Input.touches [0].position;
			}else if(Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled){
				isDraging = false;
				Reset ();
			}
		}

		//Calculate distance
		swipeDelta = Vector2.zero;
		if (isDraging) {
			if (Input.touches.Length > 0) {
				swipeDelta = Input.touches [0].position - startTouch;
			} else if (Input.GetMouseButtonDown (0)) {
				swipeDelta = (Vector2)Input.mousePosition - startTouch;
			}
		}

		//Did we cross the deadzone?
		if (swipeDelta.magnitude > 100){
			//Direction
			float x = swipeDelta.x;
			float y = swipeDelta.y;
			deltaX = x;
			deltaY = y;
			Debug.Log (Mathf.Abs (x) / swipeDelta.magnitude);
			Debug.Log (Mathf.Abs (y) / swipeDelta.magnitude);
			if (Mathf.Abs (x) / swipeDelta.magnitude  > 0.45f) {
				if (x < 0) {
					swipeLeft = true;
				} else {
					swipeRight = true;
				}
				
			} 
			if (Mathf.Abs (y) / swipeDelta.magnitude > 0.45f){
				if (y < 0) {
					swipeDown = true;
				} else {
					swipeUp = true;
				}
			}
				
			Reset ();
		}


	}

	private void Reset(){
		startTouch = swipeDelta = Vector2.zero;
		isDraging = false;
	}

	public Vector2 SwipeDelta {get {return swipeDelta;}}
	public bool Tap {get {return tap;}}
	public float DeltaX {get {return deltaX;}}
	public float DeltaY {get {return deltaY;}}
	public bool SwipeLeft {get{ return swipeLeft;}}
	public bool SwipeRight {get{ return swipeRight;}}
	public bool SwipeUp {get{ return swipeUp;}}
	public bool SwipeDown {get{ return swipeDown;}}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour {

	private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
	private float deltaX, deltaY;
	private bool isDraging = false;
	private Vector2 startTouch, swipeDelta;
	private float holdTime = 0.8f;
	private float acumTime = 0;
	private float chargeRate = 0;

	public Text charge;
	public Transform player;
	public GameObject directionPad;
	private GameObject runtimeDirectionPad;

	public Vector2 SwipeDelta {get {return swipeDelta;}}
	public bool Tap {get {return tap;}}
	public float DeltaX {get {return deltaX;}}
	public float DeltaY {get {return deltaY;}}
	public bool SwipeLeft {get{ return swipeLeft;}}
	public bool SwipeRight {get{ return swipeRight;}}
	public bool SwipeUp {get{ return swipeUp;}}
	public bool SwipeDown {get{ return swipeDown;}}
	public float ChargeRate {get{ return chargeRate;}}

	private void Update(){
		tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;

		//Detect touch
		if (Input.touches.Length != 0) {
			acumTime += Input.GetTouch (0).deltaTime;
			if (acumTime >= holdTime) {
				//Holding
				if (acumTime < 3f) {
					chargeRate = acumTime/ 3f;
					charge.text = Mathf.Round (chargeRate * 100) + "%";
					player.GetComponent<SpriteRenderer> ().color = Color.white;
				} else {
					Reset ();
				}

			}

			if (Input.touches [0].phase == TouchPhase.Began) {
				tap = true;
				isDraging = true;
				startTouch = Input.touches [0].position;
				Vector3 fingerpos = Input.GetTouch (0).position;
				fingerpos.z = 5;
				Vector3 objPos = Camera.main.ScreenToWorldPoint (fingerpos);
				runtimeDirectionPad = Instantiate (directionPad, objPos, Quaternion.identity);
			}else if(Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled){
				isDraging = false;
				Destroy (runtimeDirectionPad);
				Reset ();
			}
		}

		checkSwipe ();


	}

	private void checkSwipe(){
		



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
			//Debug.Log (Mathf.Abs (x) / swipeDelta.magnitude);
			//Debug.Log (Mathf.Abs (y) / swipeDelta.magnitude);
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
		acumTime = 0;
		charge.text = "0%";
		//player.GetComponent<SpriteRenderer> ().color = new Color (99, 218, 129);
		player.GetComponent<SpriteRenderer> ().color = new Color32 (99, 218, 129, 255);
	}


}

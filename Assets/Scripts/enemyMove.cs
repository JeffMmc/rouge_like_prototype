using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

	void Start(){
		InvokeRepeating ("randomMove", 0, 0.2f);
	}

	void randomMove(){
		int dir = Random.Range (0, 4);
		Debug.Log (dir);
		switch (dir) {
		case 0:
			transform.Translate (Vector3.up * 0.2f);
			break;
		case 1:
			transform.Translate (Vector3.down * 0.2f);
			break;
		case 2:
			transform.Translate (Vector3.left* 0.2f);
			break;
		case 3:
			transform.Translate (Vector3.right* 0.2f);
			break;
		}
	}
}

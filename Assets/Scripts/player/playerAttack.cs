using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAttack : MonoBehaviour {
	private bool moving;

	void OnTriggerEnter2D (Collider2D col){
		if (col.gameObject.tag == "enemy") {
			Destroy (col.gameObject);
		}

		if (col.gameObject.tag == "exit") {
			SceneManager.LoadScene ("GameOver");
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAttack : MonoBehaviour {
	private bool moving;

	void OnTriggerEnter2D (Collider2D col){
		Debug.Log (col.gameObject.name);
		if (col.gameObject.tag == "enemy") {
			Destroy (col.gameObject);
		}

		if (col.gameObject.tag == "exit") {
			SceneManager.LoadScene ("GameOver");
		}

		if (col.gameObject.tag == "health") {
			PlayerHealth playerHealth = (PlayerHealth)GameObject.Find ("player").GetComponent<PlayerHealth> ();
			if (playerHealth.health < 100){
				playerHealth.recovery (20);
				Destroy (col.gameObject);
			}
		}
	}
}

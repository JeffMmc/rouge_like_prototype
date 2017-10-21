using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public Text healthBar;
	public int health;

	void Start(){
		health = 100;
		healthBar.text = "Health : " + health;
	}

	public void takeDamage(int damage){
		if (health - damage < 0) {
			health = 0;
		} else {
			health = health - damage;
		}
		healthBar.text = "Health : " + health;

		if (health <= 0) {
			SceneManager.LoadScene ("GameOver");
		}
	}

	public void recovery(int recovery){
		if (health + recovery > 100) {
			health = 100;
		} else {
			health = health + recovery;
		}

		healthBar.text = "Health : " + health;
	}
}

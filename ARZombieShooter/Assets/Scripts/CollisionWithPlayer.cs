using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class CollisionWithPlayer : MonoBehaviour {

	// Public properties.
	public int timeBetweenAttack = 2;

	// Private properties.
	private string playerTag = "MainCamera";
	private bool zombieCollided = false;
	private float timer;
	private GameController gameController;
	private string gameControllerTag = "GameController";

	// Use this for initialization
	void Start () {
		/// Set initial values.
		timer = 0.0f;

		/// Get game controller script.
		GameObject gameControllerObject = GameObject.FindWithTag(gameControllerTag);
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		/// Set timer on every frame.
		timer += Time.deltaTime;

		if (zombieCollided && timer >= timeBetweenAttack ) {
			/// Zombie have collided with player so start attack animation.
			Attack ();
		}
	}

	// Collision detected.
	void OnCollisionEnter (Collision collision) {
		if (collision.gameObject.tag == playerTag) {
			/// Zombie have collided.
			zombieCollided = true;
		}
	}

	// Collision ended.
	void OnCollisionExit (Collision collision) {
		if (collision.gameObject.tag == playerTag) {
			/// Cancel zombie collision.
			zombieCollided = false;
		}
	}

	// Attack.
	void Attack () {
		/// Reset timer every time enemy attacks player.
		timer = 0.0f;

		/// Play attack animation.
		GetComponent<Animator> ().Play("attack");

		/// Notify game controller that zombie attacked player.
		if (gameController != null) {
			gameController.ZombieAttack (zombieCollided);
		}
	}
}
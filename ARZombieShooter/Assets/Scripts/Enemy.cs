using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	// Public properties.
	public float health = 30.0f;
	public float removeEnemyFromGameDelay = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// ****** PRIVATE METHODS ****** //

	void OnTakeDamege (float damage) {
		// Reduce health.
		health -= damage;

		// Check if enemy is dead.
		if (health <= 0.0f) {
			// TODO: Maybe create death animation.
			// Destroy enemy.
			Die ();
		}
	}

	void Die () {
		// Destroy game object after delay (so we can play death animation).
		Destroy(gameObject, removeEnemyFromGameDelay);
	}

	// ****** PUBLIC METHODS ****** //

	public void TakeDamage (float damage) {
		// Enemy was hit so reduce damage.
		OnTakeDamege (damage);
	}		
}

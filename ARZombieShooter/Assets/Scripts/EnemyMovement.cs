using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public float movementSpeed = 0.3f;

	// Update is called once per frame
	void Update () {
		/// Move enemy forward.
		transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);

		/// Move enemy in direction of the player (main camera).
		transform.LookAt(Camera.main.transform.position);

		/// Make sure that enemy is only moving on x component.
		transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
	}
}

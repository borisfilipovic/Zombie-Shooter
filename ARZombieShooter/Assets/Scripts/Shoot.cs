using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class Shoot : MonoBehaviour {

	// Public properties.
	public float weaponDamage = 10.0f;
	public float forceAdd = 300f;

	// Private properties.
	[SerializeField]
	private Button shootButton;

	[SerializeField]
	private Camera fpsCamera;

	[SerializeField]
	private GameObject bloodEffect;

	[SerializeField]
	private GameObject shootingEffect;

	// Use this for initialization
	void Start () {
		// Assert not nil.
		Assert.IsNotNull (shootButton);
		Assert.IsNotNull (fpsCamera);
		Assert.IsNotNull (bloodEffect);
		Assert.IsNotNull (shootingEffect);

		// Add button listener.
		shootButton.onClick.AddListener(OnShoot);
	}

	/// <summary>
	/// Shoot enemy method. This method will fire bullet against enemy.
	/// </summary>
	void OnShoot () {
		// Shoot physics raycast.
		RaycastHit hit;
		if (Physics.Raycast (fpsCamera.transform.position, fpsCamera.transform.forward, out hit)) { // We hit something.
			// Destroy enemy. First we need to get enemy's script.
			Enemy targetEnemyScript = hit.transform.GetComponent<Enemy> ();
			if (targetEnemyScript != null) { // Here we actually check if we hit enemy.
				// Reduce enemy's health.
				targetEnemyScript.TakeDamage (weaponDamage);

				// Create and destroy particle effect.
				CreateAndDestroyParticleEffect(bloodEffect, 0.2f, hit);
			} else { // We did not hit enemy so lets just fire shooting effect.
				// Create and destroy particle effect.
				CreateAndDestroyParticleEffect(shootingEffect, 0.2f, hit);
			}

			// If we hit rigid body then add some force to it.
			if (hit.rigidbody != null) {
				hit.rigidbody.AddForce(-hit.normal * 
			}

			// Load shooting effect.
			Debug.Log(hit.transform.name);
		}
	}

	/// <summary>
	/// Creates and destroys particle effect.
	/// </summary>
	/// <param name="effect">Effect to instantiate.</param>
	/// <param name="destroyAfterDelay">Destroy particle effect after delay.</param>
	/// <param name="hit">RaycastHit.</param>
	void CreateAndDestroyParticleEffect(GameObject effect, float destroyAfterDelay, RaycastHit hit) {
		// Instantiate particle effetct.
		GameObject particleEffectGameObject = Instantiate (effect, hit.point, Quaternion.LookRotation (hit.normal)); 

		// Destroy blood effect after short time.
		Destroy (particleEffectGameObject, destroyAfterDelay);
	}
}

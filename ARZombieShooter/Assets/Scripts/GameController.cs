using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	// Public properties.
	public GameObject bloodyScreen;
	public Text healthText;
	public int health = 100;
	public int enemyDamage = 5;

	// Private properties.
	public float bloodyScreenDuration = 2.0f;

	// Use this for initialization
	void Start () {
		/// Assert game objects.
		Assert.IsNotNull(bloodyScreen);
	}

	// Update is called once per frame.
	void Update () {
		/// Check if player have any life left.
		if (health <= 0) {
			/// TODO: - Load game over scene.
			/// SceneManager.LoadScene("GameOver");
		}
	}

	public void ZombieAttack() {
		/// Show bloody screen.
		BloodyScreen(true);

		/// Player have been hit so decrease players health.
		PlayerHaveBeenHit ();
	}

	public void ZombieStoppedAttacking () {
		/// Remove bloody screen after time duration.
		StartCoroutine(removeBloodyScreenAfterSomeTime());
	}

	void PlayerHaveBeenHit () {
		/// Decrease player's health.
		health -= enemyDamage;

		/// Display new health on screen.
		string stringHealth = health.ToString();
		healthText.text = "" + stringHealth;
	}

	/// <summary>
	/// Bloodies the screen.
	/// </summary>
	/// <param name="active">If set to <c>true</c> active.</param>
	void BloodyScreen(bool active) {
		bloodyScreen.SetActive (active);
	}


	/// <summary>
	/// Removes the bloody screen after some time.
	/// </summary>
	/// <returns>The bloody screen after some time.</returns>
	IEnumerator removeBloodyScreenAfterSomeTime () {
		/// Wait 2 seconds.
		yield return new WaitForSeconds (bloodyScreenDuration);

		/// Hide bloody screen.
		BloodyScreen(false);
	}
}
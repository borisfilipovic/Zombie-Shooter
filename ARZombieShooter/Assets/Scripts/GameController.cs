using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameController : MonoBehaviour {

	// Public properties.
	public GameObject bloodyScreen;

	// Private properties.
	public float bloodyScreenDuration = 2.0f;

	// Use this for initialization
	void Start () {
		/// Assert game objects.
		Assert.IsNotNull(bloodyScreen);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ZombieAttack(bool zombieCollided) {
		/// Show bloody screen.
		BloodyScreen(true);

		/// Remove bloody screen after time duration.
		removeBloodyScreenAfterSomeTime ();
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
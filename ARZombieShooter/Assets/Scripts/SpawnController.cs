using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class SpawnController : MonoBehaviour {

	// Public properties.
	[SerializeField]
	private GameObject enemy;

	[SerializeField]
	private Button startBtn;

	public float time = 2.0f;
	public float repeatRate = 4.0f;


	// Use this for initialization
	void Start () {
		// Assert that we have included all necessary elements.
		Assert.IsNotNull (enemy);
		Assert.IsNotNull (startBtn);

		// Add onClick listener to check when we should start respawning enemyies.
		startBtn.onClick.AddListener(StartInvoke);
	}
	
	/// <summary>
	/// Starts the invoke of respawning enemy.
	/// </summary>
	void StartInvoke () {
		// Invoke enemyies.
		InvokeRepeating("Spawn", time, repeatRate);
	}

	/// <summary>
	/// Instantiate the enemy.
	/// </summary>
	void Spawn () {
		// Random position.
		Vector3 randomPosition = new Vector3(Random.Range(-10.0f, 10.0f), 0.0f, Random.Range(-10.0f, 10.0f));

		// Instantiate enemy.
		Instantiate(enemy, randomPosition, Quaternion.identity);
	} 
}
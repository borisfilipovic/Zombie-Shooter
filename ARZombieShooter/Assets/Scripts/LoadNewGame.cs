using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadNewGame : MonoBehaviour {

	// Public property.
	public Button newGame;

	// Use this for initialization
	void Start () {
		// Add button listener.
		newGame.onClick.AddListener(LoadGame);
	}

	void LoadGame () {
		// Load new scene.
		SceneManager.LoadScene("Scene01");
	}
}

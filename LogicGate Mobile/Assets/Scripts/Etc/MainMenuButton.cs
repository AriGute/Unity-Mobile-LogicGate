using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuButton : MonoBehaviour {
	public Image FadeScreen;
	float time = 0;

	public void Start(){
		FadeScreen.gameObject.SetActive (true);
		FadeScreen.CrossFadeAlpha (0f, 5, false);
	}

	public void Update(){
		if (time > 1) {
			time -= Time.deltaTime;
		} else {
			if (time > 0.5f) {
				SceneManager.LoadScene ("Game");
			}
		}
	}

	public void Fade(){
		FadeScreen.CrossFadeAlpha (1f, 3, true);
		time = 5;
	}
}

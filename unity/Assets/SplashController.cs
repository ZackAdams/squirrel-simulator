using UnityEngine;
using System.Collections;

public class SplashController : MonoBehaviour {

	public GUITexture splashView;
	public Texture2D splashTitle;
	public Texture2D splashStartGame;
	public GUIText startGame;
	public GUIText quitGame;

	// Use this for initialization
	void Start () {
		splashView.texture = splashTitle;
		Invoke("nextScene", 8);
	}

	void nextScene () {
		splashView.texture = splashStartGame;
		startGame.text = "Start the Game";
		quitGame.text = "Quit Game";
	}
	// Update is called once per frame
	void Update () {
	
	}
}

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
		startGame.text = "";
		quitGame.text = "";
	}

	void nextScene () {
		splashView.texture = splashStartGame;
		startGame.text = "Start the Game";
		quitGame.text = "Quit Game";

	}
	private void OnGUI()
	{
		if(GUI.Button(new Rect(0, 0, 200, 50), "" + startGame.text))
		{
			Application.LoadLevel ("main");
		}
	}
}

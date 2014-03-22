using UnityEngine;
using System.Collections;

public class SplashController : MonoBehaviour {

	public GUITexture splashView;
	public Texture2D splashTitle;
	public Texture2D splashStartGame;
	public Texture startGame;
	public Texture quitGame;

	// Use this for initialization
	void Start () {
		splashView.texture = splashTitle;
		Invoke("nextScene", 5);
	}

	void nextScene () {
		splashView.texture = splashStartGame;
	}

	private void OnGUI()
	{
		Color c = GUI.backgroundColor;
		GUI.backgroundColor = Color.clear;

		if(GUI.Button(new Rect(300, 230, 150, 40), startGame))
		{
			Application.LoadLevel ("main");
		}
		if(GUI.Button(new Rect(300, 280, 150, 40), quitGame))
		{
			Application.Quit();
		}
	}
}

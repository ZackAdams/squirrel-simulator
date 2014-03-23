using UnityEngine;
using System.Collections;

public class SplashController : MonoBehaviour {

	public GUITexture splashView;
	public Texture2D splashTitle;
	public Texture2D splashStartGame;
	public Texture startGame;
	public Texture quitGame;
	private bool hideGui = false;

	// Use this for initialization
	void Start () {
		splashView.texture = splashTitle;
		Invoke("nextScene", 5);
	}

	void nextScene () {
		hideGui = true;
		splashView.texture = splashStartGame;
	}

	private void OnGUI()
	{
		GUI.backgroundColor = Color.clear;

		if (hideGui) {
			GUILayout.BeginArea (new Rect(Screen.width*0.25F, Screen.height*0.4F, Screen.width*0.5F, Screen.height*0.6F));
			GUILayout.Box ("Find the Nuts!");
			GUILayout.Box ("You can store 3 at a time.");
			GUILayout.Box ("Store the Nuts in mounds");
			GUILayout.Box ("When Winter happens, find your Nuts");
			GUILayout.Box ("Are you Ready?");
			if (GUILayout.Button("Begin the Hunt")){
				Application.LoadLevel ("main");
			}
			if (GUILayout.Button ("Suicide")){
				Application.Quit ();
			}
			GUILayout.EndArea ();
		}
	}
}

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
		if (hideGui) {
			GUI.backgroundColor = Color.clear;
			splashView.texture = null;
			GUILayout.BeginArea (new Rect(Screen.width*0.25F, Screen.height*0.2F, Screen.width*0.5F, Screen.height*0.8F));
			GUILayout.Box ("Find the Nuts!");
			GUILayout.Box ("You can carry 3 nuts at a time.");
			GUILayout.Box ("Store the nuts in mounds on the ground.");
			GUILayout.Box ("When it becomes winter, retrieve your nuts from the mounds.");
			GUILayout.Box ("Deposit your nuts at the large tree in the center of the willow forrest.");
			GUILayout.Box ("Help your family survive winter!");
			GUILayout.Box ("Are you Ready?");
			GUI.backgroundColor = Color.blue;
			if (GUILayout.Button("BEGIN THE HUNT")){
				Application.LoadLevel ("main");
			}
			if (GUILayout.Button ("EXIT GAME")){
				Application.Quit ();
			}
			GUILayout.EndArea ();
		}
	}
}

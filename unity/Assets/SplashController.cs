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
		//commenting out to see if anything changes, as c is never used <Michael>
		//Color c = GUI.backgroundColor;
		GUI.backgroundColor = Color.clear;

		if (hideGui) {
			GUILayout.BeginArea (new Rect(Screen.width*0.4F, Screen.height*0.5F, Screen.width*0.2F, Screen.height*0.3F));
			GUILayout.Box ("Are you Ready?");
			if (GUILayout.Button("Begin the Hunt")){
				Application.LoadLevel ("main");
			}
			if (GUILayout.Button ("Suicide")){
				Application.Quit ();
			}
			GUILayout.EndArea ();
//			Old start buttons <Michael>			
//			if(GUI.Button(new Rect(300, 230, 150, 40), startGame))
//			{
//				Application.LoadLevel ("main");
//			}
//			if(GUI.Button(new Rect(300, 280, 150, 40), quitGame))
//			{
//				Application.Quit();
//			}
		}
	}
}

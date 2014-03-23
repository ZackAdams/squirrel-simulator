using UnityEngine;
using System.Collections;

public class HUDMenu : MonoBehaviour {

	private bool menuExpanded = false;
	private bool menuCollapsed = true;
	private bool menuMain = false;
	private bool menuDebug = false;
	public bool testSeed = false;
	public string message = "";
	public string playername = "Squirelly";
	public float testing = 10.0F;
	public GUIStyle menuStyle;
	public Texture menuButton;
	
	
	// Use this for initialization
	void Start () {
		//playername = PlayerPrefs.SetString("Michael", "Foobar");
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnGUI (){
		if (menuCollapsed) {
			if (GUI.Button (new Rect (0, Screen.height * 0.4F, Screen.width * 0.1F, Screen.height * 0.2F), menuButton)) {
				menuExpanded = true;
				menuMain = true;
				menuCollapsed = false;
			}
		}
		
		if (menuExpanded) {
			if (GUI.Button (new Rect (Screen.width*0.5F, Screen.height*0.4F, Screen.width * 0.1F, Screen.height*0.2F), menuButton)){
				menuCollapsed = true;
				menuExpanded = false;
				menuMain = false;
				menuDebug = false;
			}
		}
		
		if (menuMain) {
			GUILayout.BeginArea (new Rect (0,0, Screen.width/2, Screen.height));
			GUILayout.Box (playername);
			if (GUILayout.Button ("Restart", GUILayout.Height (Screen.height*0.1F))){
				menuMain = false;
				Application.LoadLevel ("splashscreen");
			}
			if (GUILayout.Button ("Quit", GUILayout.Height (Screen.height*0.1F))){
				menuMain = false;
				Application.Quit();
				//menuBag = true;
			}
			if (GUILayout.Button ("Options", GUILayout.Height (Screen.height*0.1F))){
				menuMain = false;
				//menuOptions = true;
			}
			if (GUILayout.Button ("Debug - Scene Select", GUILayout.Height (Screen.height*0.1F))){
				menuMain = false;
				menuDebug = true;
			}
			GUILayout.TextField (message, 160, GUILayout.Height (Screen.height*0.5F));
			GUILayout.EndArea ();
		}
		
		if (menuDebug) {
			GUILayout.BeginArea (new Rect (0,0, Screen.width/2, Screen.height));
//			if (GUILayout.Button ("Main Menu", GUILayout.Height (Screen.height*0.1F))){
//				menuDebug = false;
//				menuMain = true;
//			}
			if (GUILayout.Button ("Splash Screen", GUILayout.Height (Screen.height*0.1F))){
				Application.LoadLevel ("splashscreen");
			}
			if (GUILayout.Button ("loading", GUILayout.Height (Screen.height*0.1F))){
				Application.LoadLevel ("loading");
			}
			if (GUILayout.Button ("main", GUILayout.Height (Screen.height*0.1F))){
				Application.LoadLevel ("main");
			}
			if (GUILayout.Button ("winter", GUILayout.Height (Screen.height*0.1F))){
				Application.LoadLevel ("winter");
			}
			GUILayout.EndArea ();
		}
	}
}

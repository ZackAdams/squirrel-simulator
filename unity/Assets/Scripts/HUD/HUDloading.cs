using UnityEngine;
using System.Collections;

public class HUDloading : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		GUILayout.BeginArea (new Rect (Screen.width*0.3F, Screen.height*0.5F, Screen.width*0.4F, Screen.height*0.5F));
		GUILayout.Box ("Winter is Coming......");
		GUILayout.Box ("Your Mother in law be right,");
		GUILayout.Box ("turns out rocks aren't edible");
		GUILayout.Box ("You collected");
		if (GUILayout.Button ("Begin Winter")) {
			Application.LoadLevel ("Winter");
		}
		GUILayout.EndArea ();
	}

}

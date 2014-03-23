using UnityEngine;
using System.Collections;


public class HudDisplay : MonoBehaviour {


	public GUIText alertMessage;
	public GUIText nutsCollected;
	public GUIText hunger;

	// Use this for initialization
	void Start () {
		alertMessage.text = "";
		nutSetText (1);
		hungerSetText ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void nutSetText(int nuts) {
		nutsCollected.text = "Nuts: 1";
	}

	void hungerSetText () {
		hunger.text = "Hunger: Very Hungry";
	}

}

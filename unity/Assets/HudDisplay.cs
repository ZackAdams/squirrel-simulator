using UnityEngine;
using System.Collections;


public class HudDisplay : MonoBehaviour {
	
	public GUIText alertMessage;
	public GUIText nutsCollected;
	public GUIText hunger;
	public GUIText displayTimer;
	public CharacterStats player;
	public float collectTimer;

	// Use this for initialization
	void Start () {
		alertMessage.text = "";
		nutSetText (0);
		if (true) 
		{
			hunger.text = "";
		} 
		else 
		{
			hungerSetText ();
		}
		hungerSetText ();
		collectTimer = 60.0f;
	}
	
	// Update is called once per frame
	void Update () {

		collectTimer -= Time.deltaTime;
		setTimerText (collectTimer);
		nutSetText ( player.nutCount );

		if (collectTimer <= 0.0f)
		{
			Debug.Log("Time finished");
			Application.LoadLevel ("loading");
		}

		
	}

	void setTimerText(float time) {
		displayTimer.text = "Time: " + time.ToString ();
	}

	void nutSetText(int nuts) {
		nutsCollected.text = "Nuts: " + nuts.ToString();
	}

	void hungerSetText () {
		hunger.text = "Hunger: Very Hungry";
	}

}

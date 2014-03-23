using UnityEngine;
using System.Collections;


public class HudDisplay : MonoBehaviour {
	
	public GUIText alertMessage;
	public GUIText nutsCollected;
	public GUIText hunger;
	public GUIText displayTimer;
	public CharacterStats player;
	public float fallTimelimit = 60;
	public float winterTimelimit = 60;
	public float currentTime;
	private float currentTimelimit;
	public Terrain terrain;
	public Material winterMaterial;
	private bool isWinter = false;
	private Vector3 spawnPosition;
	private Quaternion spawnRotation;

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
		currentTimelimit = fallTimelimit;
		currentTime = currentTimelimit;
		spawnPosition = player.transform.position;
		spawnRotation = player.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {

		currentTimelimit -= Time.deltaTime;
		setTimerText (currentTimelimit);
		nutSetText ( player.nutCount );

		if (currentTimelimit <= 0.0f)
		{
			Debug.Log("Time finished");
			if (isWinter) {
				endGame();
			} else {
				switchToWinter();
				respawn();
			}
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

	void endGame() {
		//GAME OVER code goes here
	}

	void switchToWinter() {
		isWinter = true;
		currentTimelimit = winterTimelimit;
		//Turn on snow
		//terrain.renderer.material = winterMaterial;
		terrain.materialTemplate = winterMaterial;
		//Hide grass
		terrain.detailObjectDistance = 0;
		//Turn off shadows, helps snow look better
		terrain.castShadows = false;
	}

	void respawn() {
		currentTime = currentTimelimit;
		player.transform.position = spawnPosition;
		player.transform.rotation = spawnRotation;
	}

}

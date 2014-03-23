﻿using UnityEngine;
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
	public NutController nutController;
	private bool isWinter = false;
	private Vector3 spawnPosition;
	private Quaternion spawnRotation;
	public FamilyTree familyTree;

	// Use this for initialization
	void Start () {
		alertMessage.text = "";
		nutSetText (0);
		if (true) 
		{
			hunger.text = "";
		} 
//		Unity claims this to be unreachable
//		else 
//		{
//			hungerSetText ();
//		}
		currentTimelimit = fallTimelimit;
		resetTimer ();
	}

	void resetTimer() {
		currentTime = currentTimelimit;
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
				nutController.destroyNuts();
				resetTimer();
				player.reSpawn();
				switchToWinter();
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
		//bool an OnGUI function true to display a box with Game Over label, grays the screen out
		//show score
		//disable player movement
		//button to restart
		//button to quit
	}

	void switchToWinter() {
		isWinter = true;
		familyTree.isWinter = true;
		currentTimelimit = winterTimelimit;
		//Turn on snow
		//terrain.renderer.material = winterMaterial;
		terrain.materialTemplate = winterMaterial;
		//Hide grass
		terrain.detailObjectDistance = 0;
		//Turn off shadows, helps snow look better
		terrain.castShadows = false;
	}

}

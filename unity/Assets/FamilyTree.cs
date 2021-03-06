﻿using UnityEngine;
using System.Collections;

public class FamilyTree : MonoBehaviour {
	public GUIText target;
	public int nutCountFamily;
	public CharacterStats player;
	private bool selected = false;
	public bool isWinter;
	public bool isCompletedTree;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		renderer.material.color = Color.white;
		selected =false;
		target.text = "";
	}
	
	public void OnLook ()
	{
		if(HudDisplay.isWinter)
		{
			renderer.material.color = Color.red;
			if(player.nutCount != 0){
				target.text = "Press E to Give Nut";
			}
			else{
				target.text = "So hungry, please get us nuts!";
			}
			selected = true;
		}
	}
	
	public void OnGUI(){
		Event currEvent = Event.current;
		//Insert that nut into the hole... heh
		if(currEvent.isKey && currEvent.character == 'e' && selected)
		{
			if(player.nutCount <= 3 && player.nutCount != 0)
			{
				player.nutCount--;
				nutCountFamily++;
				player.collectedNutToFamily(nutCountFamily);
			}
			
		}
	}
}

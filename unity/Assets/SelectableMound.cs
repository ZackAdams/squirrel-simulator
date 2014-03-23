using UnityEngine;
using System.Collections;

public class SelectableMound : Selectable {
	public GUIText target;
	public GameObject player;
	public int nutCountHole;

	public void Start() {
	}

	public void Update() {
		if (selected) {
			if (nutCountHole == 1) {
					target.text = "Press R to grab Nut";
			} else if (player.GetComponent<CharacterStats> ().nutCount != 0) {
					target.text = "Press E to drop Nut";
			} else if(!HudDisplay.isWinter) {
					target.text = "Go GET NUTS!! GO GO GO GOOOOO!";
			}
		}
	}

	public override void OnSelect() {
		base.OnSelect ();
		//Debug.Log ("Selected mound object");
		renderer.material.color = Color.red;
	}

	public override void OnDeselect() {
		base.OnDeselect ();
		//Debug.Log ("Deselected mound object");
		renderer.material.color = Color.white;
		target.text = "";
	}

	public void OnGUI(){
		Event currEvent = Event.current;
		//Insert that nut into the hole... heh
		if(currEvent.isKey && currEvent.character == 'e' && selected)
		{
			if(player.GetComponent<CharacterStats>().nutCount <= 3 && nutCountHole == 0 && player.GetComponent<CharacterStats>().nutCount != 0)
			{
				player.GetComponent<CharacterStats>().nutCount--;
				nutCountHole++;
				player.GetComponent<CharacterStats>().OnNutBury();
			}
			
		}
		
		//Quick pull the nut out
		if(currEvent.isKey && currEvent.character == 'r' && selected)
		{
			if(player.GetComponent<CharacterStats>().nutCount < 3 && nutCountHole != 0 && player.GetComponent<CharacterStats>().nutCount != 3)
			{
				player.GetComponent<CharacterStats>().nutCount++;
				nutCountHole--;
				player.GetComponent<CharacterStats>().OnNutUnbury();
			}
		}
	}
}

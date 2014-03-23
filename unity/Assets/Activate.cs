using UnityEngine;
using System.Collections;

public class Activate : MonoBehaviour {
	public GUIText target;
	public int nutCountHole;
	public GameObject player;
	private bool selected = false;

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
		renderer.material.color = Color.red;
		if(nutCountHole == 1)
		{
			target.text = "Press R to grab Nut";
		}
		else if(player.GetComponent<CharacterStats>().nutCount != 0){
			target.text = "Press E to drop Nut";
		}
		else{
			target.text = "Go GET NUTS!! GO GO GO GOOOOO!";
		}
		selected = true;
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

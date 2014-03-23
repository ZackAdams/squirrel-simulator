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
	}

	public void OnLook ()
	{
		renderer.material.color = Color.red;
		target.text = "Do shit";
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
			}
			
		}

		//Quick pull the nut out
		if(currEvent.isKey && currEvent.character == 'r' && selected)
		{
			if(player.GetComponent<CharacterStats>().nutCount < 3 && nutCountHole != 0 && player.GetComponent<CharacterStats>().nutCount != 3)
			{
				player.GetComponent<CharacterStats>().nutCount++;
				nutCountHole--;
			}
		}
	}
}

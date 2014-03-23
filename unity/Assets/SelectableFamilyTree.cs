using UnityEngine;
using System.Collections;

public class SelectableFamilyTree : Selectable {
	public GUIText target;
	public int nutCountFamily;
	public CharacterStats player;
	public bool isWinter;
	public bool isCompletedTree;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(isWinter && selected) {
			if(player.nutCount != 0) {
				target.text = "Press E to Give Nut";
			} else{
				target.text = "So hungry, please get us nuts!";
			}
		}
	}

	public override void OnSelect() {
		base.OnSelect ();
		if (isWinter) {
		 renderer.material.color = Color.red;
		}
	}

	public override void OnDeselect() {
		base.OnDeselect ();
		if (isWinter) {
			renderer.material.color = Color.white;
		}
		target.text = "";
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

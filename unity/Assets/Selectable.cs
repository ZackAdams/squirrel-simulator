using UnityEngine;
using System.Collections;

public class Selectable : MonoBehaviour {
	//public GUIText target;
	//public int nutCountHole;
	//public GameObject player;
	public bool selected = false;
	
	public virtual void OnSelect () {
		//Debug.Log ("Selected object");
		selected = true;
	}

	public virtual void OnDeselect () {
		//Debug.Log ("Deselected object");
		selected = false;
	}
}

using UnityEngine;
using System.Collections;

public class Select : MonoBehaviour {
	public RaycastHit hit;

	private GameObject selectedObject = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2,0));
		bool gotHit = Physics.Raycast (ray, out hit, 2);
		if(gotHit) {
			if( isSelectable(hit.collider.gameObject) && !isObjectSelected()) {
				//Debug.Log ("Selecting Object");
				selectObject(hit.collider.gameObject);
			}
		} else if (isObjectSelected()){
			deselectObject(selectedObject);
		}
	}

	private bool isSelectable(GameObject gameObject) {
		bool selectable = gameObject.GetComponent<Selectable>() != null;
		//Debug.Log ("Object is selectable: " + selectable.ToString());
		return selectable;
	}

	private bool isObjectSelected() {
		return (selectedObject != null);
	}
	
	private void selectObject(GameObject gameObject) {
		selectedObject = gameObject;
		selectedObject.GetComponent<Selectable>().OnSelect ();
	}
	
	private void deselectObject(GameObject gameObject) {
		selectedObject.GetComponent<Selectable>().OnDeselect ();
		selectedObject = null;
	}
}

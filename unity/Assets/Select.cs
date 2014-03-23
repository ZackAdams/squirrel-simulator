using UnityEngine;
using System.Collections;

public class Select : MonoBehaviour {
	public RaycastHit hit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2,0));
		if(Physics.Raycast(ray, out hit))
		{
			if(hit.collider.GetComponent<Activate>() != null)
			{
				hit.collider.gameObject.GetComponent<Activate>().OnLook();
			}
		}
	}
}

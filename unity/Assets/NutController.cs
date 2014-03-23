using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NutController : MonoBehaviour {

	public Terrain terrain;
	public int numberOfNuts = 100;
	public Transform nutPrefab;

	// Use this for initialization
	void Start () {
		generateNuts ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void generateNuts () {
		//Get terrain size
		Vector3 size = terrain.terrainData.size;
		Debug.Log ("Terrain size: " + size.ToString ());
		//Create a bunch of nuts at random positions on the map
		for (int i = 0; i < numberOfNuts; i++) {
			float x = Random.Range(0,size.x);
			float z = Random.Range(0,size.z);
			float y = terrain.SampleHeight(new Vector3(x,0,z)) + nutPrefab.localScale.y;
			Vector3 position = new Vector3(x, y, z);
			Debug.Log ("Nut position: " + position.ToString());
			
			float y_rotation = Random.Range(0,360);
			
			var nut = Instantiate(nutPrefab, position, Quaternion.identity);
			((Transform)nut).Rotate(0, y_rotation, 0, 0);
			((Transform)nut).parent = this.transform;
		}
	}

	public void destroyNuts () {
		foreach (Transform nut in transform) {
			Destroy(nut.gameObject);
		}
	}
}

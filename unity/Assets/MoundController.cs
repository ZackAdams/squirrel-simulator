using UnityEngine;
using System.Collections;

public class MoundController : MonoBehaviour {

	public Terrain terrain;
	public int numberOfMounds = 100;
	public Transform moundPrefab;
	public Material winterMaterial;
	
	public GUIText target;
	public GameObject player;

	// Use this for initialization
	void Start () {
		generateMounds ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void generateMounds() {
		//Get terrain size
		Vector3 size = terrain.terrainData.size;
		//Create a bunch of nuts at random positions on the map
		for (int i = 0; i < numberOfMounds; i++) {
			float x = Random.Range(0,size.x);
			float z = Random.Range(0,size.z);
			float y = terrain.SampleHeight(new Vector3(x,0,z));
			Vector3 position = new Vector3(x, y, z);

			var nut = Instantiate(moundPrefab, position, Quaternion.identity);
			((Transform)nut).parent = this.transform;
			((Transform)nut).GetComponent<SelectableMound>().target = target;
			((Transform)nut).GetComponent<SelectableMound>().player = player;
		}
	}

	public void destroyMounds() {
		foreach (Transform mound in transform) {
			Destroy(mound.gameObject);
		}
	}

	public void winterizeMounds(){
		foreach (Transform mound in transform) {
			mound.renderer.material = winterMaterial;
			mound.renderer.castShadows = false;
		}
	}
}

using UnityEngine;
using System.Collections;

public class CharacterStats : MonoBehaviour {

	public int nutCapacity = 3;
	public int nutCount = 3;
	public float maxHealth = 100;
	public float health = 100;
	private int buriedCount = 0;

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "acorn" && nutCount < nutCapacity) {
			other.gameObject.SetActive(false);
			nutCount++;
		}
	}

	public void OnNutBury() {
		buriedCount++;
		Debug.Log ("Buried Count: " + buriedCount);
	}
	public void OnNutUnbury() {
		buriedCount--;
		Debug.Log ("Buried Count: " + buriedCount);
	}

}

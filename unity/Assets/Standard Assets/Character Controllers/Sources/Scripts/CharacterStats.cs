using UnityEngine;
using System.Collections;

public class CharacterStats : MonoBehaviour {

	public int nutCapacity = 3;
	public int nutCount = 0;
	public float maxHealth = 100;
	public float health = 100;

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "acorn" && nutCount < nutCapacity) {
			other.gameObject.SetActive(false);
			nutCount++;
		}
	}

}

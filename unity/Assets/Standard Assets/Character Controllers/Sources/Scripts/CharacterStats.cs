using UnityEngine;
using System.Collections;

public class CharacterStats : MonoBehaviour {

	public int nutCapacity = 3;
	public int nutCount = 3;
	public float maxHealth = 100;
	public float health = 100;
	private int buriedCount = 0;
	public int nutsCollected = 0;
	private Vector3 spawnPosition;
	private Quaternion spawnRotation;

	public void Start() {
		spawnPosition = transform.position;
		spawnRotation = transform.rotation;
	}

	public void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "acorn" && nutCount < nutCapacity) {
			other.gameObject.SetActive(false);
			nutCount++;
		}
	}

	public void collectedNutToFamily(int newCollect) {
		nutsCollected = newCollect;
	}

	public void OnNutBury() {
		buriedCount++;
		Debug.Log ("Buried Count: " + buriedCount);
	}

	public void OnNutUnbury() {
		buriedCount--;
		Debug.Log ("Buried Count: " + buriedCount);
	}

	public void resetNutCount() {
		nutCount = 0;
	}

	public void resetHealth() {
		health = maxHealth;
	}

	public void reSpawn() {
		resetNutCount ();
		resetHealth ();
		transform.position = spawnPosition;
		transform.rotation = spawnRotation;
	}

}

using UnityEngine;
using System.Collections;


public class HudDisplay : MonoBehaviour {
	
	public GUIText alertMessage;
	public GUIText nutsCollected;
	public GUIText hunger;
	public GUIText displayTimer;
	public CharacterStats player;
	public float fallTimelimit = 60;
	public float winterTimelimit = 60;
	public float currentTime;
	private float currentTimelimit;
	public Terrain terrain;
	public Material winterMaterial;
	public NutController nutController;
	public MoundController moundController;
	public static bool isWinter = false;
	private Vector3 spawnPosition;
	private Quaternion spawnRotation;
	public SelectableFamilyTree familyTree;
	public bool showStats = true;

	// Use this for initialization
	void Start () {
		alertMessage.text = "";
		nutSetText (0);
		hunger.text = "";
		currentTimelimit = fallTimelimit;
		resetTimer ();
	}

	void resetTimer() {
		currentTime = currentTimelimit;
	}
	
	// Update is called once per frame
	void Update () {

		currentTimelimit -= Time.deltaTime;
		setTimerText (currentTimelimit);
		nutSetText ( player.nutCount );

		if (currentTimelimit <= 0.0f)
		{
			if (isWinter && familyTree.isCompletedTree) {
				endGame("You Win! Your Family lived!");
			}
			else if(isWinter && !familyTree.isCompletedTree)
			{
				endGame("You're entire family died...yeah.");
			}
			else {
				nutController.destroyNuts();
				moundController.winterizeMounds();
				resetTimer();
				player.reSpawn();
				switchToWinter();
			}
		}

	}

	void setTimerText(float time) {
		displayTimer.text = time.ToString ();
	}

	void nutSetText(int nuts) {
		nutsCollected.text = nuts.ToString ();
	}

	void endGame(string _message) {
		//GAME OVER code goes here
		//bool an OnGUI function true to display a box with Game Over label, grays the screen out
		//show score
		//disable player movement
		//button to restart
		//button to quit
		alertMessage.text = _message;
	}

	void switchToWinter() {
		isWinter = true;
		familyTree.isWinter = true;
		currentTimelimit = winterTimelimit;
		//Turn on snow
		//terrain.renderer.material = winterMaterial;
		terrain.materialTemplate = winterMaterial;
		//Hide grass
		terrain.detailObjectDistance = 0;
		//Turn off shadows, helps snow look better
		terrain.castShadows = false;
	}
	//this is proper gui usage <michael>
	void OnGUI () {
		if (showStats){
			GUILayout.BeginArea (new Rect(0,0,Screen.width*0.25F, Screen.height*0.5F));
			GUILayout.Box ("Nuts: " + nutsCollected.text + " ");
			if (currentTimelimit >= 0.0f)
			{
				GUILayout.Box ("Time: " + displayTimer.text + " ");
			}
			if (isWinter) {
				GUILayout.Box ("Stockpile: " + (3 - player.nutsCollected) + " more nuts!");
			}
			GUILayout.EndArea ();
		}

	}

}

using UnityEngine;
using System.Collections;

public class CharSelBtn : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		switch (gameObject.name) {


		case "Hermit":
			Debug.Log("hit hermit");
			TreasureGameController.currentChar = Tags.HERMIT;
			Scenes.LoadLevel(Scenes.TREASURE);
			break;


		case "Thief":
			TreasureGameController.currentChar = Tags.THIEF;
			Scenes.LoadLevel(Scenes.TREASURE);
			break;
		default:
			break;
		}
	}
}

using UnityEngine;
using System.Collections;

public class ThroneButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){

		switch (gameObject.name) {
			
		case "Hermit":
			ThroneGameController.currentChar = Tags.HERMIT;
			Scenes.LoadLevel(Scenes.THRONE);
			Debug.Log("click hermit");
			break;
			
		case "Thief":
			ThroneGameController.currentChar = Tags.THIEF;
			Scenes.LoadLevel(Scenes.THRONE);
			break;

		case "King":
			ThroneGameController.currentChar = Tags.KING;
			Scenes.LoadLevel(Scenes.THRONE);
			break;

		case "Servant":
			ThroneGameController.currentChar = Tags.SERVANT;
			Scenes.LoadLevel(Scenes.THRONE);
			Debug.Log("click servant");
			break;

		case "Mouse":
			ThroneGameController.currentChar = Tags.MOUSE;
			Scenes.LoadLevel(Scenes.THRONE);
			break;

		case "Bird":
			ThroneGameController.currentChar = Tags.BIRD;
			Scenes.LoadLevel(Scenes.THRONE);
			break;

		default:
			break;
		}
	}

	void OnMouseEnter(){
		
		switch (gameObject.name) {
			
		case "Hermit":
			break;
			
		case "Thief":
			break;
			
		case "King":
			GameObject.Find("king_1").renderer.enabled = true; 
			break;
			
		case "Servant":
			GameObject.Find("servant_1").renderer.enabled = true; 
			break;
			
		case "Mouse":
			break;
			
		case "Bird":
			break;
			
		default:
			break;
		}
	}

	void OnMouseExit(){
		
		switch (gameObject.name) {
			
		case "Hermit":
			break;
			
		case "Thief":
			break;
			
		case "King":
			GameObject.Find("king_1").renderer.enabled = false; 
			break;
			
		case "Servant":
			GameObject.Find("servant_1").renderer.enabled = false; 
			break;
			
		case "Mouse":
			break;
			
		case "Bird":
			break;
			
		default:
			break;
		}
	}
}

using UnityEngine;
using System.Collections;

public class RingHolder : MonoBehaviour {
	private Instruction instruction;
	// Use this for initialization
	void Start () {
		instruction = GameObject.Find ("objectNameThroneRoom").GetComponent<Instruction>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	
	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("trigger");
		if(other.gameObject.name =="King"){
			King king = other.gameObject.GetComponent<King>();
			king.canPickRing = true;
			
			Debug.Log("can get ring");
		}

		if (ThroneGameController.currentChar == other.name&&transform.FindChild("ringInKingRoom").renderer.enabled==true)
			instruction.findRing();
	}
	
	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.name =="King"){
			King king = other.gameObject.GetComponent<King>();
			king.canPickRing =false;
			
			Debug.Log("cannot get ring");
		}

		if (ThroneGameController.currentChar == other.name)
			instruction.disappear();
	}
}

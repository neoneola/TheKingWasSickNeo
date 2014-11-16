using UnityEngine;
using System.Collections;

public class KeyShelfInKingRoom : MonoBehaviour {

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name =="Bird"){
			Bird bird = other.gameObject.GetComponent<Bird>();
			bird.canKickKey = true;
			
			Debug.Log("bird can kick key");
		}
	}
	
	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.name =="Bird"){
			Bird bird = other.gameObject.GetComponent<Bird>();
			bird.canKickKey = false;
			
			Debug.Log("bird cannot kick key");
		}
	}
}

using UnityEngine;
using System.Collections;

public class AreaForKeyInKingRoom : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name =="Mouse"){
			Mouse mouse = other.gameObject.GetComponent<Mouse>();
			mouse.canPickKey = true;
			
			Debug.Log("mouse can pick key");
		}
	}
	
	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.name =="Mouse"){
			Mouse mouse = other.gameObject.GetComponent<Mouse>();
			mouse.canPickKey =false;
			
			Debug.Log("cannot pick key");
		}
	}
}

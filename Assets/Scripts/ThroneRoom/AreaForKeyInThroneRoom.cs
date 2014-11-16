using UnityEngine;
using System.Collections;

public class AreaForKeyInThroneRoom : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name =="Mouse"){
			Mouse mouse = other.gameObject.GetComponent<Mouse>();
			mouse.canDropKey = true;
			
			Debug.Log("mouse can drop key");
		}
	}
	
	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.name =="Mouse"){
			Mouse mouse = other.gameObject.GetComponent<Mouse>();
			mouse.canDropKey =false;
			
			Debug.Log("cannot drop key");
		}
	}
}

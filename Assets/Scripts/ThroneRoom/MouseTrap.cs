using UnityEngine;
using System.Collections;

public class MouseTrap : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name =="Mouse"){
			Mouse mouse = other.gameObject.GetComponent<Mouse>();
			mouse.canBeTrapped = true;
			
			Debug.Log("mouse can be trapped");
		}
	}
	
	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.name =="Mouse"){
			Mouse mouse = other.gameObject.GetComponent<Mouse>();
			mouse.canBeTrapped =false;
			
			Debug.Log("cannot be trapped");
		}
	}

}

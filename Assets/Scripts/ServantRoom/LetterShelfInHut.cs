using UnityEngine;
using System.Collections;

public class LetterShelfInHut : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
	
		if(other.gameObject.name =="Bird"){
			Bird bird = other.gameObject.GetComponent<Bird>();
			bird.canDropLetter = true;
		
			Debug.Log("Bird can drop letter");
		}
		
	}
	
	void OnTriggerExit2D(Collider2D other){			
		if(other.gameObject.name =="Bird"){
			Bird bird = other.gameObject.GetComponent<Bird>();
			bird.canDropLetter = false;

			Debug.Log("Bird cannot drop letter");
		}
	}
}

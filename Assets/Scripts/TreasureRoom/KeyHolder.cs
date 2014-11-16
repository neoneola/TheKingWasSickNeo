using UnityEngine;
using System.Collections;

public class KeyHolder : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name =="Hermit"){
			Hermit hermit = other.gameObject.GetComponent<Hermit>();
			hermit.canGetKey = true;

			Debug.Log("can get key");
		}
	}
	
	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.name =="Hermit"){
			Hermit hermit = other.gameObject.GetComponent<Hermit>();
			hermit.canGetKey =false;

			Debug.Log("cannot get key");
		}
	}
}

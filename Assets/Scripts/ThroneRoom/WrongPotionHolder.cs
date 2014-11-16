using UnityEngine;
using System.Collections;

public class WrongPotionHolder : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name =="Hermit"){
			Hermit hermit = other.gameObject.GetComponent<Hermit>();
			hermit.canBrewWrongPotion = true;
			
			Debug.Log("can brew wrong potion");
		}
	}
	
	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.name =="Hermit"){
			Hermit hermit = other.gameObject.GetComponent<Hermit>();
			hermit.canBrewWrongPotion =false;
			
			Debug.Log("cannot brew wrong potion");
		}
	}
}

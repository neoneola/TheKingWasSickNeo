using UnityEngine;
using System.Collections;

public class HealingPotionHolder : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name =="Hermit"){
			Hermit hermit = other.gameObject.GetComponent<Hermit>();
			hermit.canBrewHealingPotion= true;
			
			Debug.Log("can brew healing potion");
		}
	}
	
	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.name =="Hermit"){
			Hermit hermit = other.gameObject.GetComponent<Hermit>();
			hermit.canBrewHealingPotion =false;
			
			Debug.Log("cannot brew healing potion");
		}
	}
}

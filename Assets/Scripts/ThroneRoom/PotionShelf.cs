using UnityEngine;
using System.Collections;

public class PotionShelf : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name =="Hermit"){
			Hermit hermit = other.gameObject.GetComponent<Hermit>();
			hermit.canHandInPotion = true;
			
			Debug.Log("Hermit can hand in potion");
		}

		if (other.gameObject.name == "King") {
			King king=other.gameObject.GetComponent<King>();
			king.canTakePotion=true;

			Debug.Log("King can take potion");
			}
	}
	
	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.name =="Hermit"){
			Hermit hermit = other.gameObject.GetComponent<Hermit>();
			hermit.canHandInPotion =false;
			
			Debug.Log("cannot hand in potion");
		}

		if (other.gameObject.name == "King") {
			King king=other.gameObject.GetComponent<King>();
			king.canTakePotion=false;
			
			Debug.Log("King cannot take potion");
		}

	}
}

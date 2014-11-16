using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	/// <summary>
	/// TODO: Hermit thief ect.. not all charactor included.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name == "Hermit"||
		   other.gameObject.name == "Thief"||
		   other.gameObject.name == "Servant"||
		   other.gameObject.name == "King"||
		   other.gameObject.name == "Bird"||
		   other.gameObject.name == "Wolf"||
		   other.gameObject.name == "Mouse"){
			if(other.gameObject.GetComponent<PlayerMovementController>()){
				other.gameObject.GetComponent<PlayerMovementController>().setHitInfo(true);
			}

		}
	}

	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.name == "Hermit"||
		   other.gameObject.name == "Thief"||
		   other.gameObject.name == "Servant"||
		   other.gameObject.name == "King"||
		   other.gameObject.name == "Bird"||
		   other.gameObject.name == "Wolf"||
		   other.gameObject.name == "Mouse"){
			if(other.gameObject.GetComponent<PlayerMovementController>()){
				other.gameObject.GetComponent<PlayerMovementController>().setHitInfo(false);
			}
			
		}
	}
}

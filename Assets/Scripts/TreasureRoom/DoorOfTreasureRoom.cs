using UnityEngine;
using System.Collections;

public class DoorOfTreasureRoom : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name == "Servant"||
		   other.gameObject.name == "King"||
		   other.gameObject.name == "Bird"||
		   other.gameObject.name == "Wolf"||
		   other.gameObject.name == "Mouse")
			{
				if(other.gameObject.GetComponent<PlayerMovementController>()){
					other.gameObject.GetComponent<PlayerMovementController>().setHitInfo(true);
				}
			
			}
		else if(other.gameObject.name=="Hermit")
		{
			Hermit hermit=other.gameObject.GetComponent<Hermit>();
			if(!hermit.getThroneRoomScene().getAction().didHermitPickUpTheKey_D)
			if(other.gameObject.GetComponent<PlayerMovementController>()){
				other.gameObject.GetComponent<PlayerMovementController>().setHitInfo(true);
			}
			else
				Debug.Log("Treasure Room Door Open");
		}
		else if(other.gameObject.name=="Thief")
			Debug.Log("Theif pass the door");

	}
	
	void OnTriggerExit2D(Collider2D other){
		if( other.gameObject.name == "Servant"||
		   other.gameObject.name == "King"||
		   other.gameObject.name == "Bird"||
		   other.gameObject.name == "Wolf"||
		   other.gameObject.name == "Mouse"){
			if(other.gameObject.GetComponent<PlayerMovementController>()){
				other.gameObject.GetComponent<PlayerMovementController>().setHitInfo(false);
			}
			
		}
		else if(other.gameObject.name=="Hermit")
		{
			Hermit hermit=other.gameObject.GetComponent<Hermit>();
			if(!hermit.getThroneRoomScene().getAction().didHermitPickUpTheKey_D)
			if(other.gameObject.GetComponent<PlayerMovementController>()){
				other.gameObject.GetComponent<PlayerMovementController>().setHitInfo(false);
			}
			else
				Debug.Log("Treasure Room Door Open");
		}
	}


}

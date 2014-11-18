using UnityEngine;
using System.Collections;

public class FirePlace : MonoBehaviour {

	private Instruction instruction;
	// Use this for initialization
	void Start () {
		instruction = GameObject.Find ("objectNameThroneRoom").GetComponent<Instruction>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name =="Servant"){
			Servant servant = other.gameObject.GetComponent<Servant>();
			servant.canDropLog = true;
			
			Debug.Log("can drop log");

			if(ThroneGameController.currentChar == "Servant"){
				instruction.putdownLog();
			}
		}

		if (other.gameObject.name == "King") 
		{
			King king=other.gameObject.GetComponent<King>();
			king.canWarmHand=true;
			Debug.Log("can warm hand");

			if (ThroneGameController.currentChar == "King"){
				if(!king.getThroneRoomScene().getAction().didKingWarmHisHand_D){
					instruction.findFirePlace();
				}
			}
		}
	}
	
	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.name =="Servant"){
			Servant servant = other.gameObject.GetComponent<Servant>();
			servant.canDropLog =false;
			
			Debug.Log("cannot drop log");
		}

		if (other.gameObject.name == "King") 
		{
			King king=other.gameObject.GetComponent<King>();
			king.canWarmHand=false;
			Debug.Log("cannot warm hand");
		}
		if (ThroneGameController.currentChar == other.name)
			instruction.disappear ();
	}
}

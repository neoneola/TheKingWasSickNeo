using UnityEngine;
using System.Collections;

public class MedicineHolder : MonoBehaviour {
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
			servant.canTakeMedicine = true;
			
			Debug.Log("can take medicine");
		}

		if(other.gameObject.name =="King"){
			King king = other.gameObject.GetComponent<King>();
			king.canTakeMedicine = true;
			
			Debug.Log("can take medicine");
		}
		if (ThroneGameController.currentChar == other.name)
			instruction.findPill ();
	}
	
	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.name =="Servant"){
			Servant servant = other.gameObject.GetComponent<Servant>();
			servant.canTakeMedicine =false;
			
			Debug.Log("cannot drop log");
		}


		if(other.gameObject.name =="King"){
			King king = other.gameObject.GetComponent<King>();
			king.canTakeMedicine = false;
			
			Debug.Log("cannot take medicine");
		}

		if (ThroneGameController.currentChar == other.name)
			instruction.disappear ();
	}
}

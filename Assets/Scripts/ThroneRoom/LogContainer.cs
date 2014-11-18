using UnityEngine;
using System.Collections;

public class LogContainer : MonoBehaviour {

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
			servant.canPickLog = true;
			
			Debug.Log("can get log");
			if(ThroneGameController.currentChar == "Servant"){
				if(transform.FindChild("log").renderer.enabled==true){
					instruction.findLogs ();
				}
			}
		}
	}
	
	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.name =="Servant"){
			Servant servant = other.gameObject.GetComponent<Servant>();
			servant.canPickLog =false;
			
			Debug.Log("cannot pick log");
		}

		if (ThroneGameController.currentChar == other.name)
			instruction.disappear();
	}
}

using UnityEngine;
using System.Collections;

public class PaperShelf : MonoBehaviour {
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
			servant.canPickPaper = true;
			servant.canDropLetter=true;
			
			Debug.Log("servant can pick paper or drop letter");
		}

		if(other.gameObject.name =="Bird"){
			Bird bird = other.gameObject.GetComponent<Bird>();
			bird.canPickLetter = true;

			
			Debug.Log("Bird can pick letter");
		}
		if (ThroneGameController.currentChar == other.name)
			if(transform.FindChild("paperInServantRoom").renderer.enabled==true)
		{
			instruction.findUnsignedLetter();
		}
		else if(transform.FindChild("letterInServantRoom").renderer.enabled==true)
		{
			instruction.findSignedLetter();
		}
	}
	
	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.name =="Servant"){
			Servant servant = other.gameObject.GetComponent<Servant>();
			servant.canPickPaper =false;
			servant.canDropLetter=false;
			
			Debug.Log("cannot pick letter or letter");
		}

		if(other.gameObject.name =="Bird"){
			Bird bird = other.gameObject.GetComponent<Bird>();
			bird.canPickLetter = false;
			
			
			Debug.Log("Bird cannot pick letter");
		}

		if (ThroneGameController.currentChar == other.name)
			instruction.disappear();
	}
}

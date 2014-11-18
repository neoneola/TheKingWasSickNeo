using UnityEngine;
using System.Collections;

public class LetterHolderThrone : MonoBehaviour {
	private Instruction instruction;
	// Use this for initialization
	void Start () {
		instruction = GameObject.Find ("objectNameThroneRoom").GetComponent<Instruction>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name =="King"){
			King king = other.gameObject.GetComponent<King>();
			king.canSignTheLetterWithRing = true;
			
			Debug.Log("king can sign paper with ring");

			if(ThroneGameController.currentChar == "King"){
				if(king.getThroneRoomScene().getAction().didKingPickTheRing_D && ! king.getThroneRoomScene().getAction().didKingSignTheLetter_D){
					instruction.signTheLetter();
				}
			}
		}

		if (other.gameObject.name == "Servant") 
		{
			Servant servant=other.gameObject.GetComponent<Servant>();		
			servant.canDropPaper=true;
			servant.canPickLetter=true;
			if(ThroneGameController.currentChar == "Servant"){
				if(!servant.getThroneRoomScene().getAction().didServantDropThePaper_D && servant.getServantRoomScene().getAction().didServantPickThePaper_D ){
					instruction.servantdropTheLetter();
				}
			}
			Debug.Log("Servant can drop the paper or letter");
		}
	}
	
	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.name =="King"){
			King king = other.gameObject.GetComponent<King>();
			king.canSignTheLetterWithRing =false;
			
			Debug.Log("cannot sign paper");
		}

		if (other.gameObject.name == "Servant") 
		{
			Servant servant=other.gameObject.GetComponent<Servant>();		
			servant.canDropPaper=false;
			servant.canPickLetter=false;
			
			Debug.Log("Servant cannot drop the paper or letter");
		}

		if (ThroneGameController.currentChar == other.name)
			instruction.disappear();
	}
}

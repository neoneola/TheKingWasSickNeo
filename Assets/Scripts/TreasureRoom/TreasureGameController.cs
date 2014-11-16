using UnityEngine;
using System.Collections;

public class TreasureGameController : MonoBehaviour {

	public static string currentChar = "";

	private Hermit hermit;
	private Thief thief;
	
	private GameObject hermitObj;
	private GameObject thiefObj;


	void Awake(){

		hermitObj = GameObject.FindGameObjectWithTag(Tags.HERMIT);
		hermit = hermitObj.GetComponent<Hermit>();
		
		thiefObj = GameObject.FindGameObjectWithTag(Tags.THIEF);
		thief = thiefObj.GetComponent<Thief>();
	}
	// Use this for initialization
	void Start () {
	 
		
		switch(TreasureGameController.currentChar){
			
		case "Hermit":
			hermitObj.AddComponent<PlayerMovementController>();
			setupForHermit();
			//the other characters should get computer control scripts
			break;
			
		
			
		case "Thief":
			thiefObj.AddComponent<PlayerMovementController>();
			setupForThief();
			break;
		}

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void setupForThief(){
		GameCharConst.THIEF_HAS_BEEN_PLAYED = true;//??
		if(GameCharConst.HERMIT_PICKS_UP_THE_KEY_D)
			if(GameObject.Find("Key"))
				Destroy(GameObject.Find ("Key"));

	}
	
	private void setupForHermit(){
		GameCharConst.HERMIT_HAS_BEEN_PLAYED = true;

		if(GameCharConst.THIEF_GET_THE_PEARL)
			if(GameObject.Find("pearlInTreasure"))
				Destroy(GameObject.Find ("pearlInTreasure"));

	}


}

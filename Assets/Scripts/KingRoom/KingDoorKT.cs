using UnityEngine;
using System.Collections;

public class KingDoorKT : MonoBehaviour {

	public Transform theOtherHole;
	public bool isLeft;
	public float offset=2.0f;
	
	public bool kingReadyToGoKT=false;
	public bool mouseReadyToGoKT=false;

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
			
			King king=other.gameObject.GetComponent<King>();
			king.canPassKingDoorKT=true;
			
			Debug.Log("can go to king room");
		}

		if (ThroneGameController.currentChar == other.name)
			instruction.findDoorToThroneRoom();
	}
	
	
	void OnTriggerStay2D(Collider2D other){
		
		if(other.gameObject.name=="King"&&kingReadyToGoKT)
		{
			float targetPositionX=theOtherHole.position.x;
			float targetPositionY=theOtherHole.position.y;
			
			
			if(isLeft)
				other.transform.position=new Vector2(targetPositionX+offset,other.transform.position.y);
			else
				other.transform.position=new Vector2(targetPositionX-offset,other.transform.position.y);
			Debug.Log("king transport");
		}


		
	}
	
	
	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.name =="King"){
			King king=other.gameObject.GetComponent<King>();
			king.canPassKingDoorKT=false;
			kingReadyToGoKT=false;
			//servantReadyToGoTS=false;
			
			Debug.Log("cannot transport");
		}

	

		if (ThroneGameController.currentChar == other.name)
			instruction.disappear();
	}
}

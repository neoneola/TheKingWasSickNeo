using UnityEngine;
using System.Collections;

public class ServantDoorTS : MonoBehaviour {

	public Transform theOtherHole;
	public bool isLeft;
	public float offset=2.0f;
	
	public bool servantReadyToGoTS=false;
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
			
			Servant servant=other.gameObject.GetComponent<Servant>();
			servant.canPassServantDoorTS=true;
			
			Debug.Log("can go to servant room");
		}

		if (ThroneGameController.currentChar == "Servant")
			instruction.findDoorToServantRoom();
	}
	
	
	void OnTriggerStay2D(Collider2D other){
		if(other.gameObject.name =="Servant"){
			if(servantReadyToGoTS)
			{
				float targetPositionX=theOtherHole.position.x;
				float targetPositionY=theOtherHole.position.y;
				
				
				if(isLeft)
					other.transform.position=new Vector2(targetPositionX+offset,other.transform.position.y);
				else
					other.transform.position=new Vector2(targetPositionX-offset,other.transform.position.y);
				Debug.Log("servant transport");
			}
		}
	}
	
	
	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.name =="Servant"){
			Servant servant = other.gameObject.GetComponent<Servant>();
			servant.canPassServantDoorTS=false;
			servantReadyToGoTS=false;
			
			Debug.Log("cannot transport");

			if (ThroneGameController.currentChar == other.name)
				instruction.disappear();
		}
	}
}

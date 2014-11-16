using UnityEngine;
using System.Collections;

public class ServantDoorST : MonoBehaviour {

	public Transform theOtherHole;
	public bool isLeft;
	public float offset=10.0f;
	private Instruction instruction;

	public bool servantReadyToGoST=false;
	
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
			servant.canPassServantDoorST=true;
			
			Debug.Log("can go to servant room");
		}

		if (ThroneGameController.currentChar == other.name)
			instruction.findDoorToThroneRoom ();
	}
	
	
	void OnTriggerStay2D(Collider2D other){
		
		if(servantReadyToGoST)
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

	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.name =="Servant"){
			Servant servant = other.gameObject.GetComponent<Servant>();
			servant.canPassServantDoorST=false;
			servantReadyToGoST=false;
			
			Debug.Log("cannot transport");
		}

		if (ThroneGameController.currentChar == other.name)
			instruction.disappear();
	}

}

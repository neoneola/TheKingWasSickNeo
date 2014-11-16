using UnityEngine;
using System.Collections;

public class KingWindowKW : MonoBehaviour {
	public Transform theOtherHole;
	public bool isLeft;
	public float offset=2.0f;
	
	public bool birdReadyToGoKW=false;

	public bool isOpen=false;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name =="Bird"&&GameCharConst.KING_OPEN_THE_WINDOW_IN_HIS_ROOM){
			
			Bird bird=other.gameObject.GetComponent<Bird>();
			bird.canPassTheWindowKW=true;
			
			Debug.Log("can go to the wood");
		}


		if (other.gameObject.name == "King") 
		{
			King king=other.gameObject.GetComponent<King>();
			king.canOpenWindow=true;
			Debug.Log("can open window");
		}
	}
	
	
	void OnTriggerStay2D(Collider2D other){
		
		if(birdReadyToGoKW&&other.gameObject.name=="Bird")
		{
			float targetPositionX=theOtherHole.position.x;
			float targetPositionY=theOtherHole.position.y;

			if(isLeft)
				other.transform.position=new Vector2(targetPositionX+offset,targetPositionY);
			else
				other.transform.position=new Vector2(targetPositionX-offset,targetPositionY);
			Debug.Log("bird transport");
		}


		
	}
	
	
	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.name =="Bird"){
			Bird bird=other.gameObject.GetComponent<Bird>();
			bird.canPassTheWindowKW=false;
			birdReadyToGoKW=false;
			//servantReadyToGoTS=false;
			
			Debug.Log("cannot transport");
		}

		if (other.gameObject.name == "King") 
		{
			King king=other.gameObject.GetComponent<King>();
			king.canOpenWindow=false;
			Debug.Log("cannot open window");
		}
	}

	public void openTheWindow()
	{
		isOpen=true;
		GameObject.Find ("windowBlockKW").renderer.enabled=false;
	}
}

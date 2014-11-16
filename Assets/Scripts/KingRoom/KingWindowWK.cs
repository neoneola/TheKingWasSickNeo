using UnityEngine;
using System.Collections;

public class KingWindowWK : MonoBehaviour {
	public Transform theOtherHole;
	public bool isLeft;
	public float offset=2.0f;
	
	public bool birdReadyToGoWK=false;

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
			bird.canPassTheWindowWK=true;
			
			Debug.Log("can go to the wood");
		}
	}
	
	
	void OnTriggerStay2D(Collider2D other){
		
		if(birdReadyToGoWK)
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
			bird.canPassTheWindowWK=false;
			birdReadyToGoWK=false;
			//servantReadyToGoTS=false;
			
			Debug.Log("cannot transport");
		}
	}

	public void openTheWindow()
	{
		isOpen=true;
		GameObject.Find ("windowBlockWK").renderer.enabled=false;
	}

}

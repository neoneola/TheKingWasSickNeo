using UnityEngine;
using System.Collections;

public class ServantWindow : MonoBehaviour {

	public Transform theOther;
	public bool isLeft;
	public float offset=1.0f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name =="Bird"){
			float targetPositionX=theOther .position.x;
			float targetPositionY=theOther .position.y;
			if(isLeft)
				other.transform.position=new Vector2(targetPositionX+offset,targetPositionY);
			else
				other.transform.position=new Vector2(targetPositionX-offset,targetPositionY);
			Bird bird=other.GetComponent<Bird>();
			bird.goto_window_outofservantroom=false;
			
			Debug.Log("bird transport to the other hole");
		}
	}
}

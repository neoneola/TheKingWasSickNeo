using UnityEngine;
using System.Collections;

public class MouseHole : MonoBehaviour {
	public Transform theOtherHole;
	public bool isLeft;
	public float offset=1.0f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name =="Mouse"){
			float targetPositionX=theOtherHole .position.x;
			if(isLeft)
				other.transform.position=new Vector2(targetPositionX+offset,other.transform.position.y);
			else
				other.transform.position=new Vector2(targetPositionX-offset,other.transform.position.y);

			Debug.Log("mouse transport to the other hole");
		}
	}
	

}

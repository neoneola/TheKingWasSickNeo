using UnityEngine;
using System.Collections;

public class PearProtector : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void destory(){
		Destroy(gameObject);
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name =="Thief"){
			Thief thief = other.gameObject.GetComponent<Thief>();
			thief.canGetPeal = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.name =="Thief"){
			Thief thief = other.gameObject.GetComponent<Thief>();
			thief.canGetPeal= false;
		}
	}
}

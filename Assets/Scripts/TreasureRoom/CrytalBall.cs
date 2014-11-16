using UnityEngine;
using System.Collections;

public class CrytalBall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.name == "Hermit") 
		{
			Hermit hermit=coll.gameObject.GetComponent<Hermit>();
			hermit.canSeeTheCrystalBall=true;
		}
	}


	void OnTriggerExit2D(Collider2D coll)
	{
		if(coll.gameObject.name == "Hermit") 
		{
			Hermit hermit=coll.gameObject.GetComponent<Hermit>();
			hermit.canSeeTheCrystalBall=false;
		}

	}

}

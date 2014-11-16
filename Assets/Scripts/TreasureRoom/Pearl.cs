using UnityEngine;
using System.Collections;

public class Pearl : MonoBehaviour {


	//private BrewButton brewButton;
	private GameObject brewButtonObj;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown()
	{
		Debug.Log ("Pearl is touched");

	}
	




	public void disappear()
	{
		Debug.Log ("The pearl is picked.");
		//Debug.Log("Key is taken by Hermit");
		Destroy(gameObject,0.0f);
	}
}

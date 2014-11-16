using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void disappear()
	{
		//Debug.Log("Key is taken by Hermit");
		Destroy(gameObject,0.0f);
	}

}

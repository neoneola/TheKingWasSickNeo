using UnityEngine;
using System.Collections;

public class MouseOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter(){
		renderer.enabled = true;
	}

	void OnMouseExit(){
		renderer.enabled = false;
	}
}

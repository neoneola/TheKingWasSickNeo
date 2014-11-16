using UnityEngine;
using System.Collections;

public class LoopTest : MonoBehaviour {

	int i=4;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (i <= 0)
			Debug.Log ("hahahha");
		i--;

	}
}

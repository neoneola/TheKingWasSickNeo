using UnityEngine;
using System.Collections;

public class BirdSelection : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		Debug.Log ("choose bird");
		PlayerPrefs.SetInt("CharacterChosen",1);//1 represents bird
		Application.LoadLevel("AnimationTest");
	}
}

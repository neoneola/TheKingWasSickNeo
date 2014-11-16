using UnityEngine;
using System.Collections;

public class PeopleSelection : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		Debug.Log ("choose bird");
		PlayerPrefs.SetInt("CharacterChosen",2);//2 represents people
		Application.LoadLevel("AnimationTest");
	}
}

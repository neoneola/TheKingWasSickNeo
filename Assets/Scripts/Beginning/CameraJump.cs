using UnityEngine;
using System.Collections;

public class CameraJump : MonoBehaviour {

	public float jumpTime=1.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void jump()
	{
		Invoke ("jumpToNext",jumpTime);
	}

	void jumpToNext()
	{
		Application.LoadLevel("SelectCharacter");	
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RoomName : MonoBehaviour {
	public Text text;
	public bool switchOn=true;

	public GameObject cameraThroneRoom;
	public GameObject cameraKingRoom;
	public GameObject cameraServantRoom;

	// Use this for initialization
	void Start () {
		text=GetComponent<Text>();

		cameraThroneRoom = GameObject.Find ("Main Camera");
		cameraKingRoom = GameObject.Find ("CameraKingRoom");
		cameraServantRoom = GameObject.Find ("CameraServantRoom");
	}
	
	// Update is called once per frame
	void Update () {
		if (Camera.current != null) 
		{
			if(Camera.current.name=="Main Camera")
				text.text="Throne Room";
			if(Camera.current.name=="CameraKingRoom")
				text.text="King Room";
			if(Camera.current.name=="CameraServantRoom")
				text.text="Servant Room";	
		}

	}
}

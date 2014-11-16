using UnityEngine;
using System.Collections;

public class CameraSwitcher : MonoBehaviour {
	public static GameObject cameraThroneRoom;
	public static GameObject cameraKingRoom;
	public static GameObject cameraServantRoom;

	// Use this for initialization
	void Start () {
		cameraThroneRoom = GameObject.Find ("Main Camera");
		cameraKingRoom = GameObject.Find ("CameraKingRoom");
		cameraServantRoom = GameObject.Find ("CameraServantRoom");
		ActivateFalse();
		cameraThroneRoom.SetActive (true);
	}
	


	public static void changeToKingRoom()
	{
		ActivateFalse();
		cameraKingRoom.SetActive(true);
	}

	public static void changeToThroneRoom()
	{
		ActivateFalse();
		cameraThroneRoom.SetActive(true);
	}

	public static void changeToServantRoom()
	{
		ActivateFalse();
		cameraServantRoom.SetActive (true);
	}

	public static void ActivateFalse()
	{
		cameraThroneRoom.SetActive (false);
		cameraKingRoom.SetActive (false);
		cameraServantRoom.SetActive (false);
	}
}

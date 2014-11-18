using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RoonNameIMage : MonoBehaviour {

	private GameObject cameraThroneRoom;
	private GameObject cameraKingRoom;
	private GameObject cameraServantRoom;

	private GameObject KingroomImage;
	private GameObject ThroneroomImage;
	private GameObject ServantroomImage;

	private float totalTime = 5.0f;
	private float stayTime = 0.0f;

	private bool throneStarted = false;
	private bool kingStarted = false;
	private bool servantStarted = false;

	void Awake(){
		cameraThroneRoom = GameObject.Find ("Main Camera");
		cameraKingRoom = GameObject.Find ("CameraKingRoom");
		cameraServantRoom = GameObject.Find ("CameraServantRoom");

		KingroomImage = GameObject.Find("KingroomImage");
		ThroneroomImage = GameObject.Find("ThroneroomImage");
		ServantroomImage = GameObject.Find("ServantroomImage");
	}

	// Use this for initialization
	void Start () {
	}

	void reset(){
		KingroomImage.GetComponent<Image>().enabled = false;
		ThroneroomImage.GetComponent<Image>().enabled = false;
		ServantroomImage.GetComponent<Image>().enabled = false;
	}

	void resetbool(){
		throneStarted = false;
		kingStarted = false;
		servantStarted = false;
	}

	// Update is called once per frame
	void Update () {
		if (Camera.current != null) 
		{
			if(Camera.current.name=="Main Camera"){
				if(!throneStarted){
					reset();
					ThroneroomImage.GetComponent<Image>().enabled = true;
					throneStarted = true;
					Invoke("thronedisappear", 3.0f);
				}
			}

			if(Camera.current.name=="CameraKingRoom"){
				if(!kingStarted){
					reset();
					KingroomImage.GetComponent<Image>().enabled = true;
					kingStarted = true;
					Invoke("kingdisappear", 3.0f);
				}
			}

			if(Camera.current.name=="CameraServantRoom"){
				if(!servantStarted){
					reset();
					ServantroomImage.GetComponent<Image>().enabled = true;
					servantStarted = true;
					Invoke("servantdisappear", 3.0f);
				}
			}
		}
	}

	void thronedisappear(){

		ThroneroomImage.GetComponent<Image>().enabled = false;
		kingStarted = false;
		servantStarted = false;
	}

	void kingdisappear(){
		KingroomImage.GetComponent<Image>().enabled = false;
		throneStarted = false;
		servantStarted = false;
	}

	void servantdisappear(){
		ServantroomImage.GetComponent<Image>().enabled = false;
		kingStarted = false;
		throneStarted = false;
	}
}

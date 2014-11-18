using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Instruction : MonoBehaviour {
	public string stringToEdit = "Hello World";
	public float fadeOutSpeed=3.0f;
	public string objectName;
	public Text text;
	public bool switchOn=true;

	private King king;
	private Servant servant;

	public float fadeOutTime = 2f;
	public float fadeOutTimer = 0f;

	void Awake(){
		king = GameObject.FindGameObjectWithTag(Tags.KING).GetComponent<King>();
		servant = GameObject.FindGameObjectWithTag(Tags.SERVANT).GetComponent<Servant>();
	}

	// Use this for initialization
	void Start () {
		text=GetComponent<Text>();
		//findPill ();
	}
	
	// Update is called once per frame
	void Update () {
		//fadeOut ();
	}

	public void findPill()
	{
		if(switchOn)
		{
			text.color = new Color(1f, 1f, 1f, 1.0f);
			text.text="Take Medicine";
			//Invoke ("disappear",fadeOutSpeed);
		}

	}

	public void findUnsignedLetter()
	{
		if(switchOn)
		{
			text.color = new Color(1f, 1f, 1f, 1.0f);
			text.text="Pick up Letter";
			//Invoke ("disappear",fadeOutSpeed);
		}

	}

	public void findSignedLetter()
	{
		if(switchOn)
		{
			text.color = new Color(1f, 1f, 1f, 1.0f);
			text.text="Signed Letter";
			//Invoke ("disappear",fadeOutSpeed);
		}

	}

	public void findLogs()
	{
		if(switchOn)
		{
			text.color = new Color(1f, 1f, 1f, 1.0f);
			text.text="Pick up Logs";
			//Invoke ("disappear",fadeOutSpeed);
		}

	}

	public void servantdropTheLetter(){
		if(switchOn){
			text.color = new Color(1f, 1f, 1f, 1.0f);
			text.text="Drop the letter";
		}
	}

	public void putdownLog(){
		if(switchOn)
		{
			if(servant.getThroneRoomScene().getAction().didServantPickTheLog_D && !servant.getThroneRoomScene().getAction().didServantDropTheLog_D){
				text.color = new Color(1f, 1f, 1f, 1.0f);
				text.text="Add logs to fire";
			//Invoke ("disappear",fadeOutSpeed);
			}
		}
	}

	public void findFirePlace()
	{
		if(switchOn)
		{
			if(!servant.getThroneRoomScene().getAction().didServantDropTheLog_D){
				text.color = new Color(1f, 1f, 1f, 1.0f);
				text.text="Attempt to warm Hands";
			}else{
				text.color = new Color(1f, 1f, 1f, 1.0f);
				text.text="Warm Hands";
			}

			//Invoke ("disappear",fadeOutSpeed);
		}

	}

	public void signTheLetter(){
		if(switchOn){
			text.color = new Color(1f, 1f, 1f, 1.0f);
			text.text="Sign Letter";
		}
	}

	public void findDoorToServantRoom()
	{
		if(switchOn)
		{
			text.color = new Color(1f, 1f, 1f, 1.0f);
			text.text="Enter Servant’s Room";
			//Invoke ("disappear",fadeOutSpeed);
		}

	}

	public void findDoorToKingRoom()
	{
		if(switchOn)
		{
			if(!king.getThroneRoomScene().getAction().didKingWarmHisHand_D){
				text.color = new Color(1f, 1f, 1f, 1.0f);
				text.text="Attempt to enter King’s Room";
			}else{
				text.color = new Color(1f, 1f, 1f, 1.0f);
				text.text="Enter King’s Room";
			}

		}

	}

	public void findDoorToThroneRoom()
	{
		if(switchOn)
		{
			text.color = new Color(1f, 1f, 1f, 1.0f);
			text.text="Enter Throne Room";
			//Invoke ("disappear",fadeOutSpeed);
		}

	}

	public void findRing()
	{
		if(switchOn)
		{
			text.color = new Color(1f, 1f, 1f, 1.0f);
			text.text="Wear Signet ring";
			//Invoke ("disappear",fadeOutSpeed);
		}

	}
	

	public void disappear()
	{
		if(switchOn)
		{
			text.color = new Color(1f, 1f, 1f, 0.0f);
		}

	}

	public void fadeOut()
	{
	
		 text.color = new Color(1f, 1f, 1f, 0.5f);
	}

}

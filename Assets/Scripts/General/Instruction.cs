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

	public GameObject interbg;

	void Awake(){
		king = GameObject.FindGameObjectWithTag(Tags.KING).GetComponent<King>();
		servant = GameObject.FindGameObjectWithTag(Tags.SERVANT).GetComponent<Servant>();
		interbg = GameObject.Find("InteractionBG");
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
			showText();
			text.text="Take Medicine";
			showbg();
			//Invoke ("disappear",fadeOutSpeed);
		}

	}

	public void findUnsignedLetter()
	{
		if(switchOn)
		{
			showText();
			text.text="Pick up Letter";
			showbg();
			//Invoke ("disappear",fadeOutSpeed);
		}

	}

	public void findSignedLetter()
	{
		if(switchOn)
		{
			showText();
			text.text="Signed Letter";
			showbg();
			//Invoke ("disappear",fadeOutSpeed);
		}

	}

	public void findLogs()
	{
		if(switchOn)
		{
			showText();
			text.text="Pick up Logs";
			showbg();
			//Invoke ("disappear",fadeOutSpeed);
		}

	}

	public void servantdropTheLetter(){
		if(switchOn){
			showText();
			text.text="Drop the letter";
			showbg();
		}
	}

	public void putdownLog(){
		if(switchOn)
		{
			if(servant.getThroneRoomScene().getAction().didServantPickTheLog_D && !servant.getThroneRoomScene().getAction().didServantDropTheLog_D){
				showText();
				text.text="Add logs to fire";
				showbg();
			//Invoke ("disappear",fadeOutSpeed);
			}
		}
	}

	public void findFirePlace()
	{
		if(switchOn)
		{
			if(!servant.getThroneRoomScene().getAction().didServantDropTheLog_D){
				showText();
				text.text="Attempt to warm Hands";
				showbg();
			}else{
				showText();
				text.text="Warm Hands";
				showbg();
			}

			//Invoke ("disappear",fadeOutSpeed);
		}

	}

	public void signTheLetter(){
		if(switchOn){
			showText();
			text.text="Sign Letter";
			showbg();
		}
	}

	public void findDoorToServantRoom()
	{
		if(switchOn)
		{
			showText();
			text.text="Enter Servant’s Room";
			showbg();
			//Invoke ("disappear",fadeOutSpeed);
		}

	}

	public void findDoorToKingRoom()
	{
		if(switchOn)
		{
			if(!king.getThroneRoomScene().getAction().didKingWarmHisHand_D){
				showText();
				text.text="The door is cold";
				showbg();
			}else{
				showText();
				text.text="Enter King’s Room";
				showbg();
			}

		}

	}

	public void findDoorToThroneRoom()
	{
		if(switchOn)
		{
			showText();
			text.text="Enter Throne Room";
			showbg();
			//Invoke ("disappear",fadeOutSpeed);
		}

	}

	public void findRing()
	{
		if(switchOn)
		{
			showText();
			text.text="Wear Signet ring";
			showbg();
			//Invoke ("disappear",fadeOutSpeed);
		}

	}
	
	private void showText(){
		text.color = new Color(text.color.r, text.color.g, text.color.b, 1.0f);
	}

	public void disappear()
	{
		if(switchOn)
		{
			text.color = new Color(text.color.r, text.color.g, text.color.b, 0.0f);
			interbg.GetComponent<Image>().enabled = false;
		}

	}

	private void showbg(){
		interbg.GetComponent<Image>().enabled = true;
	}

	public void fadeOut()
	{
	
		 text.color = new Color(1f, 1f, 1f, 0.5f);
	}

}

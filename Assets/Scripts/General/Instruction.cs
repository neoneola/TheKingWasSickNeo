using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Instruction : MonoBehaviour {
	public string stringToEdit = "Hello World";
	public float fadeOutSpeed=3.0f;
	public string objectName;
	public Text text;
	public bool switchOn=true;


	public float fadeOutTime = 2f;
	public float fadeOutTimer = 0f;

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
			text.text="Pill";
			//Invoke ("disappear",fadeOutSpeed);
		}

	}

	public void findUnsignedLetter()
	{
		if(switchOn)
		{
			text.color = new Color(1f, 1f, 1f, 1.0f);
			text.text="Unsigned Letter";
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
			text.text="Logs";
			//Invoke ("disappear",fadeOutSpeed);
		}

	}

	public void findFirePlace()
	{
		if(switchOn)
		{
			text.color = new Color(1f, 1f, 1f, 1.0f);
			text.text="Fire Place";
			//Invoke ("disappear",fadeOutSpeed);
		}

	}

	public void findDoorToServantRoom()
	{
		if(switchOn)
		{
			text.color = new Color(1f, 1f, 1f, 1.0f);
			text.text="Door To Servant Room";
			//Invoke ("disappear",fadeOutSpeed);
		}

	}

	public void findDoorToKingRoom()
	{
		if(switchOn)
		{
			text.color = new Color(1f, 1f, 1f, 1.0f);
			text.text="Door To King Room";
			//Invoke ("disappear",fadeOutSpeed);
		}

	}

	public void findDoorToThroneRoom()
	{
		if(switchOn)
		{
			text.color = new Color(1f, 1f, 1f, 1.0f);
			text.text="Door To Throne Room";
			//Invoke ("disappear",fadeOutSpeed);
		}

	}

	public void findRing()
	{
		if(switchOn)
		{
			text.color = new Color(1f, 1f, 1f, 1.0f);
			text.text="Ring To Sign Letter";
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

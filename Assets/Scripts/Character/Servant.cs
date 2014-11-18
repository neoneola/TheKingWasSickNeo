using UnityEngine;
using System.Collections;

public class Servant : MonoBehaviour {
	public bool isDead = false;
	
	public bool canPickLog=false;
	public bool canDropLog=false;

	public bool canPickPaper = false;
	public bool canDropPaper = false;

	public bool canPickLetter=false;
	public bool canDropLetter=false;

	public bool canTakeMedicine=false;



	private GameObject kingObj;
	private King king;
	//memory 
	private bool isMemory = false;
	//***********memory servantroom
	private GameObject paperShelf;
	private GameObject doorToThroneFromServantRoom;
	private GameObject doorToServantRoomFromThroneRoom;

	private bool goto_servantroom_putletter = false;
	private bool goto_outofservantroom = false;
	//************memory throneroom
	private GameObject logContainer;
	private GameObject firePlace;
	private GameObject letterShelf;
	private GameObject servantStandplace;
	private GameObject medicineShelf;

	private bool goto_throneroom_logplace=false;
	private bool goto_throneroom_fireplace=false;

	private bool goto_thronedoortoservant_getpaper=false;
	private bool goto_servantroom_getpaper=false;

	private bool goto_servantdoortothrone_putpaper=false;
	private bool goto_throneroom_droppaper=false;

	private bool goto_throneroom_waitforletter=false;

	private bool goto_throneroom_getletter=false;
	private bool goto_thronedoortoservant_putletter=false;

	private bool goto_servantdoortothrone_afterputletter=false;
	private bool goto_throneroom_servantstandplace=false;

	private bool goto_medicineShelf_killhimeself=false;






	//servant room 
	public bool canPassServantDoorTS=false;
	public bool canPassServantDoorST=false;


	//medicine
	public int maxPillNum=3;
	private int curPillNum=0;
	private float firstPillTime;
	public float timeLimit=3.0f;

	private bool theMomentWhenKeyPress=true;

	private bool isHandsFull=false;

	private ThroneRoomScene throneRoomScene;
	private ServantRoomScene servantRoomScene;

	public ThroneRoomScene getThroneRoomScene()
	{
		if (throneRoomScene == null) 
		{
			throneRoomScene=new ThroneRoomScene();
		}
		return throneRoomScene;
	}

	public ServantRoomScene getServantRoomScene()
	{
		if (servantRoomScene == null) 
		{
			servantRoomScene=new ServantRoomScene();
		}
		return servantRoomScene;
	}

	void Awake()
	{
		paperShelf = GameObject.Find ("paperShelf");
		doorToThroneFromServantRoom = GameObject.Find ("doorToThroneFromServantRoom");
		doorToServantRoomFromThroneRoom = GameObject.Find ("doorToServantRoomFromThrone");

		logContainer=GameObject.Find("logContainer");
		firePlace=GameObject.Find("firePlace");
		letterShelf=GameObject.Find("letterShelf");
		servantStandplace = GameObject.Find ("servantStandPlace");
		medicineShelf=GameObject.Find ("medicineShelf");

		kingObj=GameObject.Find("King");
		king=kingObj.GetComponent<King>();



	}

	// Use this for initialization
	void Start () {
		if(ThroneGameController.currentChar != Tags.SERVANT){
			isMemory = true;
		}else{
			// must reset all static const parameters here.
			GameCharConst.resetServant();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!isMemory) 
		{
			if(ThroneGameController.currentChar=="Servant")
				if(Input.GetKey(KeyCode.Space)){
				//get the pear;
					if(canPickLog&&getThroneRoomScene().getAction().didServantPickTheLog_D==false&&isHandsFull==false)
					{
						pickLog();
					}
				
					if(canDropLog)
					{
						if(getThroneRoomScene().getAction().didServantPickTheLog_D&&getThroneRoomScene().getAction().didServantDropTheLog_D==false)
						{
							dropLog();
						}
					}
				
					if(canPickPaper&&getServantRoomScene().getAction().didServantPickThePaper_D==false&&isHandsFull==false)
					{
						pickPaper();
					}
				
					if(canDropPaper&&getThroneRoomScene().getAction().didServantDropThePaper_D==false&&getServantRoomScene().getAction().didServantPickThePaper_D)
					{
						dropPaper();
					}
				
				
					if(canPickLetter&&getThroneRoomScene().getAction().didServantPickUpTheLetter_D==false&&isHandsFull==false&&king.getThroneRoomScene().getAction().didKingSignTheLetter_D)
					{
						pickLetter();
					}
				
					if(canDropLetter&&getServantRoomScene().getAction().didServantDropTheLetterOnHisDesk_D==false&&getThroneRoomScene().getAction().didServantPickUpTheLetter_D)
					{
						dropLetter();
					}

					if(canTakeMedicine)
					{
						if(theMomentWhenKeyPress)
						{
							takeMedicine();
						}
					}
				
				
				//pass the door and transport to servant room
					if(canPassServantDoorTS)
					{
						CameraSwitcher.changeToServantRoom();
						passServantDoorTS();
					//if(theMomentWhenKeyPress)
					}
				
					if(canPassServantDoorST)
					{
						CameraSwitcher.changeToThroneRoom();
						passServantDoorST();
						//if(theMomentWhenKeyPress)
					}
				
				}
			
			if(Input.GetKeyUp(KeyCode.Space))
			{
				theMomentWhenKeyPress=true;
				
			}	
		}
		else
		{
			//******memory part memory servantroom***********
			if(goto_servantroom_putletter){
				if(gotoPostion(paperShelf.transform.position)){
					goto_servantroom_putletter = false;
					dropLetter();
					goto_outofservantroom = true;
					getServantRoomScene().getAction().didServantDropTheLetterOnHisDesk_D=true;

				}
			}
			
			if(goto_outofservantroom){
				if(gotoPostion(doorToThroneFromServantRoom.transform.position)){
					goto_outofservantroom = false;
					passServantDoorST();
				}
			}
			//******memory part memory servantroom***********




			//**************memory part throneroom***********************
			if(goto_throneroom_logplace)
			{
				if(GameCharConst.SERVANT_DROP_THE_LOG)
				{
					if(gotoPostion(logContainer.transform.position))
					{
						goto_throneroom_logplace=false;
						pickLog();
						getThroneRoomScene().getAction().didServantPickTheLog_D=true;
						goto_throneroom_fireplace=true;
					}
				}
				else
				{
					goto_throneroom_logplace=false;
					goto_throneroom_fireplace=true;
				}
			}

			if(goto_throneroom_fireplace)
			{
				if(GameCharConst.SERVANT_DROP_THE_LOG)
				{
					if(gotoPostion(firePlace.transform.position))
					{
						goto_throneroom_fireplace=false;
						dropLog();
						getThroneRoomScene().getAction().didServantDropTheLog_D=true;
						goto_thronedoortoservant_getpaper=true;
					}
				}
				else
				{
					goto_throneroom_fireplace=false;
					goto_thronedoortoservant_getpaper=true;
				}
			}

			if(goto_thronedoortoservant_getpaper)
			{
				if(GameCharConst.SERVANT_PICK_THE_PAPER)
				{
					if(gotoPostion(doorToServantRoomFromThroneRoom.transform.position))
					{
						goto_thronedoortoservant_getpaper=false;
						passServantDoorTS();
						goto_servantroom_getpaper=true;
					}
				}
				else
				{
					goto_thronedoortoservant_getpaper=false;
					goto_servantroom_getpaper=true;
				}
			}
			/////////////////
			if(goto_servantroom_getpaper)
			{
				if(GameCharConst.SERVANT_PICK_THE_PAPER)
				{
					if(gotoPostion(paperShelf.transform.position))
					{
						goto_servantroom_getpaper=false;
						pickPaper();
						getThroneRoomScene().getAction().didServantPickUpTheLetter_D=true;
						goto_servantdoortothrone_putpaper=true;
					}

				}
				else
				{
					goto_servantroom_getpaper=false;
					goto_servantdoortothrone_putpaper=true;
				}
			}
			// above is good

			if(goto_servantdoortothrone_putpaper)
			{
				if(GameCharConst.SERVANT_PICK_THE_PAPER)
				{
					if(gotoPostion(doorToThroneFromServantRoom.transform.position))
					{
						goto_servantdoortothrone_putpaper=false;
						passServantDoorST();
						goto_throneroom_droppaper=true;
					}
				}
				else
				{
					goto_servantdoortothrone_putpaper=false;
					goto_throneroom_droppaper=true;
				}
			}
			// above is good

			if(goto_throneroom_droppaper)
			{
				if(GameCharConst.SERVANT_DROP_THE_PAPER)
				{
					if(gotoPostion(letterShelf.transform.position))
					{
						goto_throneroom_droppaper=false;
						dropPaper();
						getThroneRoomScene().getAction().didServantDropThePaper_D=true;
						goto_throneroom_waitforletter=true;
					}
				}
				else
				{
					goto_throneroom_droppaper=false;
					goto_throneroom_waitforletter=true;
				}
			}


			if(goto_throneroom_waitforletter)
			{
				if(gotoPostion(servantStandplace.transform.position))
				{
					goto_throneroom_waitforletter=false;
					goto_throneroom_getletter=true;
				}
			}

			if(goto_throneroom_getletter)
			{
				Debug.Log("succeed1");
				if(GameCharConst.SERVANT_PICK_THE_LETTER)
				{
					if(king.getThroneRoomScene().getAction().didKingSignTheLetter_D)
					{
						if(gotoPostion(letterShelf.transform.position))
						{
							goto_throneroom_getletter=false;
							pickLetter();
							getThroneRoomScene().getAction().didServantPickUpTheLetter_D=true;
							goto_thronedoortoservant_putletter=true;
						}
					}
				}
				else
				{
					goto_throneroom_getletter=false;
					goto_thronedoortoservant_putletter=true;
				}
			}

			if(goto_thronedoortoservant_putletter)
			{

				Debug.Log("succeed2");
				if(GameCharConst.SERVANT_DROP_THE_LETTER_ON_HIS_DESK)
				{
					if(gotoPostion(doorToServantRoomFromThroneRoom.transform.position))
					{
						goto_thronedoortoservant_putletter=false;
						passServantDoorTS();
						goto_servantroom_putletter=true;
					}

				}
				else
				{
					goto_thronedoortoservant_putletter=false;
					goto_servantroom_putletter=true;
				}
			}

			if(goto_servantroom_putletter)
			{
				Debug.Log("succeed3");
				if(GameCharConst.SERVANT_DROP_THE_LETTER_ON_HIS_DESK)
				{
					if(gotoPostion(paperShelf.transform.position))
					{
						goto_servantroom_putletter=false;
						dropLetter();
						getServantRoomScene().getAction().didServantDropTheLetterOnHisDesk_D=true;
						goto_servantdoortothrone_afterputletter=true;
					}
				}
				else
				{
					goto_servantroom_putletter=false;
					goto_servantdoortothrone_afterputletter=true;
				}
			}

			if(goto_servantdoortothrone_afterputletter)
			{
				Debug.Log("succeed4");
				if(GameCharConst.SERVANT_DROP_THE_LETTER_ON_HIS_DESK)
				{
					if(gotoPostion(doorToThroneFromServantRoom.transform.position))
					{
						goto_servantdoortothrone_afterputletter=false;
						passServantDoorST();
						goto_throneroom_servantstandplace=true;
					}
				}
				else
				{
					goto_servantdoortothrone_afterputletter=false;
					goto_throneroom_servantstandplace=true;
				}
			}

			if(goto_throneroom_servantstandplace)
			{
				Debug.Log("succeed5");
				if(gotoPostion(servantStandplace.transform.position))
				{
					goto_throneroom_servantstandplace=false;
					goto_medicineShelf_killhimeself=true;
				}
			}
			if(goto_medicineShelf_killhimeself)
			{
				Debug.Log("succeed6");
				if(GameCharConst.SERVANT_TAKE_TOO_MUCH_MEDICINE)
				{
					
					if(gotoPostion(medicineShelf.transform.position))
						//Debug.Log("mouse ");
					{
						goto_medicineShelf_killhimeself=false;
						for(int i=0;i<=5;i++)
							takeMedicine();
						getThroneRoomScene().getAction().didServantTakeTooMuchMedicine_D=true;
						
					}
			
				}
				else
				{
					goto_medicineShelf_killhimeself=false;
				}
			}

			//**************memory part throneroom***********************
		}

	}


	//**************memory part servantroom********************
	public void startMemoryServantRoom(){
		if (GameCharConst.SERVANT_PICK_THE_LETTER) 
		{
			goto_servantroom_putletter=true;
		}
	}
	//**************memory part servantroom********************



	//**************memory part throneroom***********************
	public void startMemoryThroneRoom()
	{
		goto_throneroom_logplace = true;
	}
	//**************memory part throneroom***********************



	//**************memory part preperation********************

	/*public bool gotoPostion(Vector2 targetPosition){
		transform.position = Vector2.Lerp(transform.position, targetPosition, Time.deltaTime);
		return checkTargetPosition(targetPosition);
	}
	
	public bool checkTargetPosition(Vector2 targetPosition){
		if(Vector2.Distance(transform.position, targetPosition) < 1.5f ){
			return true;
		}
		return false;
	}
	*/

	//transform.position.x - targetPosition.x
	private void checkFace(float diff){
		if(diff > 0){
			transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
		}else{
			transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
		}
	}

	public bool gotoPostion(Vector2 targetPosition){
		//transform.position = Vector2.Lerp(transform.position,targetPosition, Time.deltaTime);
		
		transform.position = Vector2.Lerp(transform.position,new Vector2( targetPosition.x,transform.position.y), Time.deltaTime);
		checkFace(targetPosition.x - transform.position.x);
		return checkTargetPosition(targetPosition);
	}
	
	public bool checkTargetPosition(Vector2 targetPosition){
		//if(Vector2.Distance(transform.position, targetPosition) < 1.5f )
		if(Mathf.Abs(transform.position.x-targetPosition.x)<0.5f)
		{
			return true;
		}
		return false;
	}

//	public bool gotoPostion(Vector2 targetPosition){
//
//		transform.position = new Vector2(GetBetweenPoint(transform.position, targetPosition, 0.1f).x, transform.position.y);
//		checkFace(targetPosition.x - transform.position.x);
//
//		return checkTargetPosition(targetPosition);
//	}
//	
//	public bool checkTargetPosition(Vector2 targetPosition){
//
//		Debug.Log(transform.position.x - targetPosition.x);
//
//		if(transform.position.x - targetPosition.x < 0.1f)
//		{
//			transform.position = new Vector2(targetPosition.x,transform.position.y);
//
//			return true;
//		}
//		return false;
//	}
//
//	private Vector2 GetBetweenPoint(Vector2 start, Vector2 end, float speed)
//	{
//		Vector2 normal = (end - start).normalized;
//		return normal * speed + start;
//	}
	
	//**************memory part preperation********************





	public void pickLog()
	{
		Debug.Log("got the log");
		GameObject.Find ("log").transform.renderer.enabled=false;
		transform.FindChild("logOnServant").gameObject.renderer.enabled=true;
		
		getThroneRoomScene().getAction().didServantPickTheLog_D=true;
		GameCharConst.SERVANT_PICK_THE_LOG=true;
		isHandsFull=true;
	}
	public void dropLog()
	{
		Debug.Log("drop the log");
		transform.FindChild("logOnServant").gameObject.renderer.enabled=false;
		
		getThroneRoomScene().getAction().didServantDropTheLog_D=true;
		GameCharConst.SERVANT_DROP_THE_LOG=true;
		
		fireBigger();
		
		isHandsFull=false;
	}
	public void pickPaper()
	{
		Debug.Log("got the paper");
		GameObject.Find ("paperInServantRoom").gameObject.renderer.enabled=false;
		transform.FindChild("paperOnServant").gameObject.renderer.enabled=true;
		
		getServantRoomScene().getAction().didServantPickThePaper_D=true;
		GameCharConst.SERVANT_PICK_THE_PAPER=true;
		
		isHandsFull=true;
	}
	public void dropPaper()
	{
		Debug.Log("drop the paper");
		transform.FindChild("paperOnServant").gameObject.renderer.enabled=false;
		GameObject.Find ("paperInThroneRoom").renderer.enabled=true;
		
		getThroneRoomScene().getAction().didServantDropThePaper_D=true;
		GameCharConst.SERVANT_DROP_THE_PAPER=true;
		
		isHandsFull=false;
	}
	public void pickLetter()
	{
		Debug.Log("servant pick letter");
		//transform.FindChild();
		transform.FindChild("letterOnServant").gameObject.renderer.enabled=true;
		GameObject.Find ("letterInThrone").renderer.enabled=false;
		
		getThroneRoomScene().getAction().didServantPickUpTheLetter_D=true;
		GameCharConst.SERVANT_PICK_THE_LETTER=true;
		
		isHandsFull=true;
	}
	public void dropLetter()
	{
		Debug.Log("servant drop letter");
		
		transform.FindChild("letterOnServant").gameObject.renderer.enabled=false;
		GameObject.Find ("letterInServantRoom").renderer.enabled=true;
		
		getServantRoomScene().getAction().didServantDropTheLetterOnHisDesk_D=true;
		GameCharConst.SERVANT_DROP_THE_LETTER_ON_HIS_DESK=true;
		Debug.Log("You Win");
		isHandsFull=false;
	}
	public void takeMedicine()
	{
		Debug.Log("Servant take one pill");
		takeOnePill();
		theMomentWhenKeyPress=false;
	}
	public void passServantDoorTS()
	{

		Debug.Log("decide to pass the door to servant room");
		ServantDoorTS servantDoorTosServant;
		servantDoorTosServant=GameObject.Find("doorToServantRoomFromThrone").GetComponent<ServantDoorTS>();
			
		servantDoorTosServant.servantReadyToGoTS=true;
			
		theMomentWhenKeyPress=false;
	}
	public void passServantDoorST()
	{
		Debug.Log("decide to pass the door to servant room");
		ServantDoorST servantDoorToThrone;
		servantDoorToThrone=GameObject.Find("doorToThroneFromServantRoom").GetComponent<ServantDoorST>();
			
		servantDoorToThrone.servantReadyToGoST=true;
			
		theMomentWhenKeyPress=false;
	}



	public void takeOnePill()
	{
		Debug.Log("The current number of pill"+curPillNum);
		if(curPillNum==0)
		{
			firstPillTime=Time.time;
			Invoke("timeUpCountPill",timeLimit);
		}
		curPillNum++;

	}
	
	public void timeUpCountPill()
	{
		if (curPillNum >= maxPillNum)
			dieOfToMuchPill();
		
		curPillNum=0;
		//firstPillTime=0.0f;
		
	}
	
	public void dieOfToMuchPill()
	{
		Debug.Log ("Servant died of too much medicine");
		getThroneRoomScene ().getAction ().didServantTakeTooMuchMedicine_D = true;
		GameCharConst.SERVANT_TAKE_TOO_MUCH_MEDICINE = true;
		GameObject.Find("Servant").transform.FindChild("Servant").renderer.material.color = new Color(1f, 1f, 1f, 0.1f);

		if(ThroneGameController.currentChar=="Servant")
			Invoke("dieAndReturenToSelection", 5.0f);
	}

	public void dieAndReturenToSelection()
	{
		Application.LoadLevel("CharacterSelectionForTreasure");
	}

	public void fireBigger()
	{
		//GameObject.Find("firePlace").transform.FindChild("fireSmall").renderer.enabled=false;
		//GameObject.Find("firePlace").transform.FindChild("fireBig").gameObject.renderer.enabled=true;

		//ParticleSystem fireParticale=GameObject.Find("fire").GetComponent<ParticleSystem>();
		//fireParticale.startSpeed = 9.0f;

		//fireParticale.GetComponent<Shape>().Radius=1.0f;
	}



	public class ThroneRoomScene{
		private Action action;
		
		public Action getAction()
		{
			if (action == null) 
			{
				action=new Action();
			}
			return action;
		}
		
		public class Action
		{
			public bool didServantPickTheLog_D=false;
			public bool didServantDropTheLog_D=false;

			//public bool didServantPickThePaper_D=false;
			public bool didServantDropThePaper_D=false;

			public bool didServantPickUpTheLetter_D=false;
			//public bool didServantDropTheLetterOnHisDesk_D=false;

			public bool didServantTakeTooMuchMedicine_D=false;


		}
	}

	public class ServantRoomScene{
		private Action action;
		
		public Action getAction()
		{
			if (action == null) 
			{
				action=new Action();
			}
			return action;
		}
		
		public class Action
		{
			//public bool didServantPickTheLog_D=false;
			//public bool didServantDropTheLog_D=false;
			
			public bool didServantPickThePaper_D=false;
			//public bool didServantDropThePaper_D=false;
			
			//public bool didServantPickUpTheLetter_D=false;
			public bool didServantDropTheLetterOnHisDesk_D=false;
			
			//public bool didServantTakeTooMuchMedicine_D=false;
			
			
		}
	}
}

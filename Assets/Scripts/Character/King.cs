using UnityEngine;
using System.Collections;

public class King : MonoBehaviour {

	public bool isDead = false;

	public bool canPickRing=false;
	public bool kingHasSignTheLetter=false;
	public bool canSignTheLetterWithRing = false;

	public bool canTakeMedicine=false;

	public bool canWarmHand=false;

	public bool canTakePotion=false;

	public bool canOpenWindow=false;
	

	//memory
	private bool isMemory = false;
	//kingroom********************************
	private bool goto_doorToKingRoomTK=false;
	private bool goto_windowInKingRoom=false;
	private bool goto_doorToThroneInKingKT=false;

	private GameObject doorToKingRoom;
	private GameObject windowInKing;
	private GameObject doorToThroneRoomInKing;
	//throneroom******************************
	private bool goto_medicineShelf=false;
	private bool goto_firePlace=false;
	private bool goto_ringHolder=false;
	private bool goto_letterShelf=false;
	private bool goto_kingsChair=false;
	private bool goto_medicineShelf_killhimeself=false;
	private bool goto_doorToKingRoom_toGetRing=false;
	private bool goto_doorInKingRoomToThrone_toWarmHand=false;

	private GameObject medicineShelf;
	private GameObject firePlace;
	private GameObject ringHolder;
	private GameObject letterShelf;
	private GameObject kingChair;




	//medicine
	public int maxPillNum=3;
	private int curPillNum=0;
	private float firstPillTime;
	public float timeLimit=3.0f;

	public bool timeToTakeMedicine=false;
	public float whenToTakeMedicine=5.0f;
	public float strugglePeriod=3.0f;

	public bool canPassKingDoorTK=false;
	public bool canPassKingDoorKT=false;

	private bool theMomentWhenKeyPress=true;


	private ThroneRoomScene throneRoomScene;
	private KingRoomScene kingRoomScene;
	
	private bool isHandsFull=false;

	private GameObject servantObj;
	private Servant servant;

	//public

	public ThroneRoomScene getThroneRoomScene()
	{
		if (throneRoomScene == null) 
		{
			throneRoomScene=new ThroneRoomScene();
		}
		return throneRoomScene;
	}

	public KingRoomScene getKingRoomScene()
	{
		if (kingRoomScene == null) 
		{
			kingRoomScene=new KingRoomScene();
		}
		return kingRoomScene;
	}

	// animation
	private Animator animator;

	void Awake(){
		//kingroom******************
		doorToKingRoom=GameObject.Find("doorToKingRoom");
		windowInKing=GameObject.Find("windowInKingRoomKW");
		doorToThroneRoomInKing=GameObject.Find("doorInKingRoomToThrone");


		//throneroom****************
		medicineShelf=GameObject.Find ("medicineShelf");
		firePlace=GameObject.Find ("firePlace");
		ringHolder=GameObject.Find ("ringHolder");
		letterShelf=GameObject.Find ("letterShelf");
		kingChair=GameObject.Find ("kingChair");


		servantObj = GameObject.Find ("Servant");
		servant=servantObj.GetComponent<Servant>();

		animator = transform.FindChild("king").GetComponent<Animator>();

	}

	// Use this for initialization
	void Start () {
		//Invoke("takeMedicineCountDown",whenToTakeMedicine);


		if(ThroneGameController.currentChar != Tags.KING){
			isMemory = true;
		}else{
			// must reset all static const parameters here.
			GameCharConst.resetKing();
		}
	}



	// Update is called once per frame
	void Update () {

		if (!isMemory) 
		{
			if(ThroneGameController.currentChar=="King")
			if(Input.GetKey(KeyCode.Space)){
				//get the pear;
				if(canPickRing)
				{
					pickRing();
					
				}
				if(canSignTheLetterWithRing)
				{
					if(getThroneRoomScene().getAction().didKingPickTheRing_D&&getThroneRoomScene().getAction().didKingWarmHisHand_D)
					{
						if(GameCharConst.SERVANT_DROP_THE_PAPER)
						{
							if(!kingHasSignTheLetter)
							{
								signTheLetterWithRing();
							}
						}
					}
				}
				
				if(canTakeMedicine)
				{
					if(theMomentWhenKeyPress)
					{
						takeMedicine();
					}
				}
				
				if(canWarmHand)
				{
					if(GameCharConst.SERVANT_DROP_THE_LOG)
					{
						warmHand();
					}
				}
				
				if(canTakePotion)
				{
					if(GameCharConst.HERMIT_BREW_POTION)
					{
						takePotion();
					}
				}
				
				
				if(canPassKingDoorTK && getThroneRoomScene().getAction().didKingWarmHisHand_D)
				if(canPassKingDoorTK )
				{
					CameraSwitcher.changeToKingRoom();
					passKingDoorTK();
					//if(theMomentWhenKeyPress)
				}
				
				if(canPassKingDoorKT)
				{
					CameraSwitcher.changeToThroneRoom();
					passKingDoorKT();
					//if(theMomentWhenKeyPress)
				}
				
				if(canOpenWindow)
				{
					openWindow();
				}
				
			}	
		}
		else
		{
			//memo action
			//******memory part kingroom*****************************
			if(goto_doorToKingRoomTK)
			{
				if(gotoPostion(doorToKingRoom.transform.position))
				{
					goto_doorToKingRoomTK=false;
					goto_windowInKingRoom=true;
					passKingDoorTK();
				}
			}
			if(goto_windowInKingRoom)
			{
				if(gotoPostion(windowInKing.transform.position))
				{
					goto_windowInKingRoom=false;
					openWindow();
					goto_doorToThroneInKingKT=true;
				}
			}
			if(goto_doorToThroneInKingKT)
			{
				if(gotoPostion(doorToThroneRoomInKing.transform.position))
				{
					goto_doorToThroneInKingKT=false;
					passKingDoorKT();
				}
			}

			//******memory part kingroom*****************************

			//******memory part throneroom***************************



			//pill time**************
			/*
			if(goto_medicineShelf)
			{
				if(GameCharConst.KING_TAKE_MEDICINE_ON_TIME)
				{
					//if(GameCharConst.KING_TAKE_TOO_MUCH_MEDICINE==false)
					//{
						if(timeToTakeMedicine)
						{
							if(gotoPostion(medicineShelf.transform.position))
								//Debug.Log("mouse ");
							{
								goto_medicineShelf=false;
								takeMedicine();
								getThroneRoomScene().getAction().didKingTakeMedicineOnTime_D=true;
								goto_firePlace=true;

							}
						}


				}
				else
				{
					if(timeToTakeMedicine)
					{
						dieOfNotTakingPillOnTime();
						goto_medicineShelf=false;
						//goto_ringHolder=true;
					}

				}
			}
			*/

			//pill time*****************


			//above is good
			if(goto_firePlace)
			{
				if(GameCharConst.KING_WARM_HIS_HAND)
				{
					if(servant.getThroneRoomScene().getAction().didServantDropTheLog_D)
					{
						if(gotoPostion(firePlace.transform.position))
						{
							goto_firePlace=false;
							warmHand();
							getThroneRoomScene().getAction().didKingWarmHisHand_D=true;
							goto_doorToKingRoom_toGetRing=true;
						}
					}
					
				}
				else
				{
					goto_firePlace=false;
					goto_doorToKingRoom_toGetRing=true;
				}
				
			}



			if(goto_doorToKingRoom_toGetRing)
			{
				if(GameCharConst.KING_PICK_THE_RING)
				{
					if(gotoPostion(doorToKingRoom.transform.position))
					{
						goto_doorToKingRoom_toGetRing=false;
						passKingDoorTK();
						goto_ringHolder=true;
					}
				}
			}

			if(goto_ringHolder)
			{
				if(GameCharConst.KING_PICK_THE_RING)
				{
					if(gotoPostion(ringHolder.transform.position))
					{
						goto_ringHolder=false;
						pickRing();
						getThroneRoomScene().getAction().didKingPickTheRing_D=true;
						goto_doorInKingRoomToThrone_toWarmHand=true;
					}
				}
				else
				{
					goto_ringHolder=false;
					goto_doorInKingRoomToThrone_toWarmHand=true;
				}
			}

			if(goto_doorInKingRoomToThrone_toWarmHand)
			{
				if(GameCharConst.KING_PICK_THE_RING)
				{
					if(gotoPostion(doorToThroneRoomInKing.transform.position))
					{
						goto_doorInKingRoomToThrone_toWarmHand=false;
						passKingDoorKT();
						goto_letterShelf=true;
					}
				}
				else
				{
					goto_doorInKingRoomToThrone_toWarmHand=false;
					goto_letterShelf=true;
				}

			}

			if(goto_letterShelf)
			{
				if(GameCharConst.KING_SIGN_THE_LETTER)
				{
					if(servant.getThroneRoomScene().getAction().didServantDropThePaper_D)
					{
						if(gotoPostion(letterShelf.transform.position))
						{
							goto_letterShelf=false;
							signTheLetterWithRing();
							getThroneRoomScene().getAction().didKingSignTheLetter_D=true;
							goto_kingsChair=true;
						}
					}

				}
				else
				{
					goto_letterShelf=false;
					goto_kingsChair=true;
				}
			}

			//nono
			if(goto_kingsChair)
			{
				if(gotoPostion(kingChair.transform.position))
				{
					goto_kingsChair=false;
					goto_medicineShelf_killhimeself=true;

				}
			}

			if(goto_medicineShelf_killhimeself)
			{
				if(GameCharConst.KING_TAKE_TOO_MUCH_MEDICINE)
				{

						if(gotoPostion(medicineShelf.transform.position))
							//Debug.Log("mouse ");
						{
							goto_medicineShelf_killhimeself=false;
							for(int i=0;i<=5;i++)
								takeMedicine();
							getThroneRoomScene().getAction().didKingTakeTooMuchMedicine_D=true;

						}
					
					
				}
				else
				{
					goto_medicineShelf_killhimeself=false;
				}
			}

			//******memory part throneroom***************************
		}


		if(Input.GetKeyUp(KeyCode.Space))
			theMomentWhenKeyPress=true;
	}




	//**************memory preparation part********************

	private void checkFace(float diff){
		if(diff > 0){
			Vector3 scale = transform.localScale;
			if(scale.x < 0){
				scale.x *= -1;
			}
			
			transform.localScale = scale;
		}else{
			
			Vector3 scale = transform.localScale;
			if(scale.x > 0){
				scale.x *= -1;
			}
			
			transform.localScale = scale;
		}
	}

	public bool gotoPostion(Vector2 targetPosition){
		//transform.position = Vector2.Lerp(transform.position,targetPosition, Time.deltaTime);
		walk();
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
	
	//**************memory preparation part********************
	
	//**************memory part kingroom********************************

	public void startMemoryKingRoom()
	{
		//standby
		transform.position = GameObject.Find ("kingOriKingRoom").transform.position;
		if(GameCharConst.KING_OPEN_THE_WINDOW_IN_HIS_ROOM)
		{
			//Debug.Log("mouse ");
			goto_doorToKingRoomTK=true;
		}
	}

	//**************memory part kingroom********************************

	//**************memory part throneroom******************************
	public void startMemoryThroneRoom()
	{
		goto_firePlace = true;
	}

	//**************memory part throneroom******************************


	//actions King has
	public void pickRing()
	{
		Debug.Log("got the ring");
		GameObject.Find ("ringInKingRoom").transform.renderer.enabled=false;
		GameObject.Find("ringOnKing").gameObject.renderer.enabled=true;
		
		getThroneRoomScene().getAction().didKingPickTheRing_D=true;
		GameCharConst.KING_PICK_THE_RING=true;
	
	}

	public void signTheLetterWithRing()
	{
		Debug.Log("turn paper into letter");
		changePaperToLetter();
	}

	public void takeMedicine()
	{
		Debug.Log("King take one pill");
		takeOnePill();
		theMomentWhenKeyPress=false;
	}
	public void warmHand()
	{
		Debug.Log("King warm his hands and does not feel cold");
		getThroneRoomScene().getAction().didKingWarmHisHand_D=true;
		GameCharConst.KING_WARM_HIS_HAND=true;
	}
	public void takePotion()
	{
		Debug.Log("King drink the potion");
		getThroneRoomScene().getAction().didKingDrinkThePotion_D=true;
		GameCharConst.KING_DRINK_THE_POTION=true;
			
		if(GameCharConst.HERMIT_BREW_HEALING_POTION)
		{
			kingCuredByHealingPotion();
		}
		else
			kingDieOfWronPotion();

	}

	public void kingDieOfWronPotion()
	{

		Debug.Log("King is killed by the wrong potion");
	}

	public void kingCuredByHealingPotion()
	{
		Debug.Log("King is cured");
	}

	public void openWindow()
	{
		Debug.Log("decide to open the window to wood");
		KingWindowKW kingWindowKW;
		KingWindowWK kingWindowWK;

		kingWindowKW=GameObject.Find("windowInKingRoomKW").GetComponent<KingWindowKW>();
		kingWindowWK=GameObject.Find("windowInKingRoomWK").GetComponent<KingWindowWK>();
			
		kingWindowKW.openTheWindow();
		kingWindowWK.openTheWindow();
			

		getKingRoomScene().getAction().didKingOpenTheWindowInHisRoom_D=true;
		GameCharConst.KING_OPEN_THE_WINDOW_IN_HIS_ROOM = true;

		theMomentWhenKeyPress=false;	
	}

	//**********medicine**************
	private void takeMedicineCountDown()
	{
		GameObject.Find ("illSign").transform.renderer.enabled = true;
		Debug.Log ("Time for King to take pills");
		timeToTakeMedicine = true;
		Invoke ("checkIfKingTakePillOnTime",strugglePeriod);
	}
	
	private void checkIfKingTakePillOnTime()
	{
		if (timeToTakeMedicine)
			dieOfNotTakingPillOnTime ();
		else
		{
			Debug.Log("King takes pills on time");
			GameObject.Find ("illSign").transform.renderer.enabled = false;
		}
	}
	
	private void dieOfNotTakingPillOnTime ()
	{
		GameObject.Find("King").transform.FindChild("King").renderer.material.color = new Color(1f, 1f, 1f, 0.1f);
		if(ThroneGameController.currentChar=="King")
		Application.LoadLevel("CharacterSelectionForTreasure");
		Debug.Log ("Kind died of not taking pill on time");
	}

	public void takeOnePill()
	{
		Debug.Log("The current number of pill"+curPillNum);
		if (timeToTakeMedicine) 
		{
			timeToTakeMedicine=false;
			getThroneRoomScene().getAction().didKingTakeMedicineOnTime_D=true;
			GameCharConst.KING_TAKE_MEDICINE_ON_TIME=true;
		}
		else
		{
			if(curPillNum==0)
			{
				firstPillTime=Time.time;
				Invoke("timeUpCountPill",timeLimit);
			}
			curPillNum++;
		}
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
		GameObject.Find("King").transform.FindChild("King").renderer.material.color = new Color(1f, 1f, 1f, 0.1f);
		Debug.Log ("King died of too much medicine");
		getThroneRoomScene ().getAction ().didKingTakeTooMuchMedicine_D = true;
		GameCharConst.KING_TAKE_TOO_MUCH_MEDICINE = true;

		if(ThroneGameController.currentChar=="King")

			Invoke("dieAndReturenToSelection", 1.5f);

		die();

		//Invoke ("dieAndReturenToSelection",0.5f);
	}

	public void die(){
		animator.SetBool("DieOfTooMuchMedicine", true);
	}

	public void walk(){
		animator.SetBool("IsWalking", true);
	}
	
	public void stopWalk(){
		animator.SetBool("IsWalking", false);
	}

	public void dieAndReturenToSelection()
	{
		Application.LoadLevel("CharacterSelectionForTreasure");
	}

	public void changePaperToLetter()
	{
		Debug.Log("sign the paper");
		GameObject.Find ("paperInThroneRoom").transform.renderer.enabled = false;
		//Destroy(GameObject.Find ("paperInThroneRoom"));
		GameObject.Find ("letterInThrone").transform.renderer.enabled = true;
		GameObject.Find("ringOnKing").gameObject.renderer.enabled=false;
		GameObject.Find ("ringOnLetterShelf").renderer.enabled = true;
		
		getThroneRoomScene().getAction().didKingSignTheLetter_D=true;
		GameCharConst.KING_SIGN_THE_LETTER=true;


		//transform.FindChild ("ringOnKing").gameObject.renderer.enabled=false;
		//GameObject.Find ("ringOnLetterShelf").renderer.enabled=true;

	}


	public void passKingDoorTK()
	{
		//if (theMomentWhenKeyPress) 
		{
			canPassKingDoorTK = false;
			Debug.Log("decide to pass the door to King room");
			KingDoorTK kingDoorToKing;
			kingDoorToKing=GameObject.Find("doorToKingRoom").GetComponent<KingDoorTK>();
			
			kingDoorToKing.kingReadyToGoTK=true;
			
			theMomentWhenKeyPress=false;	
		}

	}



	public void passKingDoorKT()
	{
		//if (theMomentWhenKeyPress) 
		{
			Debug.Log("decide to pass the door to throne room");
			KingDoorKT kingDoorToThrone;
			kingDoorToThrone=GameObject.Find("doorInKingRoomToThrone").GetComponent<KingDoorKT>();
			
			kingDoorToThrone.kingReadyToGoKT=true;
			
			theMomentWhenKeyPress=false;
		}

	}




	void OnCollision2D(Collision2D coll)
	{
		if (coll.gameObject.transform.name == "Servant")
			Debug.Log ("Why there is no one come to see me?");
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
			//public bool didKingTakeThePill_D=false;

			public bool didKingWarmHisHand_D=false;

			//public bool didKingOpenTheWindowInHisRoom_D=false;

			public bool didKingSignTheLetter_D = false;

			public bool didKingPickTheRing_D = false;

			public bool didKingTakeMedicineOnTime_D = false;

			public bool didKingTakeTooMuchMedicine_D=false;

			public bool didKingDrinkThePotion_D = false;

		}
	}


	public class KingRoomScene{
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
			//public bool didKingTakeThePill_D=false;
		
			public bool didKingOpenTheWindowInHisRoom_D=false;

		}
	}

}

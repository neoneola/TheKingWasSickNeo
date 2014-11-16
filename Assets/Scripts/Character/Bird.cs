using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {
	public bool isDead = false;
	private ServantRoomScene servantRoomScene;
	private KingRoomScene kingRoomScene;

	public bool canPickLetter;
	public bool canDropLetter;

	public bool canPassTheWindowKW;
	public bool canPassTheWindowWK;

	public bool canKickKey;

	private bool theMomentWhenKeyPress=true;

	//memory 

	private bool isMemory = false;
	//servantroom*****************************
	private GameObject paperShelf;
	private GameObject windowServantRoomSW;
	private GameObject hutLetterShelf;

	private bool goto_papershelf_pickletter = false;
	public  bool goto_window_outofservantroom = false;
	private bool goto_hutlettershelf = false;

	//kingroom********************************
	//private bool goto_kingroom_origin=false;
	private GameObject windowKingRoomWK;
	private GameObject keyShelfInKingRoom;
	private GameObject windowKingRoomKW;

	private bool goto_keyshelf=false;
	private bool goto_window_intokingroom = false;
	private bool goto_window_outofkingroom = false;



	private GameObject servantObj;
	private Servant servant;
	private GameObject kingObj;
	private King king;


	
	public ServantRoomScene getServantRoomScene()
	{
		if (servantRoomScene == null) 
		{
			servantRoomScene=new ServantRoomScene();
		}
		return servantRoomScene;
	}

	public KingRoomScene getKingRoomScene()
	{
		if (kingRoomScene == null) 
		{
			kingRoomScene=new KingRoomScene();
		}
		return kingRoomScene;
	}

	void Awake()
	{
		//servantroom memory
		paperShelf = GameObject.Find ("paperShelf");
		windowServantRoomSW = GameObject.Find ("windowServantRoomSW");
		hutLetterShelf = GameObject.Find ("paperShelfInHut");

		//kingroom memory
		windowKingRoomWK = GameObject.Find ("windowInKingRoomWK");
		keyShelfInKingRoom = GameObject.Find ("keyShelfInKingRoom");
		windowKingRoomKW = GameObject.Find ("windowInKingRoomKW");


		servantObj = GameObject.Find ("Servant");
		servant=servantObj.GetComponent<Servant>();

		kingObj = GameObject.Find ("King");
		king=kingObj.GetComponent<King>();
	}

	// Use this for initialization
	void Start () {
		if(ThroneGameController.currentChar != Tags.BIRD){
			isMemory = true;
		}else{
			// must reset all static const parameters here.
			GameCharConst.resetBird();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!isMemory) 
		{
			if(ThroneGameController.currentChar=="Bird")
				if (Input.GetKey (KeyCode.Space)) 
				{
					if(canPickLetter)
					{
						pickLetter();				
					}
				
					if(canDropLetter)
					{
						dropLetter();		
					}

					if(canPassTheWindowKW&&king.getKingRoomScene().getAction().didKingOpenTheWindowInHisRoom_D)
					{
					//if (theMomentWhenKeyPress) 
						passTheWindowKW();
						//if(theMomentWhenKeyPress)
					}
				
					if(canPassTheWindowWK&&king.getKingRoomScene().getAction().didKingOpenTheWindowInHisRoom_D)
					{
					//if (theMomentWhenKeyPress) 
						passTheWindowWK();
						//if(theMomentWhenKeyPress)
					}

					if(canKickKey)
					{
						kickKey();
					}
				}	
		}
		else
		{
			//memo action
			//******memory part servantroom*****************************
			if(goto_papershelf_pickletter&&servant.getServantRoomScene().getAction().didServantDropTheLetterOnHisDesk_D){
				if(gotoPostion(paperShelf.transform.position)){
					goto_papershelf_pickletter = false;
					pickLetter();
					getServantRoomScene().getAction().dropTheLetter=true;
					goto_window_outofservantroom = true;
				}
			}
			
			if(goto_window_outofservantroom){
				if(gotoPostion(windowServantRoomSW.transform.position)){
					goto_window_outofservantroom = false;
					goto_hutlettershelf=true;
				}
			}
			if(goto_hutlettershelf)
			{
				Debug.Log("the third step");
				if(gotoPostion(hutLetterShelf.transform.position)){
					goto_hutlettershelf=false;
					dropLetter();

				}
			}

			//******memory part servantroom*****************************
			//&&king.getKingRoomScene().getAction().didKingOpenTheWindowInHisRoom_D
			//**************memory part kingroom********************************
			if(goto_window_intokingroom&&king.getKingRoomScene().getAction().didKingOpenTheWindowInHisRoom_D)
			{
				Debug.Log("nonono should not start");
				if(gotoPostion(windowKingRoomWK.transform.position))
				{
					goto_window_intokingroom=false;
					goto_keyshelf=true;
					passTheWindowWK();
				}
			}
			if(goto_keyshelf)
			{
				if(gotoPostion(keyShelfInKingRoom.transform.position))
				{
					goto_keyshelf=false;
					kickKey();
					getKingRoomScene().getAction().kickKey=true;
					goto_window_outofkingroom=true;
				}
			}
			if(goto_window_outofkingroom)
			{
				if(gotoPostion(windowKingRoomKW.transform.position))
				{
					goto_window_outofkingroom=false;
					passTheWindowKW();
					goto_window_intokingroom=false;
				}
			}
			//**************memory part kingroom********************************
		}

		if(Input.GetKeyUp(KeyCode.Space))
			theMomentWhenKeyPress=true;

	}



	//memo control

	//**************memory part servantroom*****************************
	public void startMemoryServantRoom(){
		if (GameCharConst.BIRD_GET_THE_LETTER) 
		{
			goto_papershelf_pickletter=true;
		}
		Debug.Log ("bird memory");

	}
	//**************memory part servantroom*****************************

	//**************memory part kingroom********************************
	public void startMemoryKingRoom()
	{
		Debug.Log("bird start memory");
		//standby
		transform.position = GameObject.Find ("birdOriKingRoom").transform.position;
		if(GameCharConst.BIRD_KICK_THE_KEY)
		{
			goto_window_intokingroom=true;
		}
	}
	//**************memory part kingroom********************************



	//**************memory preparation part********************
	public bool gotoPostion(Vector2 targetPosition){
		transform.position = Vector2.Lerp(transform.position, targetPosition, Time.deltaTime);
		return checkTargetPosition(targetPosition);
	}
	
	public bool checkTargetPosition(Vector2 targetPosition){
		if(Vector2.Distance(transform.position, targetPosition) < 0.5f ){
			return true;
		}
		return false;
	}
	
	//**************memory preparation part********************



	public void pickLetter()
	{
		Debug.Log("pick the letter");
		//Destroy(GameObject.Find ("pearlInTreasure"));	
		
		GameObject.Find("letterInServantRoom").renderer.enabled=false;
		transform.FindChild("letterOnBird").gameObject.renderer.enabled=true;
		
		getServantRoomScene().getAction().getTheLetter=true;
		
		GameCharConst.BIRD_GET_THE_LETTER=true;
	}

	public void dropLetter()
	{
		Debug.Log("drop the letter");
		//Destroy(GameObject.Find ("pearlInTreasure"));	
		
		GameObject.Find("letterInHut").renderer.enabled=true;
		transform.FindChild("letterOnBird").gameObject.renderer.enabled=false;
		
		getServantRoomScene().getAction().dropTheLetter=true;
		
		GameCharConst.BIRD_DROP_THE_LETTER=true;
	}


	public void passTheWindowKW()
	{
		//if (theMomentWhenKeyPress) 
		{
			Debug.Log("decide to pass the window to wood");
			KingWindowKW kingWindowKW;
			kingWindowKW=GameObject.Find("windowInKingRoomKW").GetComponent<KingWindowKW>();
			
			kingWindowKW.birdReadyToGoKW=true;
			
			theMomentWhenKeyPress=false;	
		}

	}

	public void passTheWindowWK()
	{
		//if (theMomentWhenKeyPress) 
		{
			Debug.Log("decide to pass the window to king");
			KingWindowWK kingWindowWK;
			kingWindowWK=GameObject.Find("windowInKingRoomWK").GetComponent<KingWindowWK>();
			
			kingWindowWK.birdReadyToGoWK=true;
			
			theMomentWhenKeyPress=false;	
		}
	}

	public void kickKey()
	{
		Debug.Log("decide to kick the key");
	
		GameObject.Find("keyOnShelfInKingRoom").renderer.enabled=false;
		GameObject.Find("keyInKingRoom").renderer.enabled=true;

		getKingRoomScene ().getAction ().kickKey = true;
		
		GameCharConst.BIRD_KICK_THE_KEY=true;
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
			public bool kickKey = false;
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
			public bool getTheLetter = false;
			public bool dropTheLetter = false;

		}
	}

}

using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour {
	public bool isDead = false;

	public bool canBeTrapped=false;
	public bool canPickKey=false;
	public bool canDropKey=false;

	public bool canPassKingDoorTK=false;
	public bool canPassKingDoorKT=false;

	private ThroneRoomScene throneRoomScene;
	private KingRoomScene kingRoomScene;
	
	private bool isHandsFull=false;


	//memeory
	private bool isMemory = false;
	//kingroom********************************
	private bool goto_kingdoorTK=false;
	private bool goto_keyareainkingroom=false;
	private bool goto_kingdoorKT=false;

	private GameObject doorToKingRoom;
	private GameObject areaForKeyInKingRoom;
	private GameObject doorInKingRoomToThrone;

	GameObject birdObj;
	Bird bird;

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

	void Awake()
	{
		doorToKingRoom=GameObject.Find("doorToKingRoom");
		areaForKeyInKingRoom=GameObject.Find("areaForKeyInKingRoom");
		doorInKingRoomToThrone=GameObject.Find("doorInKingRoomToThrone");


		birdObj=GameObject.Find("Bird");
		bird=birdObj.GetComponent<Bird>();
	}

	// Use this for initialization
	void Start () {
		if(ThroneGameController.currentChar != Tags.MOUSE){
			isMemory = true;
		}else{
			// must reset all static const parameters here.
			GameCharConst.resetMouse();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!isMemory) 
		{
			if(ThroneGameController.currentChar=="Mouse")
			if(Input.GetKey(KeyCode.Space)){
				if(canPickKey)
				{
					if(bird.getKingRoomScene().getAction().kickKey)
						pickKey();
				}
				if (canDropKey) 
				{
					if(getKingRoomScene().getAction().didMouseGrabTheKeyInKingRoom_D)
					{
						dropKey();
					}
				}

				if(canPassKingDoorKT)
				{
					passKingDoorKT();
				}

				if(canPassKingDoorTK)
				{
					passKingDoorTK();
				}
				
			}	
		}
		else
		{


			//memo action
			//&&bird.getKingRoomScene().getAction().kickKey==true
			//******memory part kingroom*****************************
			if(goto_kingdoorTK&&bird.getKingRoomScene().getAction().kickKey==true)
			{
				if(gotoPostion(doorToKingRoom.transform.position))
				{
					goto_kingdoorTK=false;
					goto_keyareainkingroom=true;
					passKingDoorTK();
				}
			}
			if(goto_keyareainkingroom)
			{
				if(gotoPostion(areaForKeyInKingRoom.transform.position))
				{
					goto_keyareainkingroom=false;
					pickKey();
					getKingRoomScene().getAction().didMouseGrabTheKeyInKingRoom_D=true;
					goto_kingdoorKT=true;

				}
			}
			if(goto_kingdoorKT)
			{
				if(gotoPostion(doorInKingRoomToThrone.transform.position))
				{
					goto_kingdoorKT=false;
					goto_kingdoorTK=false;
					passKingDoorKT();
				}
			}
			//******memory part kingroom*****************************
		}

		if(canBeTrapped)
		{
			getThroneRoomScene().getAction().didMouseTrapped_D=true;
			GameCharConst.MOUSE_IS_TRAPPED=true;	
			dieOfBeingTrapped();
		}

	}


	//**************memory part kingroom********************************
	public void startMemoryKingRoom()
	{
		//standby
		transform.position = GameObject.Find ("mouseOriKingRoom").transform.position;
		if(GameCharConst.MOUSE_GRAB_KEY_FROM_KINGROOM)
		{
			Debug.Log("mouse ");
			goto_kingdoorTK=true;
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


	public void dieOfBeingTrapped()
	{
		Debug.Log("be trapped");
		if(GetComponent<PlayerMovementController>())
		GetComponent<PlayerMovementController>().enabled=false;


	}
	
	public void pickKey()
	{
		Debug.Log("got the key");
		Destroy(GameObject.Find ("keyInKingRoom"));
		transform.FindChild("keyOnMouse").gameObject.renderer.enabled=true;
		
		getKingRoomScene().getAction().didMouseGrabTheKeyInKingRoom_D=true;
		GameCharConst.MOUSE_GRAB_KEY_FROM_KINGROOM=true;
	}
	public void dropKey()
	{
		Debug.Log("drop the key");
		GameObject.Find ("Key").gameObject.renderer.enabled=true;
		transform.FindChild("keyOnMouse").gameObject.renderer.enabled=false;
			
		getThroneRoomScene().getAction().didMouseDropTheKey_D=true;
		GameCharConst.MOUSE_DROP_KEY=true;

	}


	public void passKingDoorTK()
	{
		//if (theMomentWhenKeyPress) 
		{
			Debug.Log("decide to pass the door to King room");
			KingDoorTK kingDoorToKing;
			kingDoorToKing=GameObject.Find("doorToKingRoom").GetComponent<KingDoorTK>();
			
			kingDoorToKing.mouseReadyToGoTK=true;
			
			//theMomentWhenKeyPress=false;	
		}
		
	}
	
	
	
	public void passKingDoorKT()
	{
		//if (theMomentWhenKeyPress) 
		{
			Debug.Log("decide to pass the door to throne room");
			KingDoorKT kingDoorToThrone;
			kingDoorToThrone=GameObject.Find("doorInKingRoomToThrone").GetComponent<KingDoorKT>();
			
			kingDoorToThrone.mouseReadyToGoKT=true;
			
			//theMomentWhenKeyPress=false;
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
			
			public bool didMouseGrabTheKeyInKingRoom_D=false;
			//public bool didMouseDropTheKey_D = false;
			
			//public bool didMouseTrapped_D = false;
			
		}
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
			
			//public bool didMouseGrabTheKeyInKingRoom_D=false;
			public bool didMouseDropTheKey_D = false;

			public bool didMouseTrapped_D = false;
			
		}
	}

}

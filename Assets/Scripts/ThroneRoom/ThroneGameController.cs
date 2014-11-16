using UnityEngine;
using System.Collections;

public class ThroneGameController : MonoBehaviour {

	public static string currentChar = "";

	private Hermit hermit;
	private Thief thief;
	private King king;
	private Mouse mouse;
	private Servant servant;
	private Bird bird;

	private GameObject hermitObj;
	private GameObject thiefObj;
	private GameObject kingObj;
	private GameObject mouseObj;
	private GameObject servantObj;
	private GameObject birdObj;

	private CameraFollow cameraFollow;


	void Awake(){
		hermitObj = GameObject.FindGameObjectWithTag(Tags.HERMIT);
		hermit = hermitObj.GetComponent<Hermit>();
		
		thiefObj = GameObject.FindGameObjectWithTag(Tags.THIEF);
		thief = thiefObj.GetComponent<Thief>();
		
		kingObj = GameObject.FindGameObjectWithTag(Tags.KING);
		king = kingObj.GetComponent<King>();
		
		mouseObj = GameObject.FindGameObjectWithTag(Tags.MOUSE);
		mouse = mouseObj.GetComponent<Mouse>();
		
		servantObj = GameObject.FindGameObjectWithTag(Tags.SERVANT);
		servant = servantObj.GetComponent<Servant>();

		birdObj = GameObject.FindGameObjectWithTag(Tags.BIRD);
		bird = birdObj.GetComponent<Bird>();


		cameraFollow = Camera.main.camera.GetComponent<CameraFollow>();
	}


	// Use this for initialization
	void Start () {
		//Debug.Log ("current char:::"+ThroneGameController.currentChar);
		switch(ThroneGameController.currentChar){
			
		case "Hermit":
			hermitObj.AddComponent<PlayerMovementController>();
			setupForHermit();
			//the other characters should get computer control scripts
			break;
	
		case "Thief":
			thiefObj.AddComponent<PlayerMovementController>();
			setupForThief();
			break;

		case "King":
			kingObj.AddComponent<PlayerMovementController>();
			setupForKing();
			//setupForThief();
			break;

		case "Mouse":
			mouseObj.AddComponent<PlayerMovementController>();
			setupForMouse();
			//setupForThief();
			break;

		case "Servant":
			servantObj.AddComponent<PlayerMovementController>();
			setupForServant();
			//setupForThief();
			break;

		case "Bird":
			birdObj.AddComponent<PlayerMovementController>();
			setupForBird();
			//setupForThief();
			break;

		default:
			break;
			cameraFollow.setPlayer(ThroneGameController.currentChar);

		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void setupForThief(){
		
	}

	private void setupForHermit(){
		
	}

	private void setupForKing(){

		//kingroom
		/*
		mouse.startMemoryKingRoom ();
		bird.startMemoryKingRoom ();
		*/


		//throneroom
		servant.startMemoryThroneRoom ();
	}

	private void setupForMouse(){
		//kingroom
		/*
		king.startMemoryKingRoom ();
		bird.startMemoryKingRoom ();
		*/
	}

	private void setupForServant(){
		//servant room
		/*
		if(GameCharConst.BIRD_GET_THE_LETTER)
		{
			bird.startMemoryServantRoom();

			Debug.Log("servant start memory");
		
		}
		*/

		//king room
		/*
		mouse.startMemoryKingRoom ();
		if (GameCharConst.BIRD_KICK_THE_KEY) 
		{
			bird.startMemoryKingRoom();
			
			Debug.Log("servant start memory");
		}
		*/

		//throne toom
		king.startMemoryThroneRoom ();
	}

	private void setupForBird(){
		//servant room
		/*
		if(GameCharConst.SERVANT_PICK_THE_LETTER){
			//bird starts memory
			//<<<<<<< Updated upstream:Assets/Scripts/SceneController.cs
			servant.startMemoryServantRoom();
			Debug.Log("servant start memory");
			//=======
			//bird.startMemherory();
			//>>>>>>> Stashed changes:Assets/Scripts/HutScene/HutSceneController.cs


		}
		*/

		//king room
		/*
		mouse.startMemoryKingRoom();
		king.startMemoryKingRoom ();
		*/


	}

}

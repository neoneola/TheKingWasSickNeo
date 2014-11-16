using UnityEngine;
using System.Collections;

public class Thief : MonoBehaviour {

	public bool isDead = false;

	private TreasureRoomScene treasureRoomScene;
	
	private bool isHandsFull=false;

	public bool canGetPeal=false;


	//memory
	private bool isMemory = false;
	//throneroom********************************


	public TreasureRoomScene getTreasureRoomScene()
	{


		if(treasureRoomScene==null)
		{
			treasureRoomScene=new TreasureRoomScene ();
		}
		return treasureRoomScene;
	}



	// Use this for initialization
	void Start () 
	{
		//getTreasureRoomScene ().getAction ().didThiefStealThePearl_D = false;
		//PlayerPrefs.SetInt("didThiefStealThePearl_D",1);

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!isMemory) 
		{
			if(ThroneGameController.currentChar=="Thief")
				if (Input.GetKey (KeyCode.Space)) 
				{
					if(canGetPeal)
					{
						getPearl();
					
					}
				
				}	
		}
		else
		{

		}

	}


	//**************memory part throneroom********************************
	public void startMemoryKingRoom()
	{
		
	}
	
	
	//**************memory part throneroom********************************



	public void getPearl()
	{
		Debug.Log("got the pearl");
		Destroy(GameObject.Find ("pearlInTreasure"));
		transform.FindChild("pearlOnThief").gameObject.renderer.enabled=true;
		
		getTreasureRoomScene().getAction().didThiefStealThePearl_D=true;
		
		GameCharConst.THIEF_GET_THE_PEARL=true;
	}

	public class TreasureRoomScene
	{
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
			public bool didThiefStealThePearl_D;
			
		}
		
	}
}

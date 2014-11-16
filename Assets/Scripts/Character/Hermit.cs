using UnityEngine;
using System.Collections;

public class Hermit : MonoBehaviour {

	public bool isDead = false;

	public bool canHandInPotion=false;

	public bool canGetKey = false;
	public bool canSeeTheCrystalBall = false;


	//******should be changed
	public bool canBrewWrongPotion=false;
	public bool canBrewHealingPotion=false;


	private TreasureRoomScene treasureRoomScene;

	private ThroneRoomScene throneRoomScene;

	private bool isHandsFull=false;


	//memory
	private bool isMemory = false;
	//throneroom********************************



	void Start()
	{
		if(TreasureGameController.currentChar == "Hermit"){ 
			GameCharConst.resetHermit();
		}

	}

	public ThroneRoomScene getThroneRoomScene()
	{
		if (throneRoomScene == null) 
		{
			throneRoomScene=new ThroneRoomScene();
		}
		return throneRoomScene;
	}
	
	public TreasureRoomScene getTreasureRoomScene()
	{
		if(treasureRoomScene==null)
		{
			treasureRoomScene=new TreasureRoomScene ();
		}
		return treasureRoomScene;
	}
		
	
	void Update(){
		if (!isMemory) 
		{
			if(ThroneGameController.currentChar=="Hermit")
				if (Input.GetKey (KeyCode.Space)) 
			{
				if(canGetKey)
				{
					getKey();
				}
				
				
				if(canSeeTheCrystalBall)
				{
					getTreasureRoomScene().getAction().didHermitSeeTheCrystbalBall_D=true;
					GameCharConst.HERMIT_SEE_THE_CRYSTALBALL_D=true;
					
					Debug.Log("You should get pearl for the healing potion");
					
				}
				
				
				if(canHandInPotion)
				{
					if(getTreasureRoomScene().getAction().didHermitBrewThePotion_D)
					{
						if(getTreasureRoomScene().getAction().didHermitBrewHealingPotion_D)
						{
							handInHealingPotion();
						}
						else
						{
							handInWrongPotion();
						}
						
					}
				}
				
				
				//*******
				if(canBrewWrongPotion)
				{
					if(getTreasureRoomScene().getAction().didHermitBrewThePotion_D==false)
					{
						brewWrongPotion();
					}
					
					
				}
				
				if(canBrewHealingPotion)
				{
					if(getTreasureRoomScene().getAction().didHermitBrewThePotion_D==false)
					{
						brewHealingPotion();
						
					}
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




	public void getKey()
	{
		Debug.Log("got the key");
		Destroy(GameObject.Find ("Key"));
		transform.FindChild("keyOnHermit").gameObject.renderer.enabled=true;
		
		getThroneRoomScene().getAction().didHermitPickUpTheKey_D=true;
		GameCharConst.HERMIT_PICKS_UP_THE_KEY_D=true;

	}
	public void handInHealingPotion()
	{
		GameObject.Find ("healingPotionInThrone").transform.renderer.enabled=true;
		transform.FindChild("healingPotionOnH").gameObject.renderer.enabled=false;
		Debug.Log("hand in healing potion");

		getTreasureRoomScene().getAction().didHermitHandInPotion_D=true;
		GameCharConst.HERMIT_HAND_IN_POTION=true;

	}

	public void handInWrongPotion()
	{
		GameObject.Find ("wrongPotionInThrone").transform.renderer.enabled=true;
		transform.FindChild("wrongPotionOnH").gameObject.renderer.enabled=false;
		Debug.Log("hand in wrong potion");

		getTreasureRoomScene().getAction().didHermitHandInPotion_D=true;
		GameCharConst.HERMIT_HAND_IN_POTION=true;

	}

	public void brewWrongPotion()
	{
			Debug.Log("got wrong potion");
			Destroy(GameObject.Find ("wrongPotionOutside"));
			transform.FindChild("wrongPotionOnH").gameObject.renderer.enabled=true;
			
			getTreasureRoomScene().getAction().didHermitBrewThePotion_D=true;
			GameCharConst.HERMIT_BREW_POTION=true;
			
			getTreasureRoomScene().getAction().didHermitBrewHealingPotion_D=false;
			GameCharConst.HERMIT_BREW_HEALING_POTION=false;
	}

	public void brewHealingPotion()
	{
			Debug.Log("got healing potion");
			Destroy(GameObject.Find ("healingPotionOutside"));
			transform.FindChild("healingPotionOnH").gameObject.renderer.enabled=true;
			
			getTreasureRoomScene().getAction().didHermitBrewThePotion_D=true;
			GameCharConst.HERMIT_BREW_POTION=true;
			
			getTreasureRoomScene().getAction().didHermitBrewHealingPotion_D=true;
			GameCharConst.HERMIT_BREW_HEALING_POTION=true;
	
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

			public bool didHermitSeeTheCrystbalBall_D = false;

			//should be changed when merged into the final project
			public bool didHermitBrewThePotion_D = false;
			public bool didHermitBrewHealingPotion_D=false;
			public bool didHermitHandInPotion_D = false;

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
			public bool didHermitPickUpTheKey_D = false;	
		}
	}


}



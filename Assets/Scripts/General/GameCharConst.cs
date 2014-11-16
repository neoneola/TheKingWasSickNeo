using UnityEngine;
using System.Collections;

public class GameCharConst{

	//bird variables
	public static bool BIRD_HAS_BEEN_PLAYED = false;
	public static bool BIRD_DROP_THE_LETTER = false;
	//bird kingroom
	public static bool BIRD_GET_THE_LETTER=false;
	public static bool BIRD_KICK_THE_KEY=false;


	//hermit variables
	public static bool HERMIT_HAS_BEEN_PLAYED = false;//?
	public static int HERMIT_POTION_TYPE = 0; //0:none. 1:healing. 2:slumber. 3:poison

	public static bool HERMIT_IS_IG_A_ADDED = false;
	public static bool HERMIT_IS_IG_B_ADDED = false;
	public static bool HERMIT_IS_IG_C_ADDED = false;
	public static bool HERMIT_IS_IG_D_ADDED = false;
	public static bool HERMIT_IS_IG_E_ADDED = false;


	//hermit treasure Neo
	public static bool HERMIT_PICKS_UP_THE_KEY_D=false;
	public static bool HERMIT_SEE_THE_CRYSTALBALL_D=false;
	//SHOULD BE CHANGED
	public static bool HERMIT_BREW_POTION=false;
	public static bool HERMIT_BREW_HEALING_POTION=false;
	public static bool HERMIT_HAND_IN_POTION=false;



	//thief variable
	public static bool THIEF_HAS_BEEN_PLAYED = false;//?

	public static bool THIEF_GET_THE_CLOAK = false;

	//thief treasure Neo
	public static bool THIEF_GET_THE_PEARL=false;

	//King throne Neo
	public static bool KING_TAKE_THE_PILL=false;
	public static bool KING_WARM_HIS_HAND=false;
	public static bool KING_OPEN_THE_WINDOW_IN_HIS_ROOM=false;
	public static bool KING_SIGN_THE_LETTER=false;
	public static bool KING_PICK_THE_RING=false;

	public static bool KING_TAKE_MEDICINE_ON_TIME=false;
	public static bool KING_TAKE_TOO_MUCH_MEDICINE=false;

	public static bool KING_DRINK_THE_POTION=false;


	//Servant throne Neo


	public static bool SERVANT_PICK_THE_LOG=false;
	public static bool SERVANT_DROP_THE_LOG=false;

	public static bool SERVANT_PICK_THE_PAPER=false;
	public static bool SERVANT_DROP_THE_PAPER=false;//must be changed

	public static bool SERVANT_PICK_THE_LETTER=false;
	public static bool SERVANT_DROP_THE_LETTER_ON_HIS_DESK=false;

	public static bool SERVANT_TAKE_TOO_MUCH_MEDICINE=false;



	//Mouse throne Neo
	public static bool MOUSE_GRAB_KEY_FROM_KINGROOM=false;
	public static bool MOUSE_DROP_KEY=false;
	public static bool MOUSE_IS_TRAPPED=false;
	/*
public bool didMouseGrabTheKeyInKingRoom_D=false;
			public bool didMouseDropTheKey_D = false;

			public bool didMouseTrapped_D = false;
	 */


	//Bird 



	public static void resetHermit(){
		HERMIT_POTION_TYPE = 0;
		HERMIT_IS_IG_A_ADDED = false;
		HERMIT_IS_IG_B_ADDED = false;
		HERMIT_IS_IG_C_ADDED = false;
		HERMIT_IS_IG_D_ADDED = false;
		HERMIT_IS_IG_E_ADDED = false;


		//hermit treasure neo
		HERMIT_PICKS_UP_THE_KEY_D=false;
		HERMIT_SEE_THE_CRYSTALBALL_D=false;


		//should be changed
		HERMIT_BREW_POTION=false;
		HERMIT_BREW_HEALING_POTION=false;
		HERMIT_HAND_IN_POTION=false;

	}

	public static void resetKing(){

		//King throne Neo
		KING_TAKE_THE_PILL=false;
		KING_WARM_HIS_HAND=false;
		KING_OPEN_THE_WINDOW_IN_HIS_ROOM=false;
		KING_SIGN_THE_LETTER=false;
		KING_PICK_THE_RING=false;

		KING_TAKE_MEDICINE_ON_TIME=false;
		KING_TAKE_TOO_MUCH_MEDICINE=false;
	}

	public static void resetServant()
	{
		SERVANT_PICK_THE_LOG=false;
		SERVANT_DROP_THE_LOG=false;
		
		SERVANT_PICK_THE_PAPER=false;
		SERVANT_DROP_THE_PAPER=false;
		
		SERVANT_PICK_THE_LETTER=false;
		SERVANT_DROP_THE_LETTER_ON_HIS_DESK=false;

		SERVANT_TAKE_TOO_MUCH_MEDICINE=false;
	}


	public static void resetMouse()
	{
		MOUSE_GRAB_KEY_FROM_KINGROOM=false;
		MOUSE_DROP_KEY=false;
		MOUSE_IS_TRAPPED=false;
	}

	public static void resetBird()
	{
		BIRD_GET_THE_LETTER=false;
		BIRD_DROP_THE_LETTER=false;

		BIRD_KICK_THE_KEY=false;

	}
}

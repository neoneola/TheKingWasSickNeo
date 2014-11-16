using UnityEngine;
using System.Collections;

public class Scenes {

	public static string FOREST = "ForestScene";
	//public static string HUT = "HutScene";
	public static string CHAR_SELECT_SCENE = "SelectCharacter";

	public static string TREASURE = "TreasureRoomScene";

	public static string THRONE = "ThroneRoomScene";

	public static void LoadLevel(string lelName){
		Application.LoadLevel(lelName);
	}
}

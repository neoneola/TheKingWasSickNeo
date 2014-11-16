using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour {

	public Texture2D blackScreen;
	public float fadeOutTime = 2f;
	float fadeOutTimer = 0f;
	void Start () {
	}
	void Update () {

	}
	void OnGUI() {
		if (fadeOutTimer < fadeOutTime) {
			GUI.Window(-1,new Rect(0,0,Screen.width,Screen.height),OnBlScr,"",new GUIStyle());
			GUI.BringWindowToFront(-1);
		}
	}
	void OnBlScr(int index) {
		GUI.color = new Color(1,1,1,1 - (fadeOutTimer / fadeOutTime));
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),blackScreen);
	}

	void fadeOutAction()
	{
		if (fadeOutTimer >= 0 && fadeOutTimer < fadeOutTime) {
			fadeOutTimer += Time.deltaTime;
		}
	}

	void OnMouseDown()
	{

		
		//float alpha = renderer.material.color.a;
		//alpha = 0.5f;
		fadeOutAction ();
		Invoke ("jumpToNext",1.0f);
	}
	
	void jumpToNext()
	{
		Application.LoadLevel("SelectCharacter");	
	}
}

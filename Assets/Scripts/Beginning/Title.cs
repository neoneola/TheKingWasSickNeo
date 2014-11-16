using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {
	private float tempTime = 0.0f;
	private bool isFadingOut=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//print(renderer.material.color.a);

		if(isFadingOut==true)
			fadeOut();
	
	}

	void OnMouseDown()
	{

		//float alpha = renderer.material.color.a;
		//alpha = 0.5f;
		isFadingOut = true;
		Invoke ("jumpToNext",1.0f);
	}

	void jumpToNext()
	{

		Application.LoadLevel("SelectCharacter");	
	}

	void fadeOut(){

		Debug.Log ("fade out");
		if(tempTime < 1)
		{
			tempTime = tempTime + Time.deltaTime*0.05f;
		}
		if(renderer.material.color.a >0)
		{
			renderer.material.color = (1 - tempTime) * renderer.material.color;
		}
		checkOver ();
	}


	private void checkOver(){
		if(renderer.material.color.a <= 0.05f){
			renderer.material.color = Color.clear;
			Destroy(gameObject);
		}
	}
}

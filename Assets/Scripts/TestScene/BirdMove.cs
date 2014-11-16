using UnityEngine;
using System.Collections;

public class BirdMove : MonoBehaviour {

	private bool isApplePickedByPeople=false;

	//public for testing
	public bool isControlledByPC= true;

	private int hasBeenPicked;

	private static int pickedTime = 0;

	public float speed=0.05f;

	// Use this for initialization
	void Start () {
		GameObject.Find ("birdPotion").transform.renderer.enabled = false;


		if (PlayerPrefs.GetInt ("CharacterChosen") == 1)
			isControlledByPC = false;
		else
			isControlledByPC = true;
			


		if (!isControlledByPC)
			PlayerPrefs.SetInt("AppleHasBeenPicked",0);
	}
	
	// Update is called once per frame
	void Update () {
		if (!isControlledByPC)
			Move ();
		else
			defaultMode ();
	}


	void Move()
	{
		if (Input.GetKey (KeyCode.A))
			transform.Translate (new Vector2(-speed,0.0f));
		
		if (Input.GetKey (KeyCode.D))
			transform.Translate (new Vector2(speed,0.0f));

		if (Input.GetKey (KeyCode.W))
			transform.Translate (new Vector2(0.0f,speed));

		if (Input.GetKey (KeyCode.S))
			transform.Translate (new Vector2(0.0f,-speed));

	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.name == "potion")
		{
			GameObject.Find ("birdPotion").transform.renderer.enabled = true;
			isApplePickedByPeople=true;
			Debug.Log("is apple picked:"+isApplePickedByPeople);

			PlayerPrefs.SetInt("AppleHasBeenPicked",1);
		}
	}

	void defaultMode ()
	{
		if(PlayerPrefs.GetInt("AppleHasBeenPicked")==1)
			transform.Translate (new Vector2(speed*0.5f,-0.0f));
		else
			transform.Translate (new Vector2(speed*0.5f,0.002f));
	}


	private void flip(){

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
}

using UnityEngine;
using System.Collections;

public class HumanMove : MonoBehaviour {

	//public for testing
	public bool isControlledByPC= false;
	
	public float speed=0.1f;

	private float direction=1.0f;
	// Use this for initialization
	void Start () {

		
		if (PlayerPrefs.GetInt ("CharacterChosen") == 2)
			isControlledByPC = false;
		else
			isControlledByPC = true;
	
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
			transform.Translate (new Vector2(-speed*direction,0.0f));
		
		if (Input.GetKey (KeyCode.D))
			transform.Translate (new Vector2(speed*direction,0.0f));
		
	}

	void defaultMode ()
	{
		transform.Translate (new Vector2(speed*direction,0));
		if(transform.position.x < -1.0f || transform.position.x > 10.0f){
			flip();
		}
	}

	private void flip(){
		direction *= -1;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}

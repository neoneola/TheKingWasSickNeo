using UnityEngine;
using System.Collections;

public class PeopleControl : MonoBehaviour {

	//public for testing
	public bool isControlledByPC= false;
	
	public float speed=0.1f;
	private Animator animator;
	private BoxCollider2D coll2D;
	private bool curDirectionIsRight;
	
	private float direction=1.0f;
	// Use this for initialization
	void Start () {
		


		if (PlayerPrefs.GetInt ("CharacterChosen") == 2)
			isControlledByPC = false;
		else
			isControlledByPC = true;

		animator = transform.GetChild(0).GetComponent<Animator>();
		curDirectionIsRight = true;

		coll2D = GetComponent<BoxCollider2D>();

		//coll2D.enabled = false;

		//Vector2 size = coll2D.size;
		//size.Set(0.7f,1.5f)
		
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


		if (Input.GetKey (KeyCode.A)&&!Input.GetKey (KeyCode.D)) 
		{
			if (Input.GetKeyDown (KeyCode.A)) 
			{
				if(curDirectionIsRight)
				{
					flip();
					curDirectionIsRight=false;
				}
			}		
			transform.Translate (new Vector3 (speed * direction, 0.0f, 0.0f));
			animator.SetBool("isWalking", true);
		}

		if (Input.GetKeyUp (KeyCode.A)) 
		{
			animator.SetBool("isWalking", false);
		}



		if (Input.GetKey (KeyCode.D)&&!Input.GetKey (KeyCode.A)) 
		{
			if (Input.GetKeyDown (KeyCode.D)) 
			{
				if(!curDirectionIsRight)
				{
					flip();
					curDirectionIsRight=true;
				}
			}		if(!curDirectionIsRight)
				flip();
			transform.Translate (new Vector3 (speed * direction, 0.0f, 0.0f));
			animator.SetBool("isWalking", true);
		}

		if (Input.GetKeyUp (KeyCode.D)) 
		{
			animator.SetBool("isWalking", false);
		}
		
	}
	
	void defaultMode ()
	{
		transform.Translate (new Vector2(speed*direction,0));
		animator.SetBool("isWalking", true);

		if(transform.position.x < -3.0f || transform.position.x > 3.0f){
			flip();
		}
	}
	
	private void flip(){
		direction *= -1;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}


	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.name == "birdPotion")
		{
			animator.SetBool("isDying",true);

			speed=0;

			//float sizeY = coll2D.size.y;
			//sizeY = 1.5f;

			coll2D.size = new Vector2 (1.0f,1.5f);
			coll2D.center = new Vector2 (-0.16f,-1.6f);
		}

	}
}








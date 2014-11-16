using UnityEngine;
using System.Collections;

public class Route : MonoBehaviour {

	private int currentStep = 0; 

	private bool atTHeBeginningSoSpeedIsZero=true;

	//store the spot where the character will be
	public Transform[] spotsArray=new Transform[31];

	public Transform spot0;
	public Transform spot1;
	public Transform spot2;
	public Transform spot3;
	public Transform spot4;
	public Transform spot5;
	public Transform spot6;
	public Transform spot7;
	public Transform spot8;
	public Transform spot9;
	public Transform spot10;
	public Transform spot11;
	public Transform spot12;
	public Transform spot13;
	public Transform spot14;
	public Transform spot15;
	public Transform spot16;
	public Transform spot17;
	public Transform spot18;
	public Transform spot19;
	public Transform spot20;
	public Transform spot21;
	public Transform spot22;
	public Transform spot23;
	public Transform spot24;
	public Transform spot25;
	public Transform spot26;
	public Transform spot27;
	public Transform spot28;
	public Transform spot29;
	public Transform spot30;


	public bool preparationDown = false; //after all the spot assigned, it becomes true

	public Transform target;		// Reference to the player's transform.


	public float xMargin = 0.1f;		// Distance in the x axis the player can move before the camera follows.
	public float yMargin = 0.1f;		// Distance in the y axis the player can move before the camera follows.
	public float xSmooth = 1.0f;		// How smoothly the camera catches up with it's target movement in the x axis.
	public float ySmooth = 1.0f;		// How smoothly the camera catches up with it's target movement in the y axis.
	public Vector2 maxXAndY=new Vector2(10,0);		// The maximum x and y coordinates the camera can have.
	public Vector2 minXAndY=new Vector2(-10,0);		// The minimum x and y coordinates the camera can have.

	private bool curSpotFinished=false;
	private int curSpotNum=0;


	/*
	public void nextStep(){
		currentStep ++;
		Debug.Log ("next step");
	}
	*/

	bool CheckXMargin()
	{
		// Returns true if the distance between the camera and the player in the x axis is greater than the x margin.
		return Mathf.Abs(transform.position.x - target.position.x) > xMargin;
	}
	
	
	bool CheckYMargin()
	{
		// Returns true if the distance between the camera and the player in the y axis is greater than the y margin.
		return Mathf.Abs(transform.position.y - target.position.y) > yMargin;
	}

	void Awake()
	{

	}

	void Start()
	{
		/*
		for(int j=0;j++;i<=20)
		{
			spotsArray[j]=null;
		}
		*/


		//put spots into array
		spotsArray [0] = spot0;



		spotsArray [1] = spot1;
		spotsArray [2] = spot2;
		spotsArray [3] = spot3;
		spotsArray [4] = spot4;
		spotsArray [5] = spot5;

		spotsArray [6] = spot6;
		spotsArray [7] = spot7;
		spotsArray [8] = spot8;
		spotsArray [9] = spot9;
		spotsArray [10] = spot10;


		spotsArray [11] = spot11;
		spotsArray [12] = spot12;
		spotsArray [13] = spot13;
		spotsArray [14] = spot14;
		spotsArray [15] = spot15;
		
		spotsArray [16] = spot16;
		spotsArray [17] = spot17;
		spotsArray [18] = spot18;
		spotsArray [19] = spot19;
		spotsArray [20] = spot20;


		spotsArray [21] = spot21;
		spotsArray [22] = spot22;
		spotsArray [23] = spot23;
		spotsArray [24] = spot24;
		spotsArray [25] = spot25;
		

		spotsArray [26] = spot26;
		spotsArray [27] = spot27;
		spotsArray [28] = spot28;
		spotsArray [29] = spot29;
		spotsArray [30] = spot30;
		/**/



		//**************

		curSpotNum = 1;

		target=spotsArray[1];


		preparationDown = true;
	}
	
	void FixedUpdate ()
	{
		if(preparationDown){
			if(target !=null)
			TrackPlayer();
			//GoToThisSpot(curSpotNum);
		}


		//if (transform.rigidbody2D.velocity == Vector2.zero)
			//;
			//Invoke("changeTarget",1);


		if ((transform.position.x-target.position.x)<0.5f&&(transform.position.x-target.position.x)>-0.5f)
			changeTarget ();


		//&&atTHeBeginningSoSpeedIsZero==false
	}


	void changeTarget()
	{
		//if (transform.rigidbody2D.velocity == Vector2.zero) 
		//{		
			Debug.Log ("change target");
			int i=curSpotNum+1;
			for (i= curSpotNum+1; i<=30; i++) 
			{
				if(spotsArray[i]!=null)
				{
					target=spotsArray[i];
					curSpotNum=i;
					break;
				}
				
			}
			curSpotNum=i;
		//}



	}

	/*
	void OnCollisionEnter2D(Collision2D other)

	{
		Debug.Log (other.gameObject.name);
		//transform.rigidbody2D.isKinematic=true;


		if (other.gameObject.name == target.name) 
		{
			Invoke("changeTarget",1);
			Invoke("changeKinematicToTrue",0.01f);

		}

		inCollision=true;

	}
	*/

	/*
	
	void OnCollisionExit2D(Collision2D other)
	{
		//transform.rigidbody2D.isKinematic=false;

		Invoke("changeKinematicToFalse",0.75f);
		inCollision=false;
	}
	 
	void changeKinematicToFalse()
	{
		if(inCollision==false)
		transform.rigidbody2D.isKinematic=false;
	}

	void changeKinematicToTrue()
	{
		transform.rigidbody2D.isKinematic=true;
	}
	*/

	
	void TrackPlayer ()
	{
		
		// By default the target x and y coordinates of the camera are it's current x and y coordinates.
		float targetX = transform.position.x;
		float targetY = transform.position.y;
		
		// If the player has moved beyond the x margin...
		if (CheckXMargin ()) 
		{// ... the target x coordinate should be a Lerp between the camera's current x position and the player's current x position.
			targetX = Mathf.Lerp (transform.position.x, target.position.x, xSmooth * Time.deltaTime);
		}
		
		// If the player has moved beyond the y margin...
		if(CheckYMargin())
			// ... the target y coordinate should be a Lerp between the camera's current y position and the player's current y position.
			targetY = Mathf.Lerp(transform.position.y, target.position.y, ySmooth * Time.deltaTime);
		
		// The target x and y coordinates should not be larger than the maximum or smaller than the minimum.
		targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
		targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

		
		// Set the camera's position to the target position with the same z component.
		transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
	}

	
}
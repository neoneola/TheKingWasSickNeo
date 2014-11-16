using UnityEngine;
using System.Collections;

public class TailControl : MonoBehaviour {
	int dir=1;
	// Use this for initialization
	void Start () {
		WaveTail ();
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void WaveTail()
	{	dir*=-1;
		JointMotor2D motor;
		HingeJoint2D hingeJoint;
		foreach (Transform child in transform)
		{


			//motor=child.hingeJoint2D.motor;
			motor = child.GetComponent<HingeJoint2D>().motor;
			//hingeJoint = child.GetComponent<HingeJoint2D>();
			motor.motorSpeed=50*dir;
			//hingeJoint.motor=motor;

			child.GetComponent<HingeJoint2D>().motor=motor;
		}	


		Invoke ("WaveTail",2);
	}

}

using UnityEngine;
using System.Collections;

public class MovingHorizontal : MonoBehaviour {

	float initialPosition;
	public float finalPosition;
	//public float speed;
	public Vector3 speed = new Vector3();
	public bool isStartingOnLeft;
	bool isGoingLeft = false;

	float currentPositionX;

	void Start () {
		initialPosition = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
			currentPositionX = transform.position.x;
			transform.position += speed;

			if (isStartingOnLeft)
						startOnLeft ();
				else
						startOnRight ();
			
		}

	void startOnLeft(){
		if (currentPositionX > finalPosition && !isGoingLeft) {		
			speed = speed * -1f;
			isGoingLeft = true;
		} else if (currentPositionX <= initialPosition && isGoingLeft) {	
			speed = speed * -1f;
			isGoingLeft = false;
		}
	}

	void startOnRight(){
		if (currentPositionX < finalPosition && !isGoingLeft) {		
			speed = speed * -1f;
			isGoingLeft = true;
		} else if (currentPositionX >= initialPosition && isGoingLeft) {	
			speed = speed * -1f;
			isGoingLeft = false;
		}
	}

}


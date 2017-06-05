using UnityEngine;
using System.Collections;

public class MovingVertical : MonoBehaviour {

	float initialPosition;
	public float finalPosition;
	public Vector3 speed = new Vector3();
	bool isGoingUp = true;
	float currentPositionY;

	void Start () {
		initialPosition = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		currentPositionY = transform.position.y;
		transform.position += speed;
		
		if (currentPositionY > finalPosition && isGoingUp) {		
			speed = speed * -1f;
			isGoingUp = false;
		}else if(currentPositionY <= initialPosition && !isGoingUp){	
			speed = speed * -1f;
			isGoingUp = true;
		}
	}
}

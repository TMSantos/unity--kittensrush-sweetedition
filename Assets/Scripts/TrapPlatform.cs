using UnityEngine;
using System.Collections;

public class TrapPlatform : MonoBehaviour {

	public float stopPositionY;
	public float stopPositionX;
	public bool isToRight;
	public bool isToUp;
	public bool isRotateTrap;
	public float rotateSpeed;
	public string rotatePointName;
	public float stopRotatePoint;

	private Vector3 currentPosition;
	private bool isTriggered;

	private Vector3 directionX;

	private Vector3 originalPosition;
	private Vector3 rotatePoint;


	void Start(){
		currentPosition = new Vector3 ();
		directionX = new Vector3 (0.5f,0,0);
		isTriggered = false;
		originalPosition = transform.position;

		if(isRotateTrap) rotatePoint = GameObject.Find (rotatePointName).transform.position;

	}

	void FixedUpdate(){
		currentPosition = transform.position;	
		
		if (isTriggered) {
			if(isRotateTrap){
				rotateTrap();
			}else if(isToUp){
				isToUpTrap();
			}else{
				isToDownTrap();
			}
		}
	}

	void Update () {
	}

	public void isToUpTrap(){
		if(currentPosition.y > stopPositionY){
			if(isToRight){
				moveRight();
			}else{
				moveLeft();
			}
			
		}else {
			moveUp();
		}
	}

	public void isToDownTrap(){
		if(currentPosition.y < stopPositionY){
			if(isToRight){
				moveRight();
			}else{
				moveLeft();
			}
			
		}else {
			moveDown();
		}
	}

	public void rotateTrap(){
		if((transform.localEulerAngles.z  - stopRotatePoint) > 1)
		   transform.RotateAround (rotatePoint, new Vector3(0,0,1), rotateSpeed * Time.deltaTime);
	}

	public void moveRight(){
		if(currentPosition.x <  stopPositionX){
			transform.position += directionX;
		}
	}

	public void moveLeft(){
		if(currentPosition.x >  stopPositionX){
			transform.position -= directionX;
		}
	}

	public void moveUp(){
		transform.position += Vector3.up;
	}

	public void moveDown(){
		transform.position += Vector3.down;
	}
	void OnTriggerEnter2D(Collider2D collider){
		if(!isTriggered && collider.name.Equals("Cat")){
			isTriggered = true;
		}
	}
}

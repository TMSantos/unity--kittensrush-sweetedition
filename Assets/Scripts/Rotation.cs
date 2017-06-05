using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

	public float rotateSpeed;
	public bool is360Rotate;
	public bool isGoingDownFirst;

	public float stopRotatePoint;
	public float initRotatePoint;

	private Vector3 rotatePoint;
	public string rotatePointName;
	private Vector3 rotateAxis;
	private bool invertDirection = false;
	// Use this for initialization

	void Start () {
		rotateAxis = new Vector3 (0, 0, 1);
		if(!is360Rotate) rotatePoint = GameObject.Find (rotatePointName).transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (is360Rotate)
			do360rotation ();
		else if (isGoingDownFirst)
			customRotateDown ();
		else
			customRotateUp ();
			
	}

	private void do360rotation(){
		transform.Rotate (rotateAxis, rotateSpeed * Time.deltaTime);
	}

	private void customRotateDown(){
		if (!invertDirection) {
			if((transform.localEulerAngles.z) > (stopRotatePoint+2) ){
				transform.RotateAround (rotatePoint, rotateAxis, rotateSpeed * Time.deltaTime);
			}else{
				invertDirection= !invertDirection;
			}
		}else{
			if((transform.localEulerAngles.z - initRotatePoint) < (stopRotatePoint+2))
				transform.RotateAround (rotatePoint, rotateAxis, -rotateSpeed * Time.deltaTime);
			else
				invertDirection= !invertDirection;
		}	
	}

	 private void customRotateUp(){
		if (!invertDirection) {
			if((transform.localEulerAngles.z) > (stopRotatePoint+2) ){
				transform.RotateAround (rotatePoint, rotateAxis, -rotateSpeed * Time.deltaTime);
			}else{
				invertDirection= !invertDirection;
			}
		}else{
			if((transform.localEulerAngles.z ) < (initRotatePoint-2))
				transform.RotateAround (rotatePoint, rotateAxis, rotateSpeed * Time.deltaTime);
			else
				invertDirection= !invertDirection;
		}	
	}

}

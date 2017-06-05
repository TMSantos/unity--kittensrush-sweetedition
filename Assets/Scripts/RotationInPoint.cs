using UnityEngine;
using System.Collections;

public class RotationInPoint : MonoBehaviour {

	public float rotateSpeed;
	public GameObject rotateLocal;

	private Vector3 rotatePoint;
	private Vector3 rotateAxis;
	
	void Start () {
		rotateAxis = new Vector3 (0, 0, 1);
		rotatePoint = rotateLocal.transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
		doRotation ();
		
	}
	
	private void doRotation(){
		transform.RotateAround (rotatePoint, rotateAxis, rotateSpeed * Time.deltaTime);
	}	
}

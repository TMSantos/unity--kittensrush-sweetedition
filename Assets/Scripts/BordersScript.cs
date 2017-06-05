using UnityEngine;
using System.Collections;

public class BordersScript : MonoBehaviour {

	public float positionX;
	private GameObject cameraObject;

	void Start () {		
		cameraObject = GameObject.FindGameObjectWithTag ("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPos = new Vector3 (positionX,cameraObject.transform.position.y,11);
		transform.position = newPos;
	
	}
}

using UnityEngine;
using System.Collections;

public class MiddleCottonSensor : MonoBehaviour {

	private GameObject catObject;
	private CatScript cat;

	private GameObject cameraObject;
	private CameraHelper camera;

	// Use this for initialization
	void Start () {
		catObject = GameObject.FindGameObjectWithTag("Player");
		cat = catObject.GetComponent<CatScript> ();

		cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
		camera = cameraObject.GetComponent<CameraHelper> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.name.Equals("Cat")){
			camera.speed = 1f;
			cat.catMaxSpeed = 1f;
			cat.rigidbody2D.gravityScale = 0.1f;
		}
	}
}

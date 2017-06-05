using UnityEngine;
using System.Collections;

public class CottonCandyScript : MonoBehaviour {

	private GameObject catObject;
	CatScript cat;

	private GameObject cameraObject;
	private CameraHelper camera;

	private float cameraPreviousSpeed;

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
			camera.speed = 8f;
			cat.catMaxSpeed = 5f;
			cat.rigidbody2D.gravityScale = 1f;
		}
	}
}

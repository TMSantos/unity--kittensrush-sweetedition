using UnityEngine;
using System.Collections;

public class OnlySpeed : MonoBehaviour {

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
		if (collider.name.Equals ("Cat")) {
			cat.rigidbody2D.gravityScale = 1f;
			cat.catMaxSpeed = 10f;
			cat.rigidbody2D.AddForce (Vector2.up * 100f);
			camera.speed = 8f;
		}
	}
}

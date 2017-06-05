using UnityEngine;
using System.Collections;

public class SpeedInjector : MonoBehaviour {

	private GameObject catObject;
	private CatScript cat;
	private Animator animator;

	private GameObject cameraObject;
	private CameraHelper camera;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		animator.SetBool("SpeedInjector", false);

		catObject = GameObject.FindGameObjectWithTag("Player");
		cat = catObject.GetComponent<CatScript> ();

		cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
		camera = cameraObject.GetComponent<CameraHelper> ();
	}

	void castCat(){
		cat.canMove = true;
		animator.SetBool("SpeedInjector", false);
		cat.rigidbody2D.gravityScale = 1f;
		cat.catMaxSpeed = 10f;
		cat.rigidbody2D.AddForce(Vector2.up * 100f);

		camera.speed=8f;
		

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.name.Equals("Cat")){
			animator.SetBool("SpeedInjector", true);
			cat.rigidbody2D.velocity = Vector3.zero;
			cat.rigidbody2D.gravityScale = 0f;
			camera.speed = 0f;
			cat.canMove = false;
			//cat.catMaxSpeed = 10f;
			//camera.speed=8f;
		}
	}
}

using UnityEngine;
using System.Collections;

public class PopCornMode : MonoBehaviour {

	private GameObject foregroundCamera;
	private CameraHelper cameraScript;

	private GameObject cat;
	private CatScript catScript;

	private bool popCornModeInitialized;

	public float popCornModeTimer;
	private float timer;

	void Start () {
		popCornModeInitialized = false;
		foregroundCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		cameraScript = foregroundCamera.GetComponent<CameraHelper> ();

		cat = GameObject.FindGameObjectWithTag ("Player");
		catScript = cat.GetComponent<CatScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (popCornModeInitialized) {
			timer += Time.deltaTime;
			if (timer > popCornModeTimer) {
					cameraScript.speed = 2f;
					catScript.isCatInPopCornMode = false;
					cat.rigidbody2D.isKinematic = false;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (!popCornModeInitialized) {
			popCornModeInitialized = true;
			cameraScript.speed = 0f;
			catScript.isCatInPopCornMode = true;
		}
	}
}

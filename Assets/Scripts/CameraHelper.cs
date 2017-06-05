using UnityEngine;
using System.Collections;

public class CameraHelper : MonoBehaviour {

	public float speed;
	public Vector3 maxSpeed = new Vector3();
	public float levelEnd;
	private GameObject cat;
	private CatScript catScript;

	private float distance;

	public bool isGravityInverted;

	void Start(){
		cat = GameObject.FindGameObjectWithTag ("Player");
		catScript = cat.GetComponent<CatScript> ();
		isGravityInverted = false;
	}

	// Update is called once per frame
	void Update () {
		if (catScript.lostLevel == true) {
			return;
		}

		if (transform.position.y > levelEnd) {
			catScript.winLevel = true;
			return;
		}

		if (transform.position.y > cat.transform.position.y + 12) {
			catScript.lostLevel = true;
			return;
		}
		
		distance = (cat.transform.position - transform.position).magnitude;	

		if (!isGravityInverted) {
			if (distance > 0 && cat.transform.position.y > transform.position.y) {
				maxSpeed.y = cat.rigidbody2D.velocity.y + 1;
				transform.position += maxSpeed * Time.deltaTime;
			} else {
				transform.position += speed * Vector3.up * Time.deltaTime;
			}
		} else {
			transform.position += speed * Vector3.down * 3 * Time.deltaTime;
		}
		

	}
}

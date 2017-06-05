using UnityEngine;
using System.Collections;

public class customMoveSpikeBullet : MonoBehaviour {

	private Vector3 speed;
	private Vector3 firstStopPosition;
	private Vector3 secondStopPosition;

	public float speedValue;

	private bool isTriggered;

	// Use this for initialization
	void Start () {
		isTriggered = false;
		speed = new Vector3 (-speedValue,0, 0);
		firstStopPosition = GameObject.Find ("stop1").transform.position;
		secondStopPosition = GameObject.Find ("stop2").transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (isTriggered) {
				transform.position += speed;

				if (transform.position.x < firstStopPosition.x && transform.position.y < secondStopPosition.y) {
						speed = new Vector3 (0, speedValue, 0);
						transform.rotation = Quaternion.AngleAxis (-90, Vector3.forward);
				}

				if (transform.position.y > secondStopPosition.y) {
						speed = new Vector3 (speedValue, 0, 0);
						transform.rotation = Quaternion.AngleAxis (180, Vector3.forward);
				}

				if (transform.position.x > 10f) {
						Destroy (gameObject);
				}
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.name.Equals ("Cat")) {
			isTriggered = true;
		}
	}
}

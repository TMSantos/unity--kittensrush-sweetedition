using UnityEngine;
using System.Collections;

public class MovingVertical2 : MonoBehaviour {

	Vector3 initialPosition;
	public Vector2 range;
	public float speed;

	public bool shouldRotate;

	// Use this for initialization
	void Start () {
		initialPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.up * speed;
		
		if (transform.position.y > (initialPosition.y + range.x)) {
			speed *= -1;
			if(shouldRotate) transform.rotation = Quaternion.AngleAxis (0, Vector3.forward);
			
		} else if (transform.position.y < (initialPosition.y + range.y)) {
			speed *= -1;
			if(shouldRotate) transform.rotation = Quaternion.AngleAxis (180, Vector3.forward);
		}
	
	}
}

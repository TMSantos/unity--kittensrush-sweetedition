using UnityEngine;
using System.Collections;

public class DirectMovement : MonoBehaviour {

	public Vector3 direction;
	public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += direction * speed;
	}
}

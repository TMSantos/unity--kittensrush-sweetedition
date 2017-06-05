using UnityEngine;
using System.Collections;

public class CaramelPlatform : MonoBehaviour {

	private Transform cat;
	private Vector3 addPositon =  new Vector3(0,-2f,0);

	// Use this for initialization
	void Start () {
		cat = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {			
		Quaternion rotation = Quaternion.LookRotation(cat.position - transform.position - addPositon, transform.TransformDirection(Vector3.up));
		transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
	}
}

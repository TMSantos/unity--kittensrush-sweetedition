using UnityEngine;
using System.Collections;

public class FallPlatforms : MonoBehaviour {

	public GameObject[] fallingPlatforms;
	public float fallingMass;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.name.Equals("Cat")){
			foreach(GameObject obj in fallingPlatforms){
				obj.rigidbody2D.isKinematic = false;
				obj.rigidbody2D.gravityScale = -2f;
				obj.rigidbody2D.mass = fallingMass;
			}
		}
	}
}

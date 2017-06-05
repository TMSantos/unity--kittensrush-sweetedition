using UnityEngine;
using System.Collections;

public class GunBullet : MonoBehaviour {

	public bool attach;
	public float bulletWeight = 1.5f;
	public float bulletMass = 3f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	void OnCollisionEnter2D(Collision2D collision) {
		if (attach && collision.collider.name.Equals ("Cat")) {
			rigidbody2D.mass = bulletMass;
			rigidbody2D.gravityScale = -bulletWeight;
			rigidbody2D.angularVelocity = 0f;
			rigidbody2D.fixedAngle = true;
			DistanceJoint2D dj2d = gameObject.AddComponent( "DistanceJoint2D" ) as DistanceJoint2D;
			dj2d.connectedBody = collision.gameObject.rigidbody2D;

		}
	}
}

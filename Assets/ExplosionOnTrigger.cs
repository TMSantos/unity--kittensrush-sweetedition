using UnityEngine;
using System.Collections;

public class ExplosionOnTrigger : MonoBehaviour {

	public float explosion_power = 10f;
	public GameObject explosionLocal;

	bool exploded = false;
	CircleCollider2D explosionZone;
	ArrayList objectsAffected;
	
	// Use this for initialization
	void Start () {
		explosionZone = gameObject.GetComponent<CircleCollider2D> ();
		objectsAffected = new ArrayList ();
	}
	
	// Update is called once per frame
	void Update () {

		if (exploded == true)
			return;
	}

	void FixedUpdate(){
	}


	void OnTriggerEnter2D(Collider2D collider){

		if(collider.gameObject.rigidbody2D != null)
		{
			if(!collider.name.Equals("Cat")) objectsAffected.Add(collider.gameObject);

		}

		if (collider.name.Equals ("Cat")) {
			exploded = true;
			explosion();
		}
	}

	void explosion(){
		foreach (GameObject affectObject in objectsAffected) {
			Vector2 explosionTarget = affectObject.transform.position;
			Vector2 bomb = explosionLocal.transform.position;
			
			Vector2 direction = explosion_power * (explosionTarget - bomb);

			affectObject.rigidbody2D.AddForceAtPosition(new Vector2(direction.x, direction.y),explosionLocal.transform.position);
		}

	}

}

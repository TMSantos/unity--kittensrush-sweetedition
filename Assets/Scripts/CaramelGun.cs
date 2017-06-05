using UnityEngine;
using System.Collections;

public class CaramelGun : MonoBehaviour {

	public Rigidbody2D caramelRocket;	
	public float speed;
	public float fireCastRate;
	private float timer = 0;
	public float destroyTime;
	public bool shouldAttach = false;
	public float bulletWeight = 1.5f;
	public float bulletMass = 3f;
	public float attackDistance = 20;

	private Transform cat;

	// Use this for initialization
	void Start () {
		cat = GameObject.FindGameObjectWithTag ("Player").transform;

	}
		
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;
		float distance = Vector3.Distance (transform.position, cat.position);

		if (timer > fireCastRate && distance < attackDistance) {
			Rigidbody2D bulletInstance = Instantiate (caramelRocket, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
			
			GunBullet gun = bulletInstance.gameObject.GetComponent<GunBullet>();
			gun.bulletWeight = bulletWeight;
			gun.bulletMass = bulletMass;
			
			if (shouldAttach)
				gun.attach = true;
			else
				gun.attach = false;
			Destroy (bulletInstance.gameObject, destroyTime);
			Vector3 dist = (cat.transform.position - transform.position);
			bulletInstance.velocity = dist.normalized * speed;
			timer = 0;
		}
	
	}


}

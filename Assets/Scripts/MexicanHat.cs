using UnityEngine;
using System.Collections;

public class MexicanHat : MonoBehaviour {

	private int bulletsFired;
	private bool isActivated;

	public int numberOfBullets;
	public float rotateSpeed;
	public GameObject hatGun;
	public float gunCastRate;

	public Rigidbody2D cakeRocket;
	public Rigidbody2D vegRocket;

	public Sprite cake,veg;

	public float bulletSpeed;

	// Use this for initialization
	void Start () {
		gunCastRate = 0;
		bulletsFired = 0;
		isActivated = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isActivated) return;
		if (bulletsFired == numberOfBullets) return;

		transform.Rotate (0,0,rotateSpeed*Time.deltaTime);
		gunCastRate += Time.deltaTime;

		if (gunCastRate > 1) {
			bulletsFired++;
			gunCastRate = 0;

			if(Random.Range(1,3) == 1){
				Rigidbody2D bulletInstance = Instantiate (cakeRocket, hatGun.transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
				bulletInstance.gameObject.GetComponent<SpriteRenderer> ().sprite = cake;
				bulletInstance.gameObject.name="Cake";

				Vector2 heading = hatGun.transform.position - transform.position;
				float distance = heading.magnitude;
				Vector2 direction = heading / distance;

				bulletInstance.velocity = direction*bulletSpeed;

				Destroy (bulletInstance.gameObject, 20f);

			}else{
				Rigidbody2D bulletInstance = Instantiate (vegRocket, hatGun.transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
				bulletInstance.gameObject.GetComponent<SpriteRenderer> ().sprite = veg;
				bulletInstance.gameObject.name="Vegetable";

				Vector2 heading = hatGun.transform.position - transform.position;
				float distance = heading.magnitude;
				Vector2 direction = heading / distance;
				
				bulletInstance.velocity = direction*bulletSpeed;

				Destroy (bulletInstance.gameObject, 20f);

			}


		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.name.Equals ("Cat")) {
			isActivated = true;
		}
	}
}

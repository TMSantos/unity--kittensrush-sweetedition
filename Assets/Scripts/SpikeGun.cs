using UnityEngine;
using System.Collections;

public class SpikeGun : MonoBehaviour {

	public Rigidbody2D spikeBullet;	
	public float spikeCastRate;
	public float destroyTimer;
	private float spikeCastRateTimer;
	public float rotation;

	private GameObject spikeObject;
	private DirectMovement spikeScript;

	public Vector3 spikeDirection;
	public float spikeSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		spikeCastRateTimer += Time.deltaTime;
	
		if(spikeCastRateTimer > spikeCastRate){
			spikeCastRateTimer = 0;
			Rigidbody2D bulletInstance = Instantiate (spikeBullet, transform.position, Quaternion.Euler (new Vector3 (0, 0, rotation))) as Rigidbody2D;
			spikeObject = bulletInstance.gameObject;
			spikeScript = spikeObject.GetComponent<DirectMovement> ();
			spikeScript.direction = spikeDirection;
			spikeScript.speed = spikeSpeed;
			Destroy (bulletInstance.gameObject, destroyTimer);
			}
		}

}

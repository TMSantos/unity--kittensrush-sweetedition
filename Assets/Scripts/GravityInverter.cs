using UnityEngine;
using System.Collections;

public class GravityInverter : MonoBehaviour {

	private GameObject camObject;
	private CameraHelper cam;

	public float negativeGravityValue;
	public float positiveGravityValue;
	public bool isInvertingDown;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		camObject = GameObject.FindGameObjectWithTag("MainCamera");
		cam = camObject.GetComponent<CameraHelper> ();
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag.Equals("Player")) {
			if(isInvertingDown){
				cam.isGravityInverted = true;
				Physics2D.gravity = new Vector2(0,negativeGravityValue);
				Destroy(gameObject,0.1f);
			}else{
				Physics2D.gravity = new Vector2(0,positiveGravityValue);
				cam.isGravityInverted = false;
				Destroy(gameObject,0.1f);
			}
		}
	}
}

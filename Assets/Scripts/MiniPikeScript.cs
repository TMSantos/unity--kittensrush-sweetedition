using UnityEngine;
using System.Collections;

public class MiniPikeScript : MonoBehaviour {

	private float Yposition;
	private float Xposition;
	private float yStartPosition;
	private float xStartPosition;

	public float speed;
	public float wavelength;
	public float waveHeight;
	private Vector3 newPosition;


	// Use this for initialization
	void Start () {
		yStartPosition = transform.position.y;
		xStartPosition = transform.position.x;
		Yposition = yStartPosition;
	}
	
	// Update is called once per frame
	void Update () {

		Yposition += speed;
		Xposition = (Mathf.Cos(Yposition / wavelength) * waveHeight) + xStartPosition;

		newPosition.y = Yposition;
		newPosition.x = Xposition;
		newPosition.z = 11;


		transform.position = newPosition;

		float angle = Mathf.Atan2(-newPosition.y*speed, -newPosition.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}

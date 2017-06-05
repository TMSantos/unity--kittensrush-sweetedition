using UnityEngine;
using System.Collections;

public class CircleMovement : MonoBehaviour {

	float time = 0;

	public float speed;
	public float width;
	public float heigth;

	private Vector3 newPos;

	void Start () {
		newPos = new Vector3 ();
		newPos = transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime*speed;

		float x = Mathf.Cos (time)*width;
		float y = Mathf.Sin (time)*heigth;

		newPos.Set (x,y,0);
		transform.position += newPos;
	}
}

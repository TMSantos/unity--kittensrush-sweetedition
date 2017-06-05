using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float speed;
	public Vector3 direction;

	public float distanceDeltaX;
	public float distanceDeltaY;

	public bool shouldInvertSpriteX;

	private Vector3 originalPosition;

	// Use this for initialization
	void Start () {
		originalPosition = transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += direction * speed;

		if (Vector3.Distance (originalPosition, transform.position) > distanceDeltaY) {
			direction = direction * -1;
			/*if(shouldInvertSpriteX){
				if(transform.eulerAngles.z == 180){					
					transform.rotation = Quaternion.AngleAxis (0, Vector3.forward);
				}
				
			}*/

		}

		if (Vector3.Distance (originalPosition, transform.position) < distanceDeltaX) {
			direction = direction * -1;
			if(shouldInvertSpriteX){
				if(direction.x == 1){
					transform.rotation = Quaternion.AngleAxis (180, Vector3.forward);
				}else{
					transform.rotation = Quaternion.AngleAxis (0, Vector3.forward);
				}

			}
		}
	}
}

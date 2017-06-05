using UnityEngine;
using System.Collections;

public class TriggerPlatform : MonoBehaviour {

	public GameObject mPlatform1;
	public GameObject mPlatform2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.name.Equals("Cat")){
			Destroy(mPlatform1);
			Destroy(mPlatform2);
		}
	}
}

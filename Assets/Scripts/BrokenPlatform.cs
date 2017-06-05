using UnityEngine;
using System.Collections;

public class BrokenPlatform : MonoBehaviour {

	private bool allNonKinematic = false;

	GameObject[] brokenPlatforms;

	void Start () {
		brokenPlatforms = GameObject.FindGameObjectsWithTag ("BrokenPlatform");
	}
	
	// Update is called once per frame
	void Update () {
		foreach(GameObject brokenPlat in brokenPlatforms){
			if(brokenPlat == null){
				return;
			}else if(allNonKinematic && brokenPlat.rigidbody2D.isKinematic){
				brokenPlat.rigidbody2D.isKinematic = false;
				Destroy(brokenPlat,3);
			}else if(!brokenPlat.rigidbody2D.isKinematic){
				allNonKinematic = true;
			}
		}
	}
}

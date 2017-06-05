using UnityEngine;
using System.Collections;

public class TequillaScript : MonoBehaviour {

	public GameObject catObject;
	private CatScript mCatScript;

	void Start () {
		mCatScript = catObject.GetComponent<CatScript> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider){

		Destroy (gameObject);

		if(collider.name.Equals("Cat")){
			Debug.Log("Cat is crazy");
			mCatScript.isCrazy = true;
		}
	}
}

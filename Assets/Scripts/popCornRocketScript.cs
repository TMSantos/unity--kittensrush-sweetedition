using UnityEngine;
using System.Collections;

public class popCornRocketScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider){
		 if(collider.name.Equals("Vegetable")){
			Destroy(collider.gameObject);
			Destroy(gameObject);
		}
		
	}
}

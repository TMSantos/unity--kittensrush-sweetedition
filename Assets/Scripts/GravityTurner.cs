using UnityEngine;
using System.Collections;

public class GravityTurner : MonoBehaviour {

	private GameObject camObject;
	private CameraHelper cam;

	private GameObject vegInactive1;
	private GameObject vegInactive2;
	private GameObject vegInactive3;
	private GameObject vegInactive4;
	private GameObject vegInactive5;
	private GameObject vegInactive6;

	private GameObject passagePlatform;

	// Use this for initialization
	void Start () {
		camObject = GameObject.FindGameObjectWithTag("MainCamera");
		cam = camObject.GetComponent<CameraHelper> ();

		if (gameObject.name.Equals ("GravityTurnerDown")) {
			vegInactive1 = GameObject.Find ("VegetableInactive1");
			vegInactive2 = GameObject.Find ("VegetableInactive2");
			vegInactive3 = GameObject.Find ("VegetableInactive3");
			vegInactive4 = GameObject.Find ("VegetableInactive4");
			vegInactive5 = GameObject.Find ("VegetableInactive5");
			vegInactive6 = GameObject.Find ("VegetableInactive6");				

			vegInactive1.SetActive (false);
			vegInactive2.SetActive (false);
			vegInactive3.SetActive (false);
			vegInactive4.SetActive (false);
			vegInactive5.SetActive (false);
			vegInactive6.SetActive (false);
			passagePlatform = GameObject.Find ("SpikePlatformPassage");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag.Equals("Player")) {
			if(gameObject.name.Equals("GravityTurnerDown")){
				cam.isGravityInverted = true;
				Physics2D.gravity = new Vector2(0,-40f);
				Destroy(gameObject,0.5f);
				vegInactive1.SetActive(true);
				vegInactive1.name = "Vegetable";
				vegInactive2.SetActive(true);
				vegInactive2.name = "Vegetable";
				vegInactive3.SetActive(true);
				vegInactive3.name = "Vegetable";
				vegInactive4.SetActive(true);
				vegInactive4.name = "Vegetable";
				vegInactive5.SetActive(true);
				vegInactive5.name = "Vegetable";
				vegInactive6.SetActive(true);
				vegInactive6.name = "Vegetable";
				Destroy(passagePlatform,2f);
			}else{
				Physics2D.gravity = new Vector2(0,4f);
				cam.isGravityInverted = false;

			}

		}
	}
}

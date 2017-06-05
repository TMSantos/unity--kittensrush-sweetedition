using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {

	private bool isGameOverActive = false;
	private CatScript catScript;
	private GameObject cat;

	public Image starOne;
	public Image starTwo;
	public Image starThree;
	public Image winLabel;
	public Image lostLabel;

	public int currentLevel;
	public int starOneKg;
	public int starTwoKg;
	public int starThreeKg;

	private Canvas canvas;

	// Use this for initialization
	void Start () {
		cat = GameObject.FindGameObjectWithTag ("Player");
		catScript = cat.GetComponent<CatScript> ();

		canvas = GetComponent<Canvas> ();
		canvas.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (!isGameOverActive) {
			if (catScript.winLevel) {
				activateGameOverScreen();
				callWinScreen(getNumberOfStars());
			} else if (catScript.lostLevel) {						
				activateGameOverScreen();
				callLostScreen();						
			}
		}
	}

	private int getNumberOfStars(){
		int currentKg = catScript.catKg;

		if (currentKg < starOneKg) return 0;
		else if (currentKg >= starOneKg && currentKg < starTwoKg) return 1;
		else if (currentKg >= starTwoKg && currentKg < starThreeKg) return 2;
		else if (currentKg >= starThreeKg) return 3;
		else return 0;
	}

	private void activateGameOverScreen(){
		isGameOverActive = true;
		canvas.enabled = true;
	}

	public void callWinScreen(int numberOfStars){
		winLabel.enabled = true;
		lostLabel.enabled = false;

		switch (numberOfStars) {
		case 0: 
			starOne.enabled = false;
			starTwo.enabled = false;
			starThree.enabled = false;
			break;
		case 1: 
			starOne.enabled = true;
			starTwo.enabled = false;
			starThree.enabled = false;
			break;
		case 2: 
			starOne.enabled = true;
			starTwo.enabled = true;
			starThree.enabled = false;
			break;
		case 3: 
			starOne.enabled = true;
			starTwo.enabled = true;
			starThree.enabled = true;
			break;
		}
	}

	private void callLostScreen(){
		winLabel.enabled = false;
		lostLabel.enabled = true;
		starOne.enabled = false;
		starTwo.enabled = false;
		starThree.enabled = false;
	}

	public void onReplayClick(){
		Application.LoadLevel ("Level" + currentLevel);
	}

	public void onNextLevelClick(){
		Application.LoadLevel ("Level" + (currentLevel+1));
	}
}

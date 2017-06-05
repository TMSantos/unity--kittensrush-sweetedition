using UnityEngine;
using System.Collections;

public class CatScript : MonoBehaviour {

	public bool winLevel = false;
	public bool lostLevel = false;
	public float catMaxSpeed;
	public float superFatDuration;
	public float stunDuration;
	public float crazyDuration;
	public Sprite catFat0, catFat1, catFat2, catFat3, catFat4, catFat5,catFat6,superFatMode;
	public float minSwipeDistY;
	public float minSwipeDistX;
	public float catVelocity;

	private bool isLeftPressed = false;
	private bool isRightPressed = false;
	private bool isUpPressed = false;
	private bool isDownPressed = false;

	private bool isSuperFat = false;
	private float superFatTimer = 0;
	private float crazyDurationTimer = 0;

	private float stunTriggerTimer;

	public bool canMove = true;
	private bool isStunned = false;
	private bool canBeStunned = true;
	private float stunTimer = 0;
	public bool isCrazy = false;

	public int catKg;

	public bool isCatInsideCotton = false;

	public bool isCatInPopCornMode;

	private CircleCollider2D catCollider;

	static float CAT_FAT_0 = 0.55f;
	static float CAT_FAT_1 = 0.6f;
	static float CAT_FAT_2 = 0.65f;
	static float CAT_FAT_3 = 0.7f;
	static float CAT_FAT_4 = 0.75f;
	static float CAT_FAT_5 = 0.9f;
	static float CAT_FAT_6 = 1.3f;
	static float SUPER_FAT = 4.8f;

	private Vector2 startPos;

	public Rigidbody2D popcornRocket;	
	private float popcornFastCastRate;

	private float currentVelocityX;
	private float currentVelocityY;

	void Start () {
		catKg = 0;
		popcornFastCastRate = 0;
		isCatInPopCornMode = false;
		catCollider = transform.GetComponent<CircleCollider2D>();

	}

	void FixedUpdate(){
		applyForces();
		capCatVelocity ();

	}
	// Update is called once per frame
	void Update () {
		if (lostLevel) rigidbody2D.isKinematic = true;

		if (isCatInPopCornMode) popCornMode ();

		if (Application.isMobilePlatform) getMobileInput ();
		else getKeyboardPlayerInput ();

		updateFatness ();
		updateLogic ();

	}

	void popCornMode(){
		rigidbody2D.isKinematic = true;
		popcornFastCastRate += Time.deltaTime;

		if (Input.GetKeyDown ("space")) {
			if(popcornFastCastRate > 0.3f){
				popcornFastCastRate = 0;
				Rigidbody2D bulletInstance = Instantiate (popcornRocket, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
				Destroy (bulletInstance.gameObject, 2);
				bulletInstance.velocity = Vector2.up * 10f;
			}
		}
	}

	void applyForces(){
		if (isLeftPressed) {
			if(isCatInPopCornMode && transform.position.x  > -4.5f)
				rigidbody2D.AddForce(Vector2.right * 10f * -1);
			else
				rigidbody2D.AddForce(Vector2.right * 50f * -1);
				
		}else if (isRightPressed) {
			if(isCatInPopCornMode && transform.position.x  < 4.5f) rigidbody2D.AddForce(Vector2.right * 10f * -1);
			else rigidbody2D.AddForce(Vector2.right * 50f);
		}else if(isUpPressed){
			rigidbody2D.AddForce(Vector2.up * 50f);
		}else if(isDownPressed){
			rigidbody2D.AddForce(Vector2.up * 50f * -1);
		}
	}

	void capCatVelocity(){
		currentVelocityX = rigidbody2D.velocity.x;
		currentVelocityY = rigidbody2D.velocity.y;	

		if(Mathf.Abs(currentVelocityY) > catMaxSpeed) {
			currentVelocityY = Mathf.Sign(rigidbody2D.velocity.y) * catMaxSpeed;
			currentVelocityX =  rigidbody2D.velocity.x;
					
			rigidbody2D.velocity = new Vector2(currentVelocityX,currentVelocityY);
		}

		if (Mathf.Abs(currentVelocityX) > catMaxSpeed) {
			currentVelocityX = Mathf.Sign(rigidbody2D.velocity.x) * catMaxSpeed;
			currentVelocityY =  rigidbody2D.velocity.y;		


		}

		rigidbody2D.velocity = new Vector2(currentVelocityX,currentVelocityY);
	}

	void updateFatness(){

		if (isSuperFat) {
			superFat();
		}else if (catKg < 2) {
			setCatFat0();
		}else if (catKg >= 2 && catKg < 6) {
			setCatFat1();
		}else if (catKg >= 6 && catKg < 10) {
			setCatFat2();
		}else if (catKg >= 10 && catKg < 14) {
			setCatFat3();
		}else if (catKg >= 14 && catKg < 18) {
			setCatFat4();
		}else if (catKg >= 18 && catKg < 22) {
			setCatFat5();
		}else if (catKg >= 22) {
			setCatFat6();
		}
	}

	void updateLogic(){
		if (isSuperFat) {
			superFatTimer += Time.deltaTime;
			if(superFatTimer > superFatDuration){
				superFatTimer = 0;
				isSuperFat = false;
			}
		}

		if (isCrazy) {
			crazyDurationTimer += Time.deltaTime;
			if(crazyDurationTimer > crazyDuration){
				crazyDurationTimer = 0;
				isCrazy = false;
			}
		}

		if (isStunned) {
			stunned ();
		}

		if (!canBeStunned) {
			canBeStunnedTimeOut();
		}
	}

	void getMobileInput(){
				if (Input.touchCount > 0 && Input.touchCount < 2) {
					Touch touch = Input.touches [0];

					switch (touch.phase) {
					case TouchPhase.Began:
							startPos = touch.position;
							break;
					case TouchPhase.Moved:
							float swipeDistVertical = (new Vector3 (0, touch.position.y, 0) - new Vector3 (0, startPos.y, 0)).magnitude;
							float swipeDistHorizontal = (new Vector3 (touch.position.x, 0, 0) - new Vector3 (startPos.x, 0, 0)).magnitude;

							float swipeValueY = Mathf.Sign (touch.position.y - startPos.y);
							float swipeValueX = Mathf.Sign (touch.position.x - startPos.x);

							if(swipeValueX > 0 && swipeValueY > 0){
								rigidbody2D.velocity = new Vector2(swipeDistHorizontal * catVelocity,swipeDistVertical * catVelocity);	
							}else if(swipeValueX > 0 && swipeValueY < 0){
								rigidbody2D.velocity = new Vector2(swipeDistHorizontal * catVelocity,swipeDistVertical * catVelocity * -1f);	
							}else if(swipeValueX < 0 && swipeValueY > 0){
								rigidbody2D.velocity = new Vector2(swipeDistHorizontal * catVelocity * -1f,swipeDistVertical * catVelocity);	
							}else if(swipeValueX < 0 && swipeValueY < 0){
								rigidbody2D.velocity = new Vector2(swipeDistHorizontal * catVelocity * -1f,swipeDistVertical * catVelocity * -1f);	
							}
							
							break;

					}

				} else if (Input.touchCount == 3) {
					Open ();
				} else {
					isLeftPressed = false;
					isUpPressed = false;
					isRightPressed = false;
					isDownPressed = false;
				}

	 }

	void getKeyboardPlayerInput(){

		if (isStunned || !canMove) {
			isLeftPressed = false;
			isRightPressed = false;
			isUpPressed = false;
			isDownPressed = false;
			return;
		}

		if (Input.GetKeyDown ("left")) {
			if(!isCrazy) isLeftPressed = true;
			else isUpPressed = true;
		}
		
		if (Input.GetKeyUp ("left")) {
			if(!isCrazy) isLeftPressed = false;
			else isUpPressed = false;
		}
		
		if (Input.GetKeyDown ("right")) {
			if(!isCrazy) isRightPressed = true;
			else isLeftPressed = true;
		}
		
		if (Input.GetKeyUp ("right")) {
			if(!isCrazy) isRightPressed = false;
			else isLeftPressed = false;
		}

		if (Input.GetKeyDown ("up")) {
			if(!isCrazy) isUpPressed = true;
			else isDownPressed = true;
		}
		
		if (Input.GetKeyUp ("up")) {
			if(!isCrazy) isUpPressed = false;
			else isDownPressed = false;
		}

		if (Input.GetKeyDown ("down")) {
			if(!isCrazy) isDownPressed = true;
			else isRightPressed = true;
		}
		
		if (Input.GetKeyUp ("down")) {
			if(!isCrazy) isDownPressed = false;
			else isRightPressed = false;
		}

		if (Input.GetKeyDown ("a")) {
			Open ();
		}
	}
		
	void OnCollisionEnter2D(Collision2D collision) {
		if (isSuperFat && !collision.gameObject.name.Equals("BorderRight") & !collision.gameObject.name.Equals("BorderLeft")) {
			collision.gameObject.rigidbody2D.isKinematic = false;
			collision.gameObject.rigidbody2D.gravityScale = -1;
			AddExplosionForce(collision.gameObject.rigidbody2D, 10 * 350, transform.position, 10);
			Destroy(collision.gameObject,0.5f);
			//Physics2D.IgnoreCollision(catCollider, collision.collider);

		}
	}

	public static void AddExplosionForce (Rigidbody2D body, float expForce, Vector3 expPosition, float expRadius)
	{
		var dir = (body.transform.position - expPosition);
		float calc = 1 - (dir.magnitude / expRadius);
		if (calc <= 0) {
			calc = 0;		
		}
		
		body.AddForce (dir.normalized * expForce * calc);
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.name.Equals ("Cake")) {
				Destroy (collider.gameObject);
				catKg += 2;
		} else if (collider.name.Equals ("Vegetable")) {
				Destroy (collider.gameObject);
				if (catKg > 0)
						catKg -= 2;
		} else if (collider.name.Equals ("SuperCake")) {
				Destroy (collider.gameObject);
				isSuperFat = true;
		} else if (collider.name.Equals ("SuperBadCake")) {
				Destroy (collider.gameObject);
				if (catKg > 10)
						catKg -= 10;
				else
						catKg = 0;
		} else if (collider.tag.Equals ("Obstacle") && (collider.GetType () == typeof(BoxCollider2D) || collider.GetType () == typeof(CircleCollider2D)) && !isStunned) {
				if (canBeStunned) {
						isStunned = true;
				}
		} else if (collider.name.Equals ("MexicanHotPlatform")) {
			lostLevel = true;
		}

	}

	void stunned(){		
		if (isStunned) {
			stunTimer += Time.deltaTime;
			canBeStunned = false;
			rigidbody2D.isKinematic = true;
			if(stunTimer > stunDuration){
				stunTimer = 0;
				isStunned = false;
				rigidbody2D.isKinematic = false;
				resetControls();
			}			
		}

	}

	void canBeStunnedTimeOut(){
		stunTriggerTimer += Time.deltaTime;

		if (stunTriggerTimer > 3) {
			stunTriggerTimer = 0;
			canBeStunned = true;
		}
	}

	void resetControls(){
		isLeftPressed = false;
		isRightPressed = false;
		isUpPressed = false;
		isDownPressed = false;

	}

	void setCatFat0(){
		gameObject.GetComponent<SpriteRenderer> ().sprite = catFat0;
		catCollider.radius = CAT_FAT_0;
	}

	void setCatFat1(){
		gameObject.GetComponent<SpriteRenderer> ().sprite = catFat1;
		catCollider.radius = CAT_FAT_1;
	}

	void setCatFat2(){
		gameObject.GetComponent<SpriteRenderer> ().sprite = catFat2;
		catCollider.radius = CAT_FAT_2;
	}

	void setCatFat3(){
		gameObject.GetComponent<SpriteRenderer> ().sprite = catFat3;
		catCollider.radius = CAT_FAT_3;
	}

	void setCatFat4(){
		gameObject.GetComponent<SpriteRenderer> ().sprite = catFat4;
		catCollider.radius = CAT_FAT_4;
	}

	void setCatFat5(){
		gameObject.GetComponent<SpriteRenderer> ().sprite = catFat5;
		catCollider.radius = CAT_FAT_5;
	}

	void setCatFat6(){
		gameObject.GetComponent<SpriteRenderer> ().sprite = catFat6;
		catCollider.radius = CAT_FAT_6;
	}

	void superFat(){
		gameObject.GetComponent<SpriteRenderer> ().sprite = superFatMode;
		catCollider.radius = SUPER_FAT;
	}

	//**************************************FOR DEVELOPER PORPUSES ONLY*************************/// 
	
	//private Rect windowRect = new Rect ((Screen.width)/2 - (Screen.width)/4, (Screen.height)/2 - (Screen.height)/4, (Screen.width)/2, (Screen.height)/2);
	private Rect windowRect = new Rect (100, 100, 200, 800);
	private bool show = false;
	
	void OnGUI () 
	{
		if(show)
			windowRect = GUI.Window (0, windowRect, DialogWindow, "KittenRush - SweetEdition");
	}
	
	
	void DialogWindow (int windowID)
	{
		float y = 20;
		GUI.Label(new Rect(5,y, windowRect.width, 20), "Select your level:");
		
		if(GUI.Button(new Rect(5,y+40, windowRect.width - 10, 40), "Level1"))
		{
			Application.LoadLevel ("Level1");
			show = false;
		}
		
		if(GUI.Button(new Rect(5,y+80, windowRect.width - 10, 40), "Level2"))
		{
			Application.LoadLevel ("Level2");
			show = false;
		}
		
		if(GUI.Button(new Rect(5,y+120, windowRect.width - 10, 40), "Level3"))
		{
			Application.LoadLevel ("Level3");
			show = false;
		}

		if(GUI.Button(new Rect(5,y+160, windowRect.width - 10, 40), "Level4"))
		{
			Application.LoadLevel ("Level4");
			show = false;
		}


		if(GUI.Button(new Rect(5,y+200, windowRect.width - 10, 40), "Level5"))
		{
			Application.LoadLevel ("Level5");
			show = false;
		}

		if(GUI.Button(new Rect(5,y+240, windowRect.width - 10, 40), "Level6"))
		{
			Application.LoadLevel ("Level6");
			show = false;
		}

		if(GUI.Button(new Rect(5,y+280, windowRect.width - 10, 40), "Level7"))
		{
			Application.LoadLevel ("Level7");
			show = false;
		}

		if(GUI.Button(new Rect(5,y+320, windowRect.width - 10, 40), "Level8"))
		{
			Application.LoadLevel ("Level8");
			show = false;
		}

		if(GUI.Button(new Rect(5,y+360, windowRect.width - 10, 40), "Level9"))
		{
			Application.LoadLevel ("Level9");
			show = false;
		}

		if(GUI.Button(new Rect(5,y+400, windowRect.width - 10, 40), "Level10"))
		{
			Application.LoadLevel ("Level10");
			show = false;
		}

		if(GUI.Button(new Rect(5,y+440, windowRect.width - 10, 40), "Level11"))
		{
			Application.LoadLevel ("Level11");
			show = false;
		}

		if(GUI.Button(new Rect(5,y+480, windowRect.width - 10, 40), "Level12"))
		{
			Application.LoadLevel ("Level12");
			show = false;
		}
	}
	
	public void Open()
	{
		show = true;
	}
}

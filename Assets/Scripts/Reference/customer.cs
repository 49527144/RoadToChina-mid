using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class customer : MonoBehaviour {

	public Score scoreCon;
	private SpriteMask mask;
	// use to identify customer
	private SpriteRenderer render;

	public Sprite bad_cus;

	float doubleClickStart = 0;

	public GameObject coin_prefab;

	void Awake(){
		mask = GetComponentInChildren<SpriteMask> ();
		render = GetComponent<SpriteRenderer> ();
	}

    // Use this for initialization
    void Start () {
		GameObject scoreControl = GameObject.FindWithTag ("score");
		if (scoreControl != null) {
			scoreCon = scoreControl.GetComponent<Score> ();
		}
		if (scoreControl == null) {
			Debug.Log ("Cannot find 'Score' script");
		}
		if (mask != null)
			mask.alphaCutoff = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (detectBadCustomer ()) {
			mask.alphaCutoff = 0.99f;
		} else {
			if (mask != null){
				if (mask.alphaCutoff < 1)
					mask.alphaCutoff = mask.alphaCutoff + 0.0005f;
				else
					mask.alphaCutoff = 0;
			}
		}
		//customer leave after certain time
		leave ();
	}


	public void served()
    {
		if (GiveFood.severed) {

			clearSpace ();
				
			GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(gameObject.tag);
			foreach (GameObject target in gameObjects)
			{
				GameObject.Destroy(target);
			}

			gameplay.seatflag = true;
			GiveFood.severed = false;

			//scoreCon.addScore (pay());


			Vector3 coinpos = new Vector3 (gameObject.transform.position.x + 1, gameObject.transform.position.y, gameObject.transform.position.x);

			GameObject coin = (GameObject)Instantiate (coin_prefab, coinpos, gameObject.transform.rotation);
			coin.GetComponent<Coin> ().CoinInit (pay());
		}
    }

	private void leave(){
		if (mask.alphaCutoff == 1) {
			GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(gameObject.tag);
			foreach (GameObject target in gameObjects)
			{
				GameObject.Destroy(target);
			}
			clearSpace ();
			scoreCon.addScore (-8);
		}
	}

	private void clearSpace(){
		if (gameObject.tag.Equals("0"))
		{
			gameplay.seat0 = "empty";
		}
		if (gameObject.tag.Equals("1"))
		{
			gameplay.seat1 = "empty";
		}
		if (gameObject.tag.Equals("2"))
		{
			gameplay.seat2 = "empty";
		}
	}

	private float pay(){
		if (detectBadCustomer()) {
			return 0;
		} else {
			return 10 + 5 * (1 - mask.alphaCutoff) / 1;
		}
	}

	private bool detectBadCustomer(){
		if (render.sprite == bad_cus) {
			return true;
		} else {
			return false;
		}
	}

	private void OnMouseDown(){
		if (detectBadCustomer()) {
			if ((Time.time - doubleClickStart) < 0.3f) {
				GameObject[] gameObjects = GameObject.FindGameObjectsWithTag (gameObject.tag);
				foreach (GameObject target in gameObjects) {
					GameObject.Destroy (target);
				}
				clearSpace ();
			} else {
				doubleClickStart = Time.time;
			}
		} else {
			if ((Time.time - doubleClickStart) < 0.3f) {
				GameObject[] gameObjects = GameObject.FindGameObjectsWithTag (gameObject.tag);
				foreach (GameObject target in gameObjects) {
					GameObject.Destroy (target);
				}
				clearSpace ();
				scoreCon.addScore (-5 * mask.alphaCutoff);
			} else {
				doubleClickStart = Time.time;
			}
		}
	}
}

using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{
	public Score score;
	public float coinValue;
	public int time; // time interval
	public float startTime;
	public bool isClick;
	public GameObject scoreObj;

	private float speed = 3f;


	public void CoinInit(float amount) {
		coinValue = amount;
		startTime = Time.time;
		time = 5;
		isClick = false;
		scoreObj = GameObject.FindGameObjectWithTag ("score");
		score = scoreObj.GetComponent<Score> ();

	}

	void Update() {
		if (!isClick) {
			if (Time.time - startTime > time) {
				Destroy (gameObject);
				// add move animation
			}
		} else {
			gameObject.transform.position = Vector2.Lerp(gameObject.transform.position, scoreObj.transform.position, speed * Time.deltaTime);
			if (Vector2.Distance(gameObject.transform.position,scoreObj.transform.position) < 0.05f) {
				score.addScore(coinValue);
				Destroy (gameObject);
			}
		}	
	}
		
	void OnMouseDown()
	{
		
		isClick = true;
	}
}
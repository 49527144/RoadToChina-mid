using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
		
	public Text scoreText;
	public static float score;

	// Use this for initialization
	void Start () {
		score = 0;
		updateScore ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addScore(float scoreVal) {
		score += scoreVal;
		updateScore ();
	}

	void updateScore() {
		string temp = score.ToString("F2");
		scoreText.text = "Score: $" + temp;

	}
}

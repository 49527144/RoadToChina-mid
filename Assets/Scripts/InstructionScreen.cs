using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionScreen : MonoBehaviour {
	public static GameObject Screen;

	void Awake()
	{
		Screen = gameObject;
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void StartGame(){
		Screen.SetActive(false);
		GameScreen.Screen.SetActive(true);
	}

}

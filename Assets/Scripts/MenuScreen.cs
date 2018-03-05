using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScreen : MonoBehaviour {
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

	public void Back(){
		Screen.SetActive(false);
		StartScreen.Screen.SetActive(true);
	}

}

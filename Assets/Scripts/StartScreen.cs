using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour {
    public static GameObject Screen;

    void Awake()
    {
        Screen = gameObject;
    }

	// Use this for initialization
	void Start () {
        GameScreen.Screen.SetActive(false);
		InstructionScreen.Screen.SetActive (false);
		MenuScreen.Screen.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ButtonOnClick() {
        Screen.SetActive(false);
		InstructionScreen.Screen.SetActive(true);
    }

	public void Menu() {
		Screen.SetActive(false);
		MenuScreen.Screen.SetActive(true);
	}

}

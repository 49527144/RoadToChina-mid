using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GiveFood : MonoBehaviour, IDropHandler
{

	public static bool severed;
	public static bool rightdish;

	public static bool righttakeout;

	public GameObject cus;

	public Score scoreCon;

	// Use this for initialization
	void Start () {

		GameObject scoreControl = GameObject.FindWithTag ("score");
		if (scoreControl != null) {
			scoreCon = scoreControl.GetComponent<Score> ();
		}

		severed = false;
		rightdish = false;
		righttakeout = false;
	}

	// Update is called once per frame
	void Update () {

	}

	public void OnDrop(PointerEventData data)
	{
		var originalObj = data.pointerDrag;
		if (originalObj == null)
			return;
		var drag = originalObj.GetComponent<draggable>();
		if (drag == null)
			return;

		//print (Input.mousePosition);
		if (Input.mousePosition.x < 250) {
			if (gameplay.dish0.GetComponent<PrefabType> ().prefabType == drag.getDish ()) {
				rightdish = true;
				cus = GameObject.FindGameObjectWithTag ("0");
			}
		}

		if (Input.mousePosition.x > 300 && Input.mousePosition.x < 400) {
			if (gameplay.dish1.GetComponent<PrefabType> ().prefabType == drag.getDish ()) {
				rightdish = true;
				cus = GameObject.FindGameObjectWithTag ("1");
			}
		}

		if (Input.mousePosition.x > 430 && Input.mousePosition.x < 510) {
			if (gameplay.dish2.GetComponent<PrefabType> ().prefabType == drag.getDish ()) {
				rightdish = true;
				cus = GameObject.FindGameObjectWithTag ("2");
			}
		}

		if (Input.mousePosition.x > 510) {
			if (gameplay.dish3.GetComponent<PrefabType> ().prefabType == drag.getDish ()) {
				righttakeout = true;
				cus = GameObject.FindGameObjectWithTag ("3");
			}
		}

		if (drag.getFinish () && rightdish) {
			drag.clear();
			severed = true;
			rightdish = false;
			cus.GetComponent<customer> ().served ();
		}

		if (drag.getFinish () && righttakeout) {
			drag.clear();
			righttakeout = false;
			Destroy (cus);
			gameplay.takeoutflag = true;
			gameplay.takeOut = "empty";
			scoreCon.addScore (10);
		}
	}
}

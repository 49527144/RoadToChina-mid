using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gameplay : MonoBehaviour {

	public static string seat0 = "empty";
	public static string seat1 = "empty";
	public static string seat2 = "empty";
	public static string takeOut = "empty";
	public GameObject[] dishPrefabs;
    public GameObject[] customerPrefabs;
    public float y=2;

	public static bool seatflag = true;
	public static bool takeoutflag = true;

    public static GameObject dish0;
    public static GameObject dish1;
    public static GameObject dish2;
	public static GameObject dish3;

    public static GameObject customer0;
    public static GameObject customer1;
    public static GameObject customer2;

	private int num_customer;

    // Use this for initialization
    void Start () {
		num_customer = 1000;
		if (seatflag){
			InvokeRepeating ("MakeCustomers", 0, 3);
		}
		if (takeoutflag) {
			InvokeRepeating ("MakeTakeout", 0, 5);
		}
	}

	void MakeCustomers() {
		if (num_customer > 0) {
			if (seat0 == "empty") {
				int dishPreIndex = Random.Range (0, dishPrefabs.Length);
				int cusPreIndex = Random.Range (0, customerPrefabs.Length);
				dish0 = dishPrefabs [dishPreIndex];
				customer0 = customerPrefabs [cusPreIndex];
				dish0.tag = "0";
				customer0.tag = "0";
				Instantiate (customer0, new Vector2 (-3, y), customer0.transform.rotation);
				Instantiate (dish0, new Vector2 (-2.2f, y + 0.5f), dish0.transform.rotation);
				seat0 = "occupied";
			} else if (seat1 == "empty") {
				int dishPreIndex = Random.Range (0, dishPrefabs.Length);
				int cusPreIndex = Random.Range (0, customerPrefabs.Length);
				dish1 = dishPrefabs [dishPreIndex];
				customer1 = customerPrefabs [cusPreIndex];
				dish1.tag = "1";
				customer1.tag = "1";
				Instantiate (customer1, new Vector2 (0, y), customer1.transform.rotation);
				Instantiate (dish1, new Vector2 (0.8f, y + 0.5f), dish1.transform.rotation);
				seat1 = "occupied";
			} else if (seat2 == "empty") {
				int dishPreIndex = Random.Range (0, dishPrefabs.Length);
				int cusPreIndex = Random.Range (0, customerPrefabs.Length);
				dish2 = dishPrefabs [dishPreIndex];
				customer2 = customerPrefabs [cusPreIndex];
				dish2.tag = "2";
				customer2.tag = "2";
				Instantiate (customer2, new Vector2 (3, y), customer2.transform.rotation);
				Instantiate (dish2, new Vector2 (3.7f, y + 0.5f), dish2.transform.rotation);
				seat2 = "occupied";
			}
		} else {
			CancelInvoke ("MakeCustomers");
		}
		// cunstomer number count down
		num_customer--;
	}

	void MakeTakeout() {
		if (takeOut == "empty") {
			int dishPreIndex = Random.Range (0, dishPrefabs.Length);
			dish3 = dishPrefabs [dishPreIndex];
			dish3.tag = "3";
			dish3.GetComponent<Transform> ().localScale = new Vector3 (1.5f, 1.5f, 1);
			Instantiate (dish3, new Vector2 (5.1f, y), dish3.transform.rotation);
			takeOut = "occupied";
		}
	}


	void NoSeat() {
		if (seat0 == "occupied" && seat1 == "occupied" && seat2 == "occupied") {
			seatflag = false;
		}
	}

	void NoTake() {
		if (takeOut == "occupied") {
			takeoutflag = false;
		}
	}
}

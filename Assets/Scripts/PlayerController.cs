using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private HouseManager manager;

	public int maxSpeed = 3;

	void Start () {
		manager = GameObject.FindGameObjectWithTag ("GameController").GetComponent<HouseManager> ();

	}

	void Update () {
		//Movement
		if (!manager.isControlingHouse ()) {

		}

		//Taking Damage and such, collision boxes.
	}
}

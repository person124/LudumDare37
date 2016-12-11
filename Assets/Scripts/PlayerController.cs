using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private HouseManager manager;
	private Rigidbody2D rigid;

	public float speed = 3;

	void Start () {
		manager = GameObject.FindGameObjectWithTag ("GameController").GetComponent<HouseManager> ();
		rigid = GetComponent<Rigidbody2D> ();
	}

	void Update () {
		//Movement
		if (!manager.isControlingHouse ()) {
			//Testing collison
			//NOT FINAL MOVEMENT
			float x = 0, y = 0;
			if (Input.GetKey (KeyCode.W))
				y = speed;
			else if (Input.GetKey (KeyCode.S))
				y = -speed;

			if (Input.GetKey (KeyCode.D))
				x = speed;
			else if (Input.GetKey (KeyCode.A))
				x = -speed;

			rigid.velocity = new Vector2 (x, y);

			//MAKE PLAYER LOOK TORWARDS MOUSE
		}

		//Taking Damage and such, collision boxes.
	}
}

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private HouseManager manager;
	private RoomHandler room;
	private Rigidbody2D rigid;

	public float speed = 3;

	void Start () {
		manager = GameObject.FindGameObjectWithTag ("GameController").GetComponent<HouseManager> ();
		manager.player = this;
		room = GameObject.FindGameObjectWithTag ("Room").GetComponent<RoomHandler> ();
		rigid = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {
		//Movement
		if (!manager.isControllingHouse ()) {
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

			//Making Player Looking at Mouse
			Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
			float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		} else {
			rigid.position = room.getPlayerPosition ();
			rigid.rotation = 90f;
		}

		//Taking Damage and such, collision boxes.
	}
}

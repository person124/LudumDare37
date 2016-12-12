using UnityEngine;
using System.Collections;

public class RoomHandler : MonoBehaviour {

	private HouseManager manager;

	private Vector3 playerStart;
	private Vector3 cameraLocation;

	private PolygonCollider2D tabZone;

	//Use ArrayList for mook list

	void Start () {
		manager = GameObject.FindGameObjectWithTag ("GameController").GetComponent<HouseManager> ();
		manager.room = this;

		playerStart = transform.position;
		playerStart.y += 3.75f;

		cameraLocation = transform.position;
		cameraLocation.z = -10;

		tabZone = GetComponent<PolygonCollider2D> ();
	}

	void Update () {
		
	}

	public Vector3 getEnemySpawnLocation () {
		return getRange (-3, 3, -4, -3);
	}

	private Vector3 getRange(float xMin, float xMax, float yMin, float yMax) {
		float xLoc = Random.Range (0, Mathf.Abs (xMin - xMax)) + xMin + transform.position.x;
		float yLoc = Random.Range (0, Mathf.Abs (yMin - yMax)) + yMin + transform.position.y;

		return new Vector3 (xLoc, yLoc, 0.0f);
	}

	public bool insideTabZone (PlayerController player) {
		return tabZone.IsTouching (player.GetComponent<Collider2D> ());
	}

	public Vector3 getPlayerPosition () {
		return playerStart;
	}

	public Vector3 getCameraPosition () {
		return cameraLocation;
	}
}

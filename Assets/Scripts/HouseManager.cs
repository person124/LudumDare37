﻿using UnityEngine;
using System.Collections;

public class HouseManager : MonoBehaviour {

	//Global Variables
	public int MAX_HEALTH = 100;
	public int MAX_PLAYER_HEALTH = 100;

	public enum MobTypes {melee, gun, mad};
	public float[] MOB_SPEEDS = new float[3] {1, 1, 1};
	public const int MOB_COUNT = 3;
	public int MAX_MELEE = 10, MAX_GUN = 2, MAX_MAD = 1;

	public Camera MAIN_CAMERA;
	public PlayerController player;
	public RoomHandler room;

	//Private Members such as health and counts
	private int health, playerHealth;
	private int [] mobCounts;
	private bool isViewingHouse, isChanging = false;

	void Start () {
		health = MAX_HEALTH;
		playerHealth = MAX_PLAYER_HEALTH;

		mobCounts = new int [MOB_COUNT];
		for (int i = 0; i < MOB_COUNT; i++)
			mobCounts [i] = 0;

		isViewingHouse = false;

		MAIN_CAMERA = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ();
	}

	void Update () {
		//TO DO, PUT SOMETHING HERE RELATED TO PLAYER HEALTH

		if (!isChanging) {
			if (Input.GetKey (KeyCode.Tab)) {
				if (isViewingHouse)
					switchControl ();
				else if (room.insideTabZone (player))
					switchControl ();
			}
		} else if (!Input.GetKey (KeyCode.Tab))
			isChanging = false;
	}

	public bool isControllingHouse() {
		return isViewingHouse;
	}

	public void switchControl () {
		//TO DO
		//SWITCH CAMERA VIEW
		isViewingHouse = !isViewingHouse;
		isChanging = true;

		if (isViewingHouse) {
			MAIN_CAMERA.GetComponent<Transform> ().position = new Vector3 (100, 100, -10);
		} else {
			MAIN_CAMERA.GetComponent<Transform> ().position = room.getCameraPosition ();
		}
	}

	public void damagePlayer (int amount) {
		playerHealth -= amount;
		checkPlayerHealth ();
	}

	public void setPlayerHealth (int num) {
		playerHealth = num;
		checkPlayerHealth ();
	}

	public int getPlayerHealth () {
		return playerHealth;
	}

	public void damageHouse (int amount) {
		health -= amount;
		checkHealth ();
	}

	public void setHouseHealth (int num) {
		health = num;
		checkHealth ();
	}

	public int getHealth() {
		return health;
	}

	public void checkPlayerHealth () {
		if (playerHealth < 0)
			playerHealth = 0;
		else if (playerHealth > MAX_PLAYER_HEALTH)
			playerHealth = MAX_PLAYER_HEALTH;
	}

	public void checkHealth () {
		if (health < 0)
			health = 0;
		else if (health > MAX_HEALTH)
			health = MAX_HEALTH;
	}

	public bool getRandomBool () {
		return Random.value >= 0.5f;
	}
}

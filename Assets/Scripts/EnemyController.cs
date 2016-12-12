using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public Sprite[] sprites;
	public HouseManager.MobTypes type;

	private HouseManager manager;
	private int iType;

	void Start () {
		manager = GameObject.FindGameObjectWithTag ("GameController").GetComponent<HouseManager> ();

		iType = (int) type;
		GetComponent<SpriteRenderer> ().sprite = sprites [iType];

		//transform.position = manager.room.getEnemySpawnLocation ();
	}

	void Update () {
		if (type != HouseManager.MobTypes.gun)
			transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), manager.player.transform.position, manager.MOB_SPEEDS[iType] * Time.deltaTime);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public Enemy[] EnemyTypes;

	public int DifficultyLevel = 1;

	private List<GameObject> _enemies;

	// Use this for initialization
	void Start () {
		SpawnEnemies();
	}

	private void SpawnEnemies() {
		// todo: clear all
		_enemies = new List<GameObject>();

		var numA = DifficultyLevel * 10;
		for(var i = 0; i < numA; i++) {
			var created = Object.Instantiate(EnemyTypes[0], Vector3.zero, Quaternion.identity);
			created.transform.parent = transform;
			created.name = "Enemy "+i;
			created.transform.localPosition = new Vector3((-numA/2 + i) * 4.0f, 0, 0);
			created.transform.rotation = Quaternion.Euler(0, 180.0f, 0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

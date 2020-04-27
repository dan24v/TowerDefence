using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	[SerializeField]
	private float spawnDelay;

	public Transform tank, bmp;


	void Start () {
		InvokeRepeating("SpawnEnemy", 0, spawnDelay);
	}

	private void SpawnEnemy(){
		int rnd = Random.Range(0, 4);
		if(rnd == 0)Instantiate(bmp, transform.position, transform.rotation);
			else Instantiate(tank, transform.position, transform.rotation);
	}
	
}

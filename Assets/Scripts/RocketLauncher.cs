using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class RocketLauncher : Gun {

	[SerializeField]
	private Transform rocket;

	const float rocketSpawnOffset = 1;
	
	public override void Shoot(){
		Vector3 pos = new Vector3(transform.position.x, 
		transform.position.y + rocketSpawnOffset, 
		transform.position.z);

		Instantiate(rocket, pos, transform.rotation);
	}

	
}

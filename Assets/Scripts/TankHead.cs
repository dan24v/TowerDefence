using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class TankHead : Gun {

	[SerializeField]
	private Transform tankMissile;

	public override void Shoot(){
		Vector3 pos = new Vector3(transform.position.x, 
		transform.position.y, 
		transform.position.z);

		Transform rocket = Instantiate(tankMissile, pos, transform.rotation);
		rocket.Translate(0, 0, MISSILE_OFFSET);
	}

}

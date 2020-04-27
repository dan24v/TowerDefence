using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Laser : Gun {

	[SerializeField]
	private Transform laserBullets;

	[SerializeField]
	private int ammo;

	private int tmpAmmo;

	[SerializeField]
	private float reloadingTime;

	private bool reloading;

	const float OFFSET_Z = 2;


	void Awake() {
		tmpAmmo = ammo;
	}

	void Reload() {
		tmpAmmo = ammo;
		reloading = false;
	}


	public override void Shoot(){
		if(tmpAmmo > 0 && !reloading){
			Vector3 pos = new Vector3(transform.position.x, 
			transform.position.y, 
			transform.position.z);

			Transform bullets = Instantiate(laserBullets, pos, transform.rotation);
			bullets.Translate(0, 0, MISSILE_OFFSET);
			tmpAmmo--;
		}
		else
			if(!reloading){
				reloading = true;
				InvokeRepeating("Reload", reloadingTime, 0);
			}

	}
	
}

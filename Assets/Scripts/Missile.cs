using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

	private bool ready;

	[SerializeField]
	private float speed;

	[SerializeField]
	private float lifeTime;

	[SerializeField]
	private bool spawnPatricle;

	[SerializeField]
	private Transform explosionFx;

	private bool readyToExplode;
	
	[SerializeField]
	private int damage = 1;

	void Awake() {
		
	}

	private void OnTriggerEnter(Collider other){
		if(readyToExplode){
			if(other.gameObject.tag == "enemy" || other.gameObject.tag == "gun")
				other.gameObject.SendMessage("Hit", damage);

			if(spawnPatricle) Instantiate(explosionFx, transform.position, Quaternion.identity);

			Destroy(this.gameObject);
		} else readyToExplode = true;

	}



	
	void Update () {
		transform.Translate(0, 0, speed * Time.deltaTime);

		if(lifeTime < 0){
			if(spawnPatricle) Instantiate(explosionFx, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}

		lifeTime -= Time.deltaTime;
	}
}

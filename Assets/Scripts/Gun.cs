using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour {


	public abstract void Shoot();

	protected GameObject target;

	[SerializeField]
	private float shotDelay;

	[SerializeField]
	private bool isEnemy = false;
	
	[SerializeField]
	protected int health;

	[SerializeField]
	private float maxTargetRange;

	protected const float MISSILE_OFFSET = 1.3f;

	void Start() {
		InvokeRepeating("ShootIfHasTarget", shotDelay, shotDelay);
	}

	public void Hit(int damage){
		health -= damage;

		if(health <= 0){
			Destroy(gameObject);
		}
	}

	private void SearchForTarget(){
		string enemyTag = "enemy";
		if(isEnemy) enemyTag = "gun";

		GameObject[] enemys = GameObject.FindGameObjectsWithTag(enemyTag);
		foreach(GameObject enemy in enemys)
			if(Vector3.Distance(transform.position, enemy.transform.position) < maxTargetRange){
				target = enemy;
			}
	}

	private void FaceToTarget(){
		if(Vector3.Distance(transform.position, target.transform.position) < maxTargetRange){
			transform.LookAt(target.transform);
			transform.rotation = new Quaternion(0, transform.rotation .y,
			0, transform.rotation .w);
		} else SearchForTarget();
	}

	void ShootIfHasTarget(){
		if(target != null) Shoot();
	}
	
	void FixedUpdate () {
		if(target == null){
			SearchForTarget();

		} else{
			FaceToTarget();

		}
	}
}

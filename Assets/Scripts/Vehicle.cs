using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Vehicle : MonoBehaviour {
	private GameObject[] wayPoints;

	[SerializeField]
	private int health;
	private int currentWpIndex;
	[SerializeField]
	private int cost;

	private const int defaultHealth = 10;

	protected void Hit(int force){
		health -= force;
		if(health <= 0){
			MoneyManager.current.AddMoney(cost);
			Destroy(transform.gameObject);
		}

		
	}

	protected void Move(float moveSpeed){
		float localSpeed =  moveSpeed * Time.deltaTime; 

		Transform wayPoint = wayPoints[currentWpIndex].transform;

        if (Vector3.Distance(transform.position, wayPoint.position) > 0)
        {
		   Quaternion targetRotation = Quaternion.LookRotation (wayPoint.position - transform.position);

		   if(transform.rotation == targetRotation) 
		   		transform.position = Vector3.MoveTowards(transform.position, wayPoint.position, localSpeed);
			else
		   		transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, localSpeed * 2);

        } else{
			if(currentWpIndex > 0) currentWpIndex--;
				else Destroy(gameObject);
		}
	}
	protected void Init () {

		wayPoints = GameObject.FindGameObjectsWithTag("waypoint").OrderByDescending(go => go.name).ToArray();
		currentWpIndex = wayPoints.Length-1;
		if(health <= 0){
			health = defaultHealth;
		}
	}
	
}

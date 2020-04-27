using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBuilder : MonoBehaviour {

	public static WeaponBuilder current;

	[SerializeField]
	private Transform rocketLauncher, laser;

	[SerializeField]
	private int rocketCost, laserCost;

	void Awake () {
		current = this;
	}

	public void BuildWeaponOnMap(RaycastHit hit, int mouseBtn, Vector3 pos){
		if(hit.transform.gameObject.tag == "ground"){
			switch(mouseBtn){
				case(0):
					if(MoneyManager.current.CanSpend(rocketCost)){
						Instantiate(rocketLauncher, pos, Quaternion.identity);
						MoneyManager.current.ReduceMoney(rocketCost);
					}
					break;
				case(1):
					if(MoneyManager.current.CanSpend(laserCost)){
						Instantiate(laser, pos, Quaternion.identity);
						MoneyManager.current.ReduceMoney(laserCost);
					}
					break;
			}
		}
		else if(hit.transform.gameObject.tag == "gun" && mouseBtn == 2){
			MoneyManager.current.AddMoney(5);
			Destroy(hit.transform.gameObject);
		}
		
	}
	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllsManager : MonoBehaviour {

	[SerializeField]
	private Transform cursorObject;

	const float SPAWN_YPOS = 1;

	void Start () {
		cursorObject = Instantiate(cursorObject, Vector3.zero, Quaternion.identity);
	}
	

	void Update () {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit)){

				float posX = Mathf.Floor(Mathf.Ceil(hit.point.x) / 2) * 2;
				float posZ = Mathf.Floor(Mathf.Ceil(hit.point.z) / 2) * 2;
				
				if(Input.GetMouseButtonDown(0)){
					WeaponBuilder.current.BuildWeaponOnMap(hit, 0, new Vector3(posX, SPAWN_YPOS, posZ));
				}
				else if(Input.GetMouseButtonDown(1)){
					WeaponBuilder.current.BuildWeaponOnMap(hit, 1, new Vector3(posX, SPAWN_YPOS, posZ));
				}
				else if(Input.GetMouseButtonDown(2)){
					WeaponBuilder.current.BuildWeaponOnMap(hit, 2, Vector3.zero);
				}


				cursorObject.position = new Vector3(posX, 1, posZ);

			}
	}
}

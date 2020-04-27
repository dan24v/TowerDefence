using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bmp : Vehicle {


	[SerializeField]
	private float speed;
	void Start () {
		base.Init();
	}

	void Update () {
		base.Move(speed);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	public float xInput;
	public float yInput;
	public Ishift bo;

	void Start () {
		bo = gameObject.GetComponent<Ishift>();
	}
	
	void Update () {
		xInput = Input.GetAxis("Horizontal");
		yInput = Input.GetAxis("Vertical");
		bo.Translate(xInput * Time.deltaTime, yInput * Time.deltaTime);

		if (Input.GetButtonDown("Fire1")) {
			Debug.Log("k1");
			var shooting = GetComponent<Shooting>();
			if (shooting != null) {
				shooting.trigger();
				Debug.Log("k2");
			}
		}
	}
}

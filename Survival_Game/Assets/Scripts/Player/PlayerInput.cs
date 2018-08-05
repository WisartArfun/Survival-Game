using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	public float xInput;
	public float yInput;
	public Ishift bo;

	Shooting shooting;

	void Start () {
		bo = gameObject.GetComponent<Ishift>();
		shooting = GetComponent<Shooting>();
	}
	
	void Update () {
		xInput = Input.GetAxis("Horizontal");
		yInput = Input.GetAxis("Vertical");
		bo.Translate(xInput * Time.deltaTime, yInput * Time.deltaTime);

		if (Input.GetButton("Fire1")) {
			shooting = GetComponent<Shooting>();
			if (shooting != null && shooting.weapon.shot_current_cooldown <= 0) {
				shooting.weapon.shot_current_cooldown = shooting.weapon.shot_cooldown;
				shooting.trigger();
			}
		}

		if (shooting.weapon.shot_current_cooldown > 0) {
			shooting.weapon.shot_current_cooldown -= Time.deltaTime;
		}
	}
}

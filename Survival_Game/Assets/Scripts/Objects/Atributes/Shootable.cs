using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootable : MonoBehaviour {

	public bool shootable;
	public bool damageable;

	public void hit(Bullet_Information bullet_information) {
		if (damageable) {
			Debug.Log(bullet_information.damage);
			GetComponent<Health>().change_health(bullet_information.damage);
		}
		if (shootable) { 
			Destroy(bullet_information.gameObject);
		}
	}
}

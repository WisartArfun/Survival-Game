using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

	public Weapon weapon; 
	
	public void trigger() {
		if (weapon != null) {
			var bullet = Instantiate(weapon.bullet, transform.position, transform.rotation) as GameObject;
			bullet.GetComponent<Bullet_Information>().Initialize(transform);
		}
	}

}

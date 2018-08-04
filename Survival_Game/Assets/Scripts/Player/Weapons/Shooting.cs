using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

	public Weapon weapon;
	
	public void trigger() {
		if (weapon != null) {
			// Quaternion rotation = transform.rotation;
			// rotation.z += 90;
			var bullet = Instantiate(weapon.bullet, transform.position, transform.rotation) as GameObject;
			Debug.Log(bullet);
			bullet.GetComponent<Bullet_Information>().Initialize(transform);
			Debug.Log(bullet.GetComponent<Bullet_Information>() != null);
		}
	}

}

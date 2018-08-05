using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Information : MonoBehaviour {
	
	public string aName;
	public float damage;
	public float speed;
	public float range;
	public Transform owner;

	float currentDistance = 0;
	Vector2 displacement;

	Vector3 direction;
	Rigidbody2D rb;

	public void Initialize(Transform _owner) {
		owner = _owner;
		var owner_weapon = owner.GetComponent<Shooting>().weapon;
		damage = owner_weapon.shot_damage;
		speed = owner_weapon.shot_speed;
		range = owner_weapon.shot_range;
	}

	void Start() {
		// direction = Input.mousePosition;
		// direction.z = 0;
		// direction = Camera.main.ScreenToWorldPoint(direction);
		// direction = direction - transform.position;
		// direction.Normalize();

		rb = GetComponent<Rigidbody2D>();
		// displacement = direction * speed;
		rb.AddForce(transform.up * speed);
	}

	void Update() {
		currentDistance += speed * Time.deltaTime;

		if (currentDistance >= range) {
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		// var ho = col.gameObject.GetComponent<HitableObject>();
		// if (ho != null) {
		// 	Destroy(gameObject);
		// }
		if (col.gameObject.transform == owner) {
			return;
		}
		
		var shootable = col.gameObject.GetComponent<Shootable>();
		if (shootable != null) {
			shootable.hit(this);
		}
	}
}

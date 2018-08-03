using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BaseObject, Ishift, Ihealth {

	public MovementData movementData;
	public HealthData   healthData;
	public void changeHealth (float damage) {
		healthData.currentHealth -= damage;
		if (healthData.currentHealth <= 0) {
			Destroy(gameObject);
		}
	}

	public void Translate (float x, float y) {
		movementData.force.x = x * movementData.speed;
		movementData.force.y = y * movementData.speed;
		movementData.force.z = 0;
		movementData.rb.AddForce(movementData.force);
		// Vector2 new_pos = new Vector2(transform.position.x + movementData.force.x, transform.position.y + movementData.force.y);
		// movementData.rb.MovePosition(new_pos);
	}

	// Use this for initialization
	public override void Start () {
		base.Start();
		movementData    = gameObject.GetComponent<MovementData>();
		healthData		= gameObject.GetComponent<HealthData>  ();
		movementData.rb = gameObject.GetComponent<Rigidbody2D> ();
	}

	void OnCollisionEnter2D (Collision2D col) {
		Debug.Log("hiiii");
		changeHealth(2);
	}
}

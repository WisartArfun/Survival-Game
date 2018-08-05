using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BaseObject, Ishift { //, Ihealth {

	public MovementData movementData;
	// public HealthData   healthData;
	public Health health;

	Camera cam;
	Transform my;
	Rigidbody2D body;

	public override void Start () {
		base.Start();
		movementData    = gameObject.GetComponent<MovementData>();
		// healthData		= gameObject.GetComponent<HealthData>  ();
		health = GetComponent<Health>();
		movementData.rb = gameObject.GetComponent<Rigidbody2D> ();
	}

	void Awake() {
		cam = Camera.main;
		my = GetComponent <Transform> ();
		body = GetComponent <Rigidbody2D> ();
	}

	public override void Update() {
		base.Update();
		// Distance from camera to object.  We need this to get the proper calculation.
		float camDis = cam.transform.position.y - my.position.y;
	
		// Get the mouse position in world space. Using camDis for the Z axis.
		Vector3 mouse = cam.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, camDis));
	
		float AngleRad = Mathf.Atan2 (mouse.y - my.position.y, mouse.x - my.position.x);
		float angle = (180 / Mathf.PI) * AngleRad;
	
		body.rotation = angle - 90;
	}

	void OnCollisionEnter2D (Collision2D col) {
		health.change_health(2);
	}

	// public void changeHealth (float damage) {
	// 	healthData.currentHealth -= damage;
	// 	if (healthData.currentHealth <= 0) {
	// 		Destroy(gameObject);
	// 	}
	// }

	public void Translate (float x, float y) {
		movementData.force.x = x * movementData.speed;
		movementData.force.y = y * movementData.speed;
		movementData.force.z = 0;
		// movementData.rb.AddForce(movementData.force);
		Vector2 new_pos = new Vector2(transform.position.x + movementData.force.x, transform.position.y + movementData.force.y);
		// movementData.rb.MovePosition(new_pos);
		transform.position += movementData.force;
	}
}

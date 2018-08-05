using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	public float xInput;
	public float yInput;
	public Ishift bo;

	Shooting shooting;

	public Controler_Keyboard controler_keyboard;


	Camera cam;
	Transform my;
	Rigidbody2D body;

	void Awake() {
		cam = Camera.main;
		my = GetComponent <Transform> ();
		body = GetComponent <Rigidbody2D> ();
	}

	void Start () {
		bo = gameObject.GetComponent<Ishift>();
		shooting = GetComponent<Shooting>();
		// controler_keyboard = GetComponent<Controler_Keyboard>();
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

		if (controler_keyboard.m_State == Controler_Keyboard.eInputState.MouseKeyboard) {
			float camDis = cam.transform.position.y - my.position.y;
			Vector3 mouse = cam.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, camDis));
		
			float AngleRad = Mathf.Atan2 (mouse.y - my.position.y, mouse.x - my.position.x);
			float angle = (180 / Mathf.PI) * AngleRad;
		
			body.rotation = angle - 90;
		} else {
			float x = Input.GetAxis("ShootX");
			float y = Input.GetAxis("ShootY");
			if (x != 0.0f || y != 0.0f) {
				body.rotation = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
			}
		}
	}
}

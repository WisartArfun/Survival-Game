using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	public float xInput;
	public float yInput;
	public Ishift bo;

	// Use this for initialization
	void Start () {
		bo = gameObject.GetComponent<Ishift>();
	}
	
	// Update is called once per frame
	void Update () {
		xInput = Input.GetAxis("Horizontal");
		yInput = Input.GetAxis("Vertical");
		bo.Translate(xInput, yInput);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObject : MonoBehaviour {
	public Sprite sprite;
	public string myName; 
	
	// Use this for initialization
	public virtual void Start () {
		if (!gameObject.GetComponent<SpriteRenderer>()) 
		{
			gameObject.AddComponent<SpriteRenderer>();
		}
		gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
	}
	
	// Update is called once per frame
	public virtual void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Weapon : ScriptableObject {

	public string aName;
	public GameObject bullet;
	public float shot_speed;
	public float shot_range;
	public float shot_damage;

}

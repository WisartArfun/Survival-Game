using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IHealth {

	public HealthData healthData;

	void Start() {
		healthData = GetComponent<HealthData>();
	}

	public void change_health(float amount) {
		healthData.currentHealth -= amount;
		if (healthData.currentHealth <= 0) {
			Destroy(gameObject);
		}
	}
}

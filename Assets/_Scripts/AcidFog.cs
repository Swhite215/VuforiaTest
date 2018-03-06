using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidFog : MonoBehaviour {
	
	private GameObject[] enemies;
	public float acidDamage = 1;

	public float rechargeTime = 0.5f;
	private float lastGeneratedTime;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, 4.0f);
	}
	
	// Update is called once per frame
	void Update () {
		enemies = GameObject.FindGameObjectsWithTag ("Monster");
		Debug.Log (enemies.Length);
		if (enemies.Length != 0) {
			for (var i = 0; i < enemies.Length; i++) {
				if (Time.time > lastGeneratedTime + rechargeTime) {
					Health health = enemies[i].GetComponentInChildren<Health> ();
					health.TakeDamage (acidDamage * Time.deltaTime);
					lastGeneratedTime = Time.time;
				}
			}
		}
	}
		
}

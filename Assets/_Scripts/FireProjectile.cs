using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour {

	public GameObject shot;
	private GameObject[] enemies;

	private float range = 3f;

	private GameObject shootingTarget;
	private GameObject currentTarget;
	public float smallestDistance = 3f;

	public float rechargeTime = 3.0f;
	private float lastGeneratedTime;


	/*
	public Transform shotSpawn;
	public float startWait;
	public float waveWait;
	public float spawnWait;

	public int shotCount;

	// Use this for initialization

	void Start () {
		StartCoroutine(SpawnShots());
	}
		
	IEnumerator SpawnShots () 
	{
		yield return new WaitForSeconds (startWait);
		while(true) 
		{
			for (var i = 0; i < shotCount; i++) 
			{
				Object.Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

		}

	}
    */

	void Update() {
		//Get List of All Enemies
		//Find Enemy Closest to Objective
		//While that enemies health is greater than 0, spawn arrows and set as target
		//Repeat until enemies are gone

		enemies = GameObject.FindGameObjectsWithTag ("Monster");
		if (enemies.Length != 0) {
			//Check each enemies transform.position
			currentTarget = FindClosestMonster(enemies);
			if (Time.time > lastGeneratedTime + rechargeTime) {
				fireArrow (currentTarget);
				lastGeneratedTime = Time.time;
			}
			smallestDistance = range;
		}



	}

	/*
	void OnTriggerEnter(Collider co) {
		if (co.tag == "Monster") {
			GameObject g = (GameObject)Instantiate (shot, transform.position, Quaternion.identity);
			g.GetComponent<ArrowScript> ().target = co.transform;
		}
	}
	*/

	void fireArrow(GameObject enemy) {
		GameObject arrow = (GameObject)Instantiate (shot, transform.position, Quaternion.identity);
		arrow.GetComponent<Projectile> ().target = enemy.transform;
	}

	GameObject FindClosestMonster(GameObject[] enemies) {
		
		for (var i = 0; i < enemies.Length; i++) {
			float dist = Vector3.Distance (enemies [i].transform.position, transform.position);

			if (dist < range && dist < smallestDistance) {
				shootingTarget = enemies [i];
				smallestDistance = dist;
			}


		}
		//Debug.Log (shootingTarget.transform.position);
		return shootingTarget;
	}
}

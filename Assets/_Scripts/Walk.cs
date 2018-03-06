using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour {

	public float xSpeed = 0;
	public float zSpeed = 2.0f;
	public float attackStrength = 0.9f;

	private bool attacking;

	public string attackAnimName = "attack01";

	private GameObject target;

	// Use this for initialization
	void Start () {
		GetComponent<Animator> ().SetBool ("walk", true);
	}

	// Update is called once per frame
	void Update () {

		if (!attacking) {
			transform.Translate (xSpeed * Time.deltaTime, 0, zSpeed * Time.deltaTime);
		} else {
			bool standing = target.GetComponent<Building>().TakeDamage(attackStrength);
			if (!standing) {
				attacking = false;
				GetComponent<Animator> ().SetBool (attackAnimName, false);
				GetComponent<Animator> ().SetBool ("walk", true);
			}
		}
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Building") {
			attacking = true;
			target = col.gameObject;
			GetComponent<Animator> ().SetBool (attackAnimName, true);
			GetComponent<Animator> ().SetBool ("walk", false);
		}
	}
}

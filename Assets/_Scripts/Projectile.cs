using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	private Rigidbody rb;
	public float attackDamage = 10;

	//Speed
	public float speed;

	//Target (Set by Tower)
	public Transform target;

	void Start() 
	{
		rb = GetComponent<Rigidbody> ();

		rb.velocity = transform.forward * speed;
	}

	void FixedUpdate() 
	{
		if (target != null) {
			Vector3 dir = target.position - transform.position;
			rb.velocity = dir.normalized * speed;
		} else {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter(Collider co) {
		Health health = co.GetComponentInChildren<Health> ();
		if (health) {
			health.TakeDamage (attackDamage);
			Destroy (gameObject);
		}
	}


}
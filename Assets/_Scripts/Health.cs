using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public float health = 50;
	private Animator animator;

	void Start() {
		animator = GetComponent<Animator> ();
	}

	public bool TakeDamage(float damage) {
		health -= damage;

		if (health <= 0) {
			animator.SetBool ("attack01", false);
			animator.SetBool ("walk", false);
			animator.SetBool ("dead", true);

			gameObject.SetActive (false);
			Destroy (gameObject);
			return false;
		}

		return true;
	}
}

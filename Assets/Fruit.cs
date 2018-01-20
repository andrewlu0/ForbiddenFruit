using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour {

	public GameObject fruitSlicedPrefab;
	public float startForce = 13f;
	public Blade user;

	Rigidbody2D rb;

	void Start(){
		rb = GetComponent<Rigidbody2D>();
		rb.AddForce (this.transform.up * startForce, ForceMode2D.Impulse);
		transform.rotation = Random.rotation;
	}

	void OnTriggerEnter2D (Collider2D col){
		if (col.tag == "Blade") {
			Vector3 direction = (col.transform.position - transform.position).normalized;
			Quaternion rotation = Quaternion.LookRotation (direction);
			GameObject sliced = Instantiate (fruitSlicedPrefab, transform.position, rotation);
			Destroy (sliced, 3f);
			Destroy (gameObject);
	
		}
	}
}

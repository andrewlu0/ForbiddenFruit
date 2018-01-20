using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blade : MonoBehaviour {
	public GameObject bladeTrail;
	public float minVel = .001f;
	public Text scoreText;
	private int score;
	GameObject currentBladeTrail;
	CircleCollider2D circleCollider;
	bool isCutting = false;
	Rigidbody2D rb;
	Camera cam;
	Vector2 previous;
	void Start(){
		cam = Camera.main;
		rb = GetComponent<Rigidbody2D>();
		circleCollider = GetComponent<CircleCollider2D> ();
		circleCollider.enabled = false;
		score = 0;
		scoreText.text = "PODS OPENED: " + score;
	}

	void addScore(){
		score++;
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			StartCutting ();
		} else if (Input.GetMouseButtonUp (0)) {
			StopCutting ();
		}
		if (isCutting) {
			updateCut ();
		}
		scoreText.text = "PODS OPENED: " + score;

	}
	void StartCutting(){
		isCutting = true;
		currentBladeTrail = Instantiate (bladeTrail, transform);
		previous = cam.ScreenToWorldPoint (Input.mousePosition);
		circleCollider.enabled = false;
	}
	void StopCutting(){
		isCutting = false;
		currentBladeTrail.transform.SetParent (null);
		Destroy (currentBladeTrail, 3f);
		circleCollider.enabled = false;

	}
	void updateCut(){
		Vector2 newPos = cam.ScreenToWorldPoint(Input.mousePosition);
		rb.position = newPos;
		float velocity = (newPos - previous).magnitude*Time.deltaTime;
		if (velocity > minVel) {
			circleCollider.enabled = true;
		} else {
			circleCollider.enabled = false;
		}
		previous = newPos;
	}
	void OnTriggerEnter2D (Collider2D col){
		if (col.tag == "Pod") {
			score++;
		}
	}
}

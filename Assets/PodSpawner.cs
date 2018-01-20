using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PodSpawner : MonoBehaviour {

	public GameObject podPrefab;
	public Transform[] SpawnPoints;
	public float minDelay = 0.1f;
	public float maxDelay = 1f;

	public Text scoreText;
	public int score;
	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnPods ());
	}

	IEnumerator SpawnPods(){
		while (true) {
			float delay = Random.Range (minDelay, maxDelay);
			yield return new WaitForSeconds (delay);
			int spawnIndex = Random.Range (0, SpawnPoints.Length);
			Transform spawnPoint = SpawnPoints[spawnIndex];

			GameObject pod = Instantiate (podPrefab, spawnPoint.position, spawnPoint.rotation);
			Destroy (pod, 5f);
		}

	}
		
	// Update is called once per frame
	void Update () {
		
	}
}

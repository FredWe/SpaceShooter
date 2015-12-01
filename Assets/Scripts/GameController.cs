using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	//1. spawning harzards

	public GameObject harzard;
	public Vector3 spawnValues;

	void spawnWaves () {
		Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (harzard, spawnPosition, spawnRotation);
	}

	// Use this for initialization
	void Start () {
		spawnWaves ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

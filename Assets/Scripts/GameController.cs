using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	//1. spawning harzards

	public GameObject harzard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GUIText scoreText;
	public int score;

	public void AddScore (int newScoreValue) {
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore () {
		scoreText.text = "Score: " + score;
	}

	IEnumerator spawnWaves () {
		yield return new WaitForSeconds (startWait);
		while (true) {
			for (int i = 0; i < hazardCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (harzard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}

	// Use this for initialization
	void Start () {
		score = 0;
		UpdateScore ();
		StartCoroutine (spawnWaves ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

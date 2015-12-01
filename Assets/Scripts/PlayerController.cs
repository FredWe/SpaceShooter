﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
	 
}

public class PlayerController : MonoBehaviour {

	public float speed;
	public float tilt;
	public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;
    
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            //GameObject clone = 
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation); // as GameObject;
			AudioSource audio = GetComponent<AudioSource> ();
			audio.Play ();
        }
        // Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
           // If directly call Instiante() in Update(), it will create a flow of shot. Since on every frame, a shot created.
    }

    void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		Rigidbody rigidbody = GetComponent<Rigidbody> ();
		rigidbody.velocity = movement * speed;

		rigidbody.position = new Vector3 (
			Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax) 
			);
		rigidbody.rotation = Quaternion.Euler (rigidbody.velocity.z * tilt, 0.0f, rigidbody.velocity.x * -tilt);
	}

}

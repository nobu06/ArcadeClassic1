using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 10.0f;		// player's movement

	public GameObject bulletPrefab;
	public Transform bulletSpawn;
	public GameObject bulletGiantPrefab;

	/*
	 * Tae input to move the player with the arrow keys
	 */ 
	void Update() {
		float translation = Input.GetAxis ("Vertical") * speed;		// forward and backward
		float straffe = Input.GetAxis ("Horizontal") * speed;		// side movement

		// to ensure character moves smoothly, since Update doesn't 
		// get called at the same time every frame or each frame is called at different time
		translation *= Time.deltaTime;
		straffe *= Time.deltaTime;

		transform.Translate (-straffe, translation, 0);			// Note: had to do -straffe for spaceship. Don't know why


//		var x = Input.GetAxis ("Horizontal") * Time.deltaTime * 150.0f;
//		var z = Input.GetAxis ("Vertical") * Time.deltaTime * 3.0f;
//
//		transform.Rotate (0, x, 0);
//		transform.Translate (0, 0, z);
//

		if (Input.GetKeyDown(KeyCode.Space)) {
			Fire();
		}

		if (Input.GetKeyDown (KeyCode.V)) {
			FireExtra ();
		}


		// line used for memory management. Still deciding where would be a good place to put it
		Resources.UnloadUnusedAssets();		// should be placed here or elsewhere??
	}

	/*
	 * Instantiates a bullet.
	 * The bullet gets destroyed after 5 seconds
	 */ 
	void Fire() {
		// Create the bullet from the bullet prefb
		var bullet = (GameObject)Instantiate (
			bulletPrefab,
			bulletSpawn.position,
			bulletSpawn.rotation);

		// Add velocity to the bullet
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 50;

		// Destroy the bullet after 10 seconds
		Destroy(bullet, 5.0f);
	}



	void FireExtra() {
		// Create the bullet from the bullet prefb
		var bullet = (GameObject)Instantiate (
			bulletGiantPrefab,
			bulletSpawn.position,
			bulletSpawn.rotation);

		// Add velocity to the bullet
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

		// Destroy the bullet after 2 seconds
		Destroy(bullet, 10.0f);
	}
}
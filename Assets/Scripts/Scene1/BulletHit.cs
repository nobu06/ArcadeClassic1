using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour {

	// Q) how can I keep track of the entire score??
	// seems like this count will only last during the lifetime of the bullet

	private int count;

	void Start() {
		count = 0;
	}

	void OnTriggerEnter(Collider other) {

		// set object with the tag "enemy" to inactive when the bullet hits it - includes Enemy obj and Enemy bullets
		if (other.gameObject.CompareTag ("Enemy"))
		{
			other.gameObject.SetActive (false);		// make the enemy disappear
			count++;
			this.gameObject.SetActive (false);		// make the bullet disappear
			//			setCountText ();

//			Destroy(other.gameObject);			// destroy the object to prevent memory leak. Working?
//			Destroy(this.gameObject);
		}
	}
}

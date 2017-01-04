using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour {

	// Q) how can I keep track of the entire score??
	// seems like this count will only last during the lifetime of the bullet

	private int count;

	void Start()
	{
		count = 0;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Enemy"))
		{
			other.gameObject.SetActive (false);
			count++;
			this.gameObject.SetActive (false);
			//			setCountText ();
		}
	}
}

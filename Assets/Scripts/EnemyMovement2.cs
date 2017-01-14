/* 
 * ver 2 of enemy movement that converges all enemies to one position.
 * The default is (0, 0, 0) so they all converge to that point.
 * Also possible to set a different position for each enemy. Would like to play around with that.
 */

using UnityEngine;
using System.Collections;

public class EnemyMovement2 : MonoBehaviour {
	public Vector3 pointB;

	IEnumerator Start()
	{
		var pointA = transform.position;
		while (true) {
			yield return StartCoroutine(MoveObject(transform, pointA, pointB, 3.0f));
			yield return StartCoroutine(MoveObject(transform, pointB, pointA, 3.0f));
		}
	}

	IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
	{
		var i= 0.0f;
		var rate= 1.0f/time;
		while (i < 1.0f) {
			i += Time.deltaTime * rate;
			thisTransform.position = Vector3.Lerp(startPos, endPos, i);
			yield return null; 
		}
	}

//	// for firing bullets
//	public GameObject bulletPrefab;		
//	public Transform bulletSpawn;	
//
//	// for firing bullets at random times
//	public float fireRatep;
//	public float fireRatem;
//	private float nextFire;
//
//	// for enemy movement
//	//	public Transform farEnd;		// Q? what is this for?
//	private Vector3 frometh;		// position A
//	private Vector3 untoeth;		// position B
//	private float secondsForOneLength = 5f;
//
//	private Vector3 sideOffset = new Vector3(5, 0, 0);	
//
//
//	void Start() {
//		// set the two positions that the obj will move between.
//		frometh = transform.position;
//		untoeth = transform.position + sideOffset;
//
//		// to make enemy to shoot at random times
//		nextFire = nextFire + Random.Range (fireRatep, fireRatem);		// or nextFire = Time.time + Random.Range (fireRatep, fireRatem);
//	}
//
//
//	void Update() {
//		transform.position = Vector3.Lerp(frometh, untoeth,
//			Mathf.SmoothStep(0f, 1f, Mathf.PingPong(Time.time/secondsForOneLength, 1f) ) );
//	}
//
//
//	void FixedUpdate () {
//		if (Time.time > nextFire) {
//			nextFire = Time.time + Random.Range (fireRatep, fireRatem);
//			Fire ();   // Instantiate (bolt, Canon.position, Canon.rotation);
//		}
//	}
//
//	/*
//	 * Fires the bullet
//	 */
//	void Fire()
//	{
//		// Create the bullet from the bullet prefb
//		var bullet = (GameObject)Instantiate (
//			bulletPrefab,
//			bulletSpawn.position,
//			bulletSpawn.rotation);
//
//		// Add velocity to the bullet
//		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 50;
//
//		// Destroy the bullet after 3 seconds
//		Destroy(bullet, 3.0f);
//	}
}

// Code by duck from: http://answers.unity3d.com/questions/14279/make-an-object-move-from-point-a-to-point-b-then-b.html
// shooting at random times - http://answers.unity3d.com/questions/863280/random-enemy-fire-rate.html
using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	// for firing bullets
	public GameObject bulletPrefab;		
	public Transform bulletSpawn;	

	// for firing bullets at random times
	public float fireRatep;
	public float fireRatem;
	private float nextFire;

	// for enemy movement
	//	public Transform farEnd;		// Q? what is this for?
	private Vector3 frometh;		// position A
	private Vector3 untoeth;		// position B
	private float secondsForOneLength = 5f;

	private Vector3 sideOffset = new Vector3(5, 0, 0);	


	void Start() {
		// set the two positions that the obj will move between
		frometh = transform.position;
		untoeth = transform.position + sideOffset;

		// set random value that determines when it will shoot
		nextFire = nextFire + Random.Range (fireRatep, fireRatem);		// or nextFire = Time.time + Random.Range (fireRatep, fireRatem);
	}


	/*
	 * Enemy movement that goes sideways between two positions, back and forth
	 */
	void Update() {
		transform.position = Vector3.Lerp(frometh, untoeth,
			Mathf.SmoothStep(0f, 1f, Mathf.PingPong(Time.time/secondsForOneLength, 1f) ) );
	}


	/*
	 * Decides whether to shoot a bullet or not, based on random number calculation
	 */
	void FixedUpdate () {
		if (Time.time > nextFire) {
			nextFire = Time.time + Random.Range (fireRatep, fireRatem);
			Fire ();   // Instantiate (bolt, Canon.position, Canon.rotation);
		}
	}

	/*
	 * Instantiates a bullet.
	 * The bullet gets destroyed after a few seconds.
	 */
	void Fire() {
		// Create the bullet from the bullet prefb
		var bullet = (GameObject)Instantiate (
			bulletPrefab,
			bulletSpawn.position,
			bulletSpawn.rotation);

		// Add velocity to the bullet
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 50;

		// Destroy the bullet after 3 seconds
		Destroy(bullet, 3.0f);


	}
		
}	




/* (IMP!) Save! - shrinks all into one position. */
//public class EnemyMovement : MonoBehaviour
//{
//	public Transform farEnd;
//	private Vector3 frometh;
//	private Vector3 untoeth;
//	private float secondsForOneLength = 20f;
//
//	void Start()
//	{
//		frometh = transform.position;
//		untoeth = farEnd.position;
//	}
//
//	void Update()
//	{
//		transform.position = Vector3.Lerp(frometh, untoeth,
//			Mathf.SmoothStep(0f,1f,
//				Mathf.PingPong(Time.time/secondsForOneLength, 1f)
//			) );
//	}
//}



/* (IMP! - but in Javascript not C#) Save! - ver 2 of awesome, shrink all into one object method */
//public class EnemyMovement : MonoBehaviour {
//	public Vector3 pointB;
//
//	IEnumerator Start()
//	{
//		var pointA = transform.position;
//		while (true) {
//			yield return StartCoroutine(MoveObject(transform, pointA, pointB, 3.0f));
//			yield return StartCoroutine(MoveObject(transform, pointB, pointA, 3.0f));
//		}
//	}
//
//	IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
//	{
//		var i= 0.0f;
//		var rate= 1.0f/time;
//		while (i < 1.0f) {
//			i += Time.deltaTime * rate;
//			thisTransform.position = Vector3.Lerp(startPos, endPos, i);
//			yield return null; 
//		}
//	}
//}


// https://www.youtube.com/watch?v=blO039OzUZc

using UnityEngine;
using System.Collections;

public class CamMouseLook : MonoBehaviour {

	Vector2 mouseLook;		// keep track of movement the camera has made. Total movement
	Vector2 smoothV;		// Q) why Vector2?		// smooth out the movement of the mouse b/c w/o it, can be jerky
	public float sensitivity = 5.0f;
	public float smoothing = 2.0f;

	GameObject character;	// also moves the character as well

	void Start ()
	{
		// character is set to the parent (the code is attached to, camera)		// Q) c???
		character = this.transform.parent.gameObject;	
	}

	// Update is called once per frame
	void Update ()
	{
		// like mouse delta
		var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));		// just gives change of change since last Update()

		md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
		smoothV.x = Mathf.Lerp (smoothV.x, md.x, 1f / smoothing);		// Lerp - linear interpretation of movement. Move smoothly b/w two points
		smoothV.y = Mathf.Lerp (smoothV.y, md.y, 1f / smoothing);
		mouseLook += smoothV;

		mouseLook.y = Mathf.Clamp (mouseLook.y, -90f, 90f);		// to add going up and down


		// m??
		transform.localRotation = Quaternion.AngleAxis (-mouseLook.y, Vector3.right);	// as local rotation around camera around its right axis
		// -mouseLook.y -- negative gives inverted value
		character.transform.localRotation = Quaternion.AngleAxis (mouseLook.x, character.transform.up);	// rotates around the character's up not the camera
	}
}
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public int speed;
	public float xMin, xMax, zMin, zMax;

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
		rigidbody.velocity = movement * speed;

		rigidbody.position = new Vector3
		(
			Mathf.Clamp(rigidbody.position.x, xMin, xMax),
			0,
			Mathf.Clamp(rigidbody.position.z, zMin, zMax)
		);
	}
}
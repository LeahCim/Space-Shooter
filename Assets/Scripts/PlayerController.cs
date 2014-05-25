using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
	public int speed;
	public Boundary boundary;

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
		rigidbody.velocity = movement * speed;

		rigidbody.position = new Vector3
		(
			Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
			0,
			Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax)
		);
	}
}
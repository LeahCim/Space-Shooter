using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
	public GameObject player;
	public float speed;

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{
		Vector3 heading = player.transform.position - transform.position;

		rigidbody.velocity = new Vector3
		(
			heading.normalized.x * speed,
			rigidbody.velocity.y,
			rigidbody.velocity.z
		);
	}
}
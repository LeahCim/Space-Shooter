using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
	public GameObject player;
	public float speed;

	void Start ()
	{

	}
	
	void FixedUpdate ()
	{
		if(player != null) {
			Vector3 heading = player.transform.position - transform.position;

			if(Mathf.Abs(heading.z) > 5.0)
			{
				rigidbody.velocity = new Vector3
				(
					heading.normalized.x * speed,
					rigidbody.velocity.y,
					rigidbody.velocity.z
				);
			}
		}
	}
}
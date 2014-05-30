using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
	public GameObject player;
	public ProximitySensor proximitySensor;
	public float speed;

	void FixedUpdate ()
	{
		if(proximitySensor.triggered) {
			Debug.Log ("Triggered: " + proximitySensor.triggered);
			Vector3 escapeRoute = transform.position - proximitySensor.otherPosition;
			rigidbody.velocity = escapeRoute.normalized * speed;
		}
		else
		{
			FollowPlayer();
		}
	}

	void FollowPlayer ()
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

	void OnTriggerEnter(Collider other)
	{
		Debug.Log("In Enemy, triggered by: " + other.name);
		if(other.tag == "ProximitySensor")
		{
			return;
		}
	}
}
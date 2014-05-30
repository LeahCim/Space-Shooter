using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
	public GameObject player;
	public ProximitySensor proximitySensor;
	public float speed;
	public Boundary boundary;
	public float tilt;
	public float randomMoveDelay;
	private float nextRandomMove = 0;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private float nextFire = 0.0F;

	void Update ()
	{
		if (Time.time > nextFire &&
		    transform.position.z < boundary.zMax - 5)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			audio.Play();
		}
	}
	
	void FixedUpdate ()
	{
		if(proximitySensor.triggered) {
			Vector3 escapeRoute = transform.position - proximitySensor.otherPosition;
			rigidbody.velocity = escapeRoute.normalized * speed;
		}
		else
		{
			FollowPlayer();
		}

		if(Time.time > nextRandomMove)
		{
			nextRandomMove = Time.time + randomMoveDelay;
			rigidbody.velocity += Random.insideUnitSphere;
		}

		rigidbody.position = new Vector3
			(
				Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
				0,
				Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax)
				);
		
		rigidbody.rotation = Quaternion.Euler(0, 180, rigidbody.velocity.x * -tilt);
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
}
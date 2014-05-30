using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
	public ProximitySensor proximitySensor;
	public float speed;
	public Boundary boundary;
	public float tilt;
	public float randomMoveDelay;
	public float randomMoveDistance;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float targetDistX;

	private GameObject player;
	private GameObject lastShot;
	private float nextRandomMove = 0;
	private float nextFire = 0.0F;

	void Start()
	{
		player = GameObject.FindWithTag("Player");
		if (player == null)
		{
			Debug.Log("Cannot find the 'Player' object");
		}
	}

	void Update ()
	{
		if(player != null)
		{
			float xDistance = Mathf.Abs
				( 
					player.transform.position.x - transform.position.x
				);
			if(xDistance < targetDistX &&
			   player.transform.position.z < transform.position.z)
			{
				Fire();
			}
		}
	}

	void FixedUpdate ()
	{
		if(proximitySensor.triggered) {
			float xDistance = Mathf.Abs
				(
					proximitySensor.obstaclePos.x - transform.position.x
				);
			if(proximitySensor.obstacle != null &&
			   proximitySensor.obstacle.tag != "Enemy" &&
			   xDistance < targetDistX &&
			   proximitySensor.obstaclePos.z < transform.position.z)
			{
				Fire();
			}
			else
			{
				Vector3 escapeRoute = transform.position - proximitySensor.obstaclePos;
				rigidbody.velocity = escapeRoute.normalized * speed;
			}
		}
		else
		{
			FollowPlayer();
		}

		if(Time.time > nextRandomMove)
		{
			nextRandomMove = Time.time + randomMoveDelay;
			rigidbody.velocity += Random.insideUnitSphere * randomMoveDistance;
		}

		rigidbody.position = new Vector3
			(
				Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
				0,
				Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax)
			);

		rigidbody.rotation = Quaternion.Euler(0, 180, rigidbody.velocity.x * tilt);
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

	void Fire()
	{
		if (Time.time > nextFire && transform.position.z < boundary.zMax - 3)
		{
			nextFire = Time.time + fireRate;
			lastShot = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
			audio.Play();
		}
	}

	public bool OwnShot(GameObject shot)
	{
		if(lastShot != null)
		{
			return shot.GetInstanceID() == lastShot.GetInstanceID();
		}
		return false;
	}
}
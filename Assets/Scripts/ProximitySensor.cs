using UnityEngine;
using System.Collections;

public class ProximitySensor : MonoBehaviour {

	public bool triggered { get; private set; }
	public GameObject obstacle { get; private set; }
	public Vector3 obstaclePos { get; private set; }

	void Start () {
		triggered = false;
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag == "Boundary" || other.tag == "Enemy" ||
		   other.tag == "EnemyBolt" || other.tag == "ProximitySensor")
		{
			return;
		}
		triggered = true;
		obstacle = other.gameObject;
		obstaclePos = other.transform.position;
	}

	void OnTriggerExit(Collider other) {
		if(other.tag == "Boundary" || other.tag == "Enemy" || other.tag == "EnemyBolt")
		{
			return;
		}
		triggered = false;
	}
}
using UnityEngine;
using System.Collections;

public class ProximitySensor : MonoBehaviour {

	public bool triggered { get; private set; }
	public GameObject obstacle { get; private set; }

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
	}

	void OnTriggerExit(Collider other) {
		if(other.tag == "EnemyBolt")
		{
			return;
		}
		triggered = false;
	}
}
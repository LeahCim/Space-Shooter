using UnityEngine;
using System.Collections;

public class ProximitySensor : MonoBehaviour {

	public bool triggered { get; private set; }
	public GameObject obstacle { get; private set; }

	void Start () {
		triggered = false;
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag == "EnemyBolt" ||
		   other.tag == "ProximitySensor" ||
		   other.tag == "Boundary" ||
		   transform.parent == other.transform)
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
using UnityEngine;
using System.Collections;

public class ProximitySensor : MonoBehaviour {

	public bool triggered { get; private set; }
	public Vector3 otherPosition { get; private set; }

	void Start () {
		triggered = false;
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag == "Boundary" || other.tag == "Enemy" || other.tag == "EnemyBolt")
		{
			return;
		}
		triggered = true;
		otherPosition = other.transform.position;
	}

	void OnTriggerExit(Collider other) {
		if(other.tag == "Boundary" || other.tag == "Enemy" || other.tag == "EnemyBolt")
		{
			return;
		}
		triggered = false;
	}
}
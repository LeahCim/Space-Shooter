using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		rigidbody.constraints = RigidbodyConstraints.FreezeRotation |
								RigidbodyConstraints.FreezePositionY;
	}

	// Update is called once per frame
	void Update ()
	{

	}
}
using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;

	public int scoreValue;
	private GameController gameController;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log("Cannot find the 'GameController' object");
		}
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag == "Boundary" || other.tag == "ProximitySensor")
		{
			return;
		}
		if(other.tag == "Bolt")
		{
			gameController.AddScore(scoreValue);
		}
		if(explosion != null)
		{
			Instantiate(explosion, transform.position, transform.rotation);
		}
		Destroy (gameObject);
	}
}
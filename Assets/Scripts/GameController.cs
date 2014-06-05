using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject asteroid1;
	public GameObject asteroid2;
	public GameObject asteroid3;
	public GameObject purpleEnemy;
	public GameObject redEnemy;
	public float enemyChance;

	public Vector3 spawnValues;
	public int hazardCount;
	public float asteroidSpawnWait;
	public float enemyPreSpawnWait;
	public float enemySpawnWait;
	public float startWait;
	public float waveWait;

	public GUIText scoreText;
	public GUIText gameOverText;
	public GUIText restartText;

	private GameObject hazard;
	private int score;
	private bool gameOver;
	private bool restart;

	void Start()
	{
		score = 0;
		gameOver = false;
		restart = false;

		gameOverText.text = "";
		restartText.text = "";

		UpdateScore();
		StartCoroutine ( SpawnWaves() );
	}

	void Update()
	{
		if(restart)
		{
			if(Input.GetKeyDown(KeyCode.R))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds(startWait);
		float spawnWait = 0;
		float preSpawnWait = 0;
		while(true)
		{
			for(int i = 0; i < hazardCount; i++)
			{
				Vector3 spawnPosition = new Vector3
					(
						Random.Range(-spawnValues.x, spawnValues.x),
						spawnValues.y,
						spawnValues.z
					);
				Quaternion spawnRotation = Quaternion.identity;

				if(Random.value < enemyChance)
				{
					if(Random.value < 0.5)
					{
						hazard = purpleEnemy;
					}
					else
					{
						hazard = redEnemy;
					}
					preSpawnWait = enemyPreSpawnWait;
					spawnWait = enemySpawnWait;
				}
				else
				{
					float rand = Random.value;
					if(rand < 0.334)
					{
						hazard = asteroid1;
					}
					else if(rand < 0.667)
					{
						hazard = asteroid2;
					}
					else
					{
						hazard = asteroid3;
					}
					preSpawnWait = 0;
					spawnWait = asteroidSpawnWait;
				}
				yield return new WaitForSeconds(preSpawnWait);
				Instantiate(hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);

			if(gameOver)
			{
				restartText.text = "Press 'R' to Restart";
				restart = true;
				break;
			}
		}
	}

	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore();
	}

	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}

	public void GameOver()
	{
		if(gameOverText != null)
		{
			gameOverText.text = "Game Over";
		}
		gameOver = true;
	}
}
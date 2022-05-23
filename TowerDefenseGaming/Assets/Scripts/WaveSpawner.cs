using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WaveSpawner : MonoBehaviour
{
	public Transform enemyPrefab;
	public Transform spawnPoint;
	public float timeBetweenWaves = 5f;
	private float countdown = 10f;
	private int waveNumber = 1;


    public Text waveCountdownText;

    void Update()
	{
		if(countdown <= 0)
		{
			StartCoroutine(spawnWave());
			countdown = timeBetweenWaves;
		}
		countdown -= Time.deltaTime;
		
		waveCountdownText.text = "Wave Spawn:" + Mathf.Floor(countdown).ToString();
	}
	IEnumerator spawnWave()
	{
		Debug.Log("Wave Incoming!");
		for(int i = 0; i < waveNumber; i++)
		{
			spawnEnemy();
			yield return new WaitForSeconds(0.3f);
		}
		waveNumber++;
	}
	
	void spawnEnemy()
	{
		Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
	}
}

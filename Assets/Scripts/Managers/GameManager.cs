using UnityEngine;
using System.Collections;

namespace Managers
{
	public class GameManager : MonoBehaviour 
	{
		#region Singleton
		private static GameManager instance;

		public static GameManager GetInstance()
		{
			return instance;
		}
		#endregion

		[SerializeField] private GameObject[] EnemiesPrefab;
		[SerializeField] private int MaxEnemies;
		[SerializeField] private float SpawnTime;
		private int aliveEnemies;
		private GameObject playerObject;

		public void Dead(GameObject gameChar)
		{
			if (gameChar.tag.Equals ("Enemy")) {
				aliveEnemies--;
				Destroy(gameChar);
			} else {
				GameOver();
			}
		}

		public GameObject GetPlayerObject()
		{
			return playerObject;
		}

		private void GameOver()
		{
			Debug.Log("GameOver");
		}

		private void Awake()
		{
			instance = this;

			if(EnemiesPrefab.Length > 0)
				StartCoroutine (SpawnEnemy (SpawnTime));

			playerObject = GameObject.FindGameObjectWithTag ("Player");
		}

		private IEnumerator SpawnEnemy(float delay)
		{
			while (true) 
			{
				yield return new WaitForSeconds (delay);
				if (aliveEnemies < MaxEnemies)
					Spawn (EnemiesPrefab [Random.Range (0, EnemiesPrefab.Length)]);
			}
		}

		private void Spawn(GameObject enemy)
		{
			Instantiate (enemy, Vector3.zero, Quaternion.identity);

			aliveEnemies++;
		}
	}
}
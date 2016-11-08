using System.Collections;
using UnityEngine;

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

        [SerializeField] private GameObject[] enemiesPrefab;
        [SerializeField] private GameObject explosionParticlePrefab;
        [SerializeField] private AudioClip explosionSound;
        [SerializeField] private int maxEnemies;
        [SerializeField] private float spawnTime;
        [SerializeField] private Vector2 spawnArea;
        private int aliveEnemies;
        private GameObject playerObject;
        private IEnumerator spawnEnumerator;

        #region Public methods

        /// <summary>
        /// Вызывается, когда объект мертв
        /// </summary>
        /// <param name="deadGameObject">объект, который мертв</param>
        public void Dead(GameObject deadGameObject)
        {
            Destroy(Instantiate(explosionParticlePrefab, deadGameObject.transform.position, Quaternion.identity), 5f);
            AudioSource.PlayClipAtPoint(explosionSound, deadGameObject.transform.position);

            if (deadGameObject.tag.Equals("Enemy"))
            {
                aliveEnemies--;
                Destroy(deadGameObject);
            }
            else
            {
                deadGameObject.SetActive(false);
                GameOver();
            }
        }

        public GameObject GetPlayerObject()
        {
            return playerObject;
        }

        #endregion

        private void GameOver()
        {
            StopCoroutine(spawnEnumerator);
        }

        private void Awake()
        {
            instance = this;
            spawnEnumerator = SpawnEnemy(spawnTime);

            if (enemiesPrefab.Length > 0)
            {
                StartCoroutine(spawnEnumerator);
            }


            playerObject = GameObject.FindGameObjectWithTag("Player");
        }

        private IEnumerator SpawnEnemy(float delay)
        {
            while (true)
            {
                yield return new WaitForSeconds(delay);
                if (aliveEnemies < maxEnemies)
                    Spawn(enemiesPrefab[Random.Range(0, enemiesPrefab.Length)]);
            }
        }

        private void Spawn(GameObject enemy)
        {
            Vector3 position = new Vector3(
                Random.Range(-spawnArea.x, spawnArea.x),
                0f,
                Random.Range(-spawnArea.y, spawnArea.y));

            Instantiate(enemy, position, Quaternion.identity);
            aliveEnemies++;
        }
    }
}
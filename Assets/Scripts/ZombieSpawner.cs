using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class ZombieSpawner : MonoBehaviour
    {
        [SerializeField] private float spawnRate = 1f;
        [SerializeField] private GameObject zombiePrefab;
        [SerializeField] private bool canSpawn = true;

        private void Start()
        {
            StartCoroutine(SpawnZombie());
        }

        private IEnumerator SpawnZombie()
        {
            WaitForSeconds wait = new WaitForSeconds(spawnRate);

            while (canSpawn)
            {
                Instantiate(zombiePrefab, transform.position, Quaternion.identity);
                yield return wait;

                GameObject enemyToSpawn = Instantiate(zombiePrefab, transform.position, Quaternion.identity);
            }
        }
    }
}

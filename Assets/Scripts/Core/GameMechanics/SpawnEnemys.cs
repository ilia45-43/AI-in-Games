using UnityEngine;
using System.Collections;

public class SpawnEnemys : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float delayForSpawn;

    private GameObject[] placeForSpawn;
    private WaitForSeconds waitForSeconds;

    private void Start()
    {
        waitForSeconds = new WaitForSeconds(delayForSpawn);
        placeForSpawn = GameObject.FindGameObjectsWithTag("PlaceForSpawn");
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            System.Random random = new System.Random();
            int place = random.Next(placeForSpawn.Length);
            Instantiate(enemyPrefab, placeForSpawn[place].transform.position, Quaternion.identity);

            yield return waitForSeconds;
        }
    }
}

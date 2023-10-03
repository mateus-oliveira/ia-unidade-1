using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject heal;
    [SerializeField] private GameObject bomb;
    [SerializeField] private int enemiesAmount;
    [SerializeField] private int healAmount;
    [SerializeField] private int bombsAmount;

    void Start()
    {
        StartCoroutine(SpawnObject(enemy));
        StartCoroutine(SpawnObject(heal));
        StartCoroutine(SpawnObject(bomb));
    }

    IEnumerator SpawnObject(GameObject spawnObject){
        int limit = 0;
        if (spawnObject == enemy)
        {
            limit = enemiesAmount;
        } else if (spawnObject == heal)
        {
            limit = healAmount;
        } else if (spawnObject == bomb)
        {
            limit = bombsAmount;
        }

        for (int i = 0; i < limit; i++)
        {
            var position = new Vector3(Random.Range(-30.0f, 30.0f), Random.Range(-30.0f, 30.0f), 0);
            Instantiate(spawnObject, position, Quaternion.identity);
            yield return new WaitForSeconds(.2f);
        }
    }
}

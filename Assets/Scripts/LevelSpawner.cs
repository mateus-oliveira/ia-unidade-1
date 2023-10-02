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
        for (int i = 0; i < enemiesAmount; i++)
        {
            var position = new Vector3(Random.Range(-30.0f, 30.0f), Random.Range(-30.0f, 30.0f), 0);
            Instantiate(enemy, position, Quaternion.identity);
        }
        for (int i = 0; i < healAmount; i++)
        {
            var position = new Vector3(Random.Range(-30.0f, 30.0f), Random.Range(-30.0f, 30.0f), 0);
            Instantiate(heal, position, Quaternion.identity);
        }
        for (int i = 0; i < bombsAmount; i++)
        {
            var position = new Vector3(Random.Range(-30.0f, 30.0f), Random.Range(-30.0f, 30.0f), 0);
            Instantiate(bomb, position, Quaternion.identity);
        }
    }
}

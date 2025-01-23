using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    public int ColumnPoolSize = 5;
    public GameObject ColumnPrefab;
    public float SpawnRate = 4f;
    public float ColumnMin = -2f;
    public float ColumnMax = 2f;

    private GameObject[] Columns;
    private Vector2 ObjectPoolPosition = new Vector2(-15f, -25f);

    private float TimeSinceLastSpawned;
    private float spawnXPosition = 25f;
    private int CurrentColum = 0;

    void Start()
    {
        Columns = new GameObject[ColumnPoolSize];

        for (int i = 0; i < ColumnPoolSize; i++)
        {
            Columns[i] = (GameObject)Instantiate(ColumnPrefab, ObjectPoolPosition, Quaternion.identity);
        }   
    }

    void Update()
    {
        TimeSinceLastSpawned += Time.deltaTime;

        if (!GameManager.Instance.IsGameOver && TimeSinceLastSpawned >= SpawnRate)
        {
            TimeSinceLastSpawned = 0;

            float spawnYPosition = Random.Range(ColumnMin, ColumnMax);

            Columns[CurrentColum].transform.position = new Vector2(spawnXPosition, spawnYPosition);

            CurrentColum++;

            if (CurrentColum >= ColumnPoolSize)
            {
                CurrentColum = 0;
            }
        }   
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zadanie5 : MonoBehaviour
{
    public GameObject cubePrefab; 
    public int cubeIlosc = 10; 
    

    private List<Vector3> pozycjeZajete = new List<Vector3>(); 

    void Start()
    {
        SpawnCubes();
    }

    void SpawnCubes()
    {
        for (int i = 0; i < cubeIlosc; i++)
        {
            Vector3 randomPosition = GetRandomPosition();

            while (pozycjeZajete.Contains(randomPosition))
            {
                randomPosition = GetRandomPosition(); 
            }

            pozycjeZajete.Add(randomPosition); 

            Instantiate(cubePrefab, randomPosition, Quaternion.identity);
        }
    }

    Vector3 GetRandomPosition()
    {
        float randomX = Random.Range(-10, 10);
        float randomZ = Random.Range(-10, 10);


        return new Vector3(randomX, 1.5f, randomZ);
    }
}
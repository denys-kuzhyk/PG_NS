using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class zadanie1 : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    public int objectCounter;
    public GameObject block;
    public Material[] materials;

    void Start()
    {
        
        Renderer platformRenderer = GetComponent<Renderer>();
        Bounds platformBounds = platformRenderer.bounds;

        
        float minX = platformBounds.min.x;
        float maxX = platformBounds.max.x;
        float minZ = platformBounds.min.z;
        float maxZ = platformBounds.max.z;

        
        for (int i = 0; i < objectCounter; i++)
        {
            float randomX = UnityEngine.Random.Range(minX, maxX);
            float randomZ = UnityEngine.Random.Range(minZ, maxZ);
            this.positions.Add(new Vector3(randomX, platformBounds.max.y + 1, randomZ)); 
        }

        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {

    }

    IEnumerator GenerujObiekt()
    {

        // int generatedObjects = 0;

        foreach (Vector3 pos in positions)
        {
            
            GameObject newBlock = Instantiate(this.block, pos, Quaternion.identity);

            
            if (materials.Length > 0)
            {
                Material randomMaterial = materials[UnityEngine.Random.Range(0, materials.Length)];
                newBlock.GetComponent<Renderer>().material = randomMaterial;
            }

            // generatedObjects++;

            
            yield return new WaitForSeconds(this.delay);
        }

        
        StopCoroutine(GenerujObiekt());
    }
}

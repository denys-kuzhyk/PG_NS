using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zadanie2 : MonoBehaviour
{
    public float speed = 5f; 
    private Vector3 startPosition1; 
    private Vector3 targetPosition; 
    private bool ruchDoCelu = true; 

    void Start()
    {
        
        startPosition1 = transform.position;
        
        targetPosition = startPosition1 + new Vector3(5f, 0f, 0f);
    }

    void Update()
    {
        


        if (ruchDoCelu)
        {
        
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        
            if (transform.position == targetPosition)
            {
        
                ruchDoCelu = false;
            }
        }
        else
        {
            transform.Rotate(90, 0, 0);

            transform.position = Vector3.MoveTowards(transform.position, startPosition1, speed * Time.deltaTime);
            
            if (transform.position == startPosition1)
            {
                ruchDoCelu = true;
            }
        }
    }
}

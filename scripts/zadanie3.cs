using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zadanie3 : MonoBehaviour
{
    float speed = 5f; // Pr?dko?? poruszania si?
    float sideLength = 10f; // D?ugo?? boku kwadratu
    
    public GameObject kierunek; // Obiekt wskazuj?cy kierunek (np. strza?ka)

    Vector3 startPosition; // Pocz?tkowa pozycja
    int currentDirection = 0; // Indeks kierunku (0: w prawo, 1: w g�r?, 2: w lewo, 3: w d�?)
    Vector3[] directions;
    Vector3[] destinations; // Kierunki ruchu
    Vector3 targetPosition; // Pozycja docelowa



    // bool moving = true;

    int currentTarget = 1;


    void Start()
    {
        


        directions = new Vector3[]{
            Vector3.forward,
            Vector3.right,
            Vector3.back,
            Vector3.left
        };
        
        destinations = new Vector3[]{
            new Vector3(5f, 0.5f, 5f),
            new Vector3(5f, 0.5f, -5f),
            new Vector3(-5f, 0.5f, -5f),
            new Vector3(-5f, 0.5f, 5f)
        };

        transform.position = destinations[0];
        kierunek.transform.position = new Vector3(0f, 0f, 0f);

    }

    void Update()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, destinations[currentTarget], speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, destinations[currentTarget]) < 0.1f) {
            currentTarget = (currentTarget + 1) % 4;

            transform.Rotate(0f, -90f, 0f, Space.World);
            kierunek.transform.Rotate(0f, 90f, 0f, Space.World);


        }

        
    }
}

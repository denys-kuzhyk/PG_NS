using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMovement : MonoBehaviour
{
    public Transform target; // Cel, do którego zmierzamy
    public float smoothTime = 0.3f; // Czas, po którym dotrzemy do celu

    private Vector3 velocity = Vector3.zero; // Zmienna przechowująca prędkość

    void Update()
    {
        // Płynne przejście pozycji obiektu w kierunku target
        transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, smoothTime);
    }
}

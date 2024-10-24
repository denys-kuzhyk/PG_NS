using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    // Referencja do obiektu gracza (jego komponent Transform)
    public Transform player;

    public float sensitivity = 200f;
    private float verticalRotation = 0f; // Do śledzenia kąta obrotu kamery w osi X

    void Start()
    {
        // Zablokowanie kursora na środku ekranu, oraz ukrycie kursora
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Pobieramy wartości dla obu osi ruchu myszy
        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // Rotacja gracza wokół osi Y (obrót w poziomie)
        player.Rotate(Vector3.up * mouseXMove);

        // Zmiana kąta obrotu kamery wokół osi X (obrót w pionie)
        verticalRotation -= mouseYMove; // Odejmujemy, aby uzyskać naturalne sterowanie (brak inwersji)
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f); // Ograniczamy obrót do -90 i 90 stopni

        // Ustawienie zaktualizowanego obrotu wokół osi X kamery
        transform.localEulerAngles = new Vector3(verticalRotation, 0f, 0f);
    }
}

using System.Collections;
using UnityEngine;

public class PlytaNaciskowa : MonoBehaviour
{
    public float silaWyrzutu = 30f; 

    private void OnTriggerEnter(Collider inny)
    {
        if (inny.CompareTag("Player"))
        {
            Rigidbody rb = inny.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 wyrzut = Vector3.up * silaWyrzutu;
                rb.AddForce(wyrzut, ForceMode.Impulse);
            }
        }
    }
}

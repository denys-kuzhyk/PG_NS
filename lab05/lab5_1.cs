using System.Collections;
using UnityEngine;

public class PoruszajacaPlatforma : MonoBehaviour
{
    public Transform punktPoczatkowy;
    public Transform punktKoncowy;
    public float predkoscPlatformy = 2f;
    private bool poruszanieDoKonca = true;

    private void OnTriggerEnter(Collider inny)
    {
        if (inny.CompareTag("Player"))
        {
            StartCoroutine(PoruszPlatforma());
        }
    }

    private IEnumerator PoruszPlatforma()
    {
        while (true)
        {
            Transform cel = poruszanieDoKonca ? punktKoncowy : punktPoczatkowy;
            transform.position = Vector3.MoveTowards(transform.position, cel.position, predkoscPlatformy * Time.deltaTime);

            if (transform.position == cel.position)
            {
                poruszanieDoKonca = !poruszanieDoKonca;
            }

            yield return null;
        }
    }
}

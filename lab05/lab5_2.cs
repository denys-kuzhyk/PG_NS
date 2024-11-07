using System.Collections;
using UnityEngine;

public class PrzesuwaneDrzwi : MonoBehaviour
{
    public Transform punktOtwarcia;
    public Transform punktZamkniecia;
    public float predkoscDrzwi = 2f;
    private bool otwieranie = false;

    private void OnTriggerEnter(Collider inny)
    {
        if (inny.CompareTag("Player"))
        {
            otwieranie = true;
            StartCoroutine(PoruszDrzwi());
        }
    }

    private void OnTriggerExit(Collider inny)
    {
        if (inny.CompareTag("Player"))
        {
            otwieranie = false;
            StartCoroutine(PoruszDrzwi());
        }
    }

    private IEnumerator PoruszDrzwi()
    {
        while (true)
        {
            Transform cel = otwieranie ? punktOtwarcia : punktZamkniecia;
            transform.position = Vector3.MoveTowards(transform.position, cel.position, predkoscDrzwi * Time.deltaTime);

            if (transform.position == cel.position)
                yield break;

            yield return null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformaWaypoints : MonoBehaviour
{
    public List<Transform> punktyTrasy;  
    public float predkoscPlatformy = 2f; 
    private int obecnyPunkt = 0;
    private bool doPrzodu = true; 

    private void Start()
    {
        if (punktyTrasy.Count > 0)
        {
            transform.position = punktyTrasy[obecnyPunkt].position;
            StartCoroutine(PoruszPlatforme());
        }
    }

    private IEnumerator PoruszPlatforme()
    {
        while (true)
        {
            Transform cel = punktyTrasy[obecnyPunkt];
            transform.position = Vector3.MoveTowards(transform.position, cel.position, predkoscPlatformy * Time.deltaTime);

            if (transform.position == cel.position)
            {
                if (doPrzodu)
                {
                    obecnyPunkt++;
                    if (obecnyPunkt >= punktyTrasy.Count)
                    {
                        obecnyPunkt = punktyTrasy.Count - 2;
                        doPrzodu = false;
                    }
                }
                else
                {
                    obecnyPunkt--;
                    if (obecnyPunkt < 0)
                    {
                        obecnyPunkt = 1;
                        doPrzodu = true;
                    }
                }
            }

            yield return null;
        }
    }
}

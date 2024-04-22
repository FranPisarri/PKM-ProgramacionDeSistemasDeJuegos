using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteChange: MonoBehaviour
{

    [SerializeField] GameObject NewRoute;
    [SerializeField] GameObject OldRoute;
    [SerializeField] GameObject[] NewChangeRoutes;
    [SerializeField] GameObject[] OldChangeRoutes;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        NewRoute.gameObject.SetActive(true);
        OldRoute.gameObject.SetActive(false);
        for (int i = 0; i < NewChangeRoutes.Length; i++)
        {
            NewChangeRoutes[i].gameObject.SetActive(true);
        }
        for (int i = 0; i < OldChangeRoutes.Length; i++)
        {
            OldChangeRoutes[i].gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
    }
}

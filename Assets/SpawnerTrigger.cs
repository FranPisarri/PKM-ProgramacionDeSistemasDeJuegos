using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.GetComponent<Spawner>().enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        gameObject.GetComponent<Spawner>().enabled = false;
    }
}

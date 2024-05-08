using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    public GameObject player;
    public GameObject[] zones;
    public GameObject[] newTriggers;
    public GameObject oldTriggers;



    private void Start()
    {
        player = MovPlayer.Instance.gameObject;
        if (player.transform.position.y > 7.7f)
        {
            oldTriggers.SetActive(false);
            zones[0].SetActive(false);
            newTriggers[2].SetActive(true);
            zones[2].SetActive(true);
        }else if (player.transform.position.y > 1.1f)
        {
            oldTriggers.SetActive(false);
            zones[0].SetActive(false);
            newTriggers[1].SetActive(true);
            zones[1].SetActive(true);
        }
    }
}

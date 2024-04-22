using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorChange : MonoBehaviour
{
    public Vector3 NewPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MovPlayer.Instance.SetPosition(NewPosition);

    }
}

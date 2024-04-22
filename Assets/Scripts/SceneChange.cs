using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChange : MonoBehaviour
{
    public Vector3 NewPosition;
    public string sceneName;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        MovPlayer.Instance.SetPosition(NewPosition);
        SceneManager.LoadScene(sceneName);

    }
}
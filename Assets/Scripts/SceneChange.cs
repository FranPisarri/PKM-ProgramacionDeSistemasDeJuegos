using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChange : MonoBehaviour, I_Interactable
{
    public Vector3 NewPosition;
    public string sceneName;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.LoadNewScene(NewPosition, sceneName);
        //MovPlayer.Instance.SetPosition(NewPosition);
        //SceneManager.LoadScene(sceneName);

    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MjsInicio : MonoBehaviour
{
    public GameObject textMeshPro;
    public TextMeshProUGUI mjs;

    float time = 0;
    float timer1 = 3;
    float timer2 = 6;
    void Start()
    {
        if (GameManager.Instance.ShowMjs)
        {
            GameManager.Instance.ShowMjs = false;
            
            mjs.text = "Explora este mundo sin humanos y encuentra sus secretos";
        }
        else
        {
            Destroy(textMeshPro);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time >= timer1)
        {
            mjs.text = "Ten cuidado con los peligros de estas tierras...Suerte";
        }
        if (time >= timer2)
        {
            MovPlayer.Instance.gameObject.GetComponent<InputManager>().enabled = true;
            Destroy(textMeshPro);
            Destroy(gameObject);
        }
        
    }
}

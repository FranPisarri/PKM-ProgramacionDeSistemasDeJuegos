using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPKMMenu : MonoBehaviour
{
    [SerializeField] private GameObject battleButtons;
    [SerializeField] private GameObject changePKMButtons;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangeToBattleMenu();
        }
    }
    public void ChangeToBattleMenu()
    {
        battleButtons.SetActive(true);
        changePKMButtons.SetActive(false);
    }

}

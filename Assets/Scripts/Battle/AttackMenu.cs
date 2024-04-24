using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMenu : MonoBehaviour
{
    [SerializeField] private GameObject battleButtons;
    [SerializeField] private GameObject attackButtons;


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
        attackButtons.SetActive(false);
    }
}

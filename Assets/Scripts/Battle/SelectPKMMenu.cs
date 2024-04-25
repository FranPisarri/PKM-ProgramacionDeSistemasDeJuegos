using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPKMMenu : MonoBehaviour
{
    [SerializeField] private GameObject battleButtons;
    [SerializeField] private GameObject changePKMButtons;

    [SerializeField] private GameObject playerHealthShow;
    [SerializeField] private GameObject enemyHealthShow;

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
        playerHealthShow.SetActive(true);
        enemyHealthShow.SetActive(true);
        changePKMButtons.SetActive(false);
    }

}

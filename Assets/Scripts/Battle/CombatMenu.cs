using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMenu : MonoBehaviour
{
    [SerializeField] private GameObject battleButtons;
    [SerializeField] private GameObject attackButtons;
    [SerializeField] private GameObject changePKMButtons;

    [SerializeField] private GameObject playerHealthShow;
    [SerializeField] private GameObject enemyHealthShow;
    
    public void ChangeToAttackMenu()
    {
        attackButtons.SetActive(true);
        battleButtons.SetActive(false);
    }

    public void ChangeToSelectPKM()
    {
        changePKMButtons.SetActive(true);
        playerHealthShow.SetActive(false);
        enemyHealthShow.SetActive(false);
        battleButtons.SetActive(false);
    }
}

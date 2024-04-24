using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMenu : MonoBehaviour
{
    [SerializeField] private GameObject battleButtons;
    [SerializeField] private GameObject attackButtons;
    [SerializeField] private GameObject changePKMButtons;
    
    public void ChangeToAttackMenu()
    {
        attackButtons.SetActive(true);
        battleButtons.SetActive(false);
    }

    public void ChangeToSelectPKM()
    {
        changePKMButtons.SetActive(true);
        battleButtons.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokemonInBattleManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyPokemons = new List<GameObject>();
    [SerializeField] private List<GameObject> myPokemons = new List<GameObject>();
    public int enemyInBattle = 0;
    public int allyInBattle = 0;
    [SerializeField] private Slider enemyHealthBar;
    [SerializeField] private Slider allyHealthBar;

    public List<GameObject> EnemyPokemons => enemyPokemons;
    public List<GameObject> MyPokemons => myPokemons;

    [SerializeField] private Transform enemyPosition;
    [SerializeField] private Transform allyPosition;
    
    
    public void AddNewEnemy(GameObject enemy)
    {
        enemyPokemons.Add(Instantiate(enemy, enemyPosition));
    }

    public void AddNewAlly(GameObject ally)
    {
       myPokemons.Add(Instantiate(ally, allyPosition));
    }

    
    public void ChangeEnemyPKM(int pokeballIndex)
    {
        if (pokeballIndex < 0 || pokeballIndex > 5)
        {
            Debug.Log("No existe esta pokeball");
            return;
        }
        if (enemyPokemons[pokeballIndex].GetComponent<Pokemon>().CurrentHp > 0)
        {
            foreach (GameObject ally in enemyPokemons)
            {
                ally.SetActive(false);
            }
            enemyPokemons[pokeballIndex].SetActive(true);
            enemyHealthBar.value = enemyPokemons[pokeballIndex].GetComponent<Pokemon>().CurrentHp / enemyPokemons[pokeballIndex].GetComponent<Pokemon>().Stats[0];
            enemyInBattle = pokeballIndex;
            BattleManager.instance.EnemyPKM = enemyPokemons[pokeballIndex];
        }
        else
        {
            Debug.Log("Es pokemon está debilitado");
        }
    }

    public void ChangeAllyPKM(int pokeballIndex)
    {
        if (pokeballIndex < 0 || pokeballIndex > 5)
        {
            Debug.Log("No existe esta pokeball");
            return;
        }
        if (myPokemons[pokeballIndex].GetComponent<Pokemon>().CurrentHp > 0)
        {
            foreach (GameObject ally in myPokemons)
            {
                ally.SetActive(false);
            }
            myPokemons[pokeballIndex].SetActive(true);
            allyHealthBar.value = myPokemons[pokeballIndex].GetComponent<Pokemon>().CurrentHp / myPokemons[pokeballIndex].GetComponent<Pokemon>().Stats[0];
            allyInBattle = pokeballIndex;
            BattleManager.instance.AllyPKM = myPokemons[pokeballIndex];
        }
        else
        {
            Debug.Log("Es pokemon está debilitado");
        }
    }

    public void ModifyEnemyHealthBar()
    {
        enemyHealthBar.value -= 1 / enemyPokemons[enemyInBattle].GetComponent<Pokemon>().Stats[0];
    }
    
    public void ModifyAllyHealthBar()
    {
        allyHealthBar.value -= 1 / myPokemons[allyInBattle].GetComponent<Pokemon>().Stats[0];
    }
}

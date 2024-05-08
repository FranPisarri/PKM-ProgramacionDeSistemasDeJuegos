using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonInBattleManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyPokemons = new List<GameObject>();
    [SerializeField] private List<GameObject> myPokemons = new List<GameObject>();
    private int pkmInBattle = 0;
    private GameObject spawnedEnemy = null;
    private GameObject spawnedAlly = null;

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
        }
        else
        {
            Debug.Log("Es pokemon está debilitado");
        }
    }


}

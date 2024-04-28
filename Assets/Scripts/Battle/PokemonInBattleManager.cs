using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonInBattleManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyPokemons = new List<GameObject>();
    [SerializeField] private List<GameObject> myPokemons = new List<GameObject>();

    public List<GameObject> EnemyPokemons => enemyPokemons;
    public List<GameObject> MyPokemons => myPokemons;

    [SerializeField] private Transform enemyPosition;
    [SerializeField] private Transform allyPosition;

    public void SpawnEnemy()
    {
        GameObject newPKM = Instantiate(enemyPokemons[0]);
        newPKM.transform.position = enemyPosition.position;
    }

    public void SpawnAlly(int value)
    {
        GameObject newPKM = Instantiate(myPokemons[value], allyPosition);
        newPKM.transform.position = allyPosition.position;
    }
    public void AddNewEnemy(GameObject enemy)
    {
        enemyPokemons.Add(enemy);
    }

    public void AddNewAlly(GameObject ally)
    {
       myPokemons.Add(ally);
    }

    public void KillEnemy(GameObject enemy)
    {
        enemyPokemons.Remove(enemy);
    }
    
    public void KillAlly(GameObject ally)
    {
        myPokemons.Remove(ally);
    }
}

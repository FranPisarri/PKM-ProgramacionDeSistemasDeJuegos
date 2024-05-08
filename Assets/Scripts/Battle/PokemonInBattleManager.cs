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
        enemyPokemons.Add(enemy);
    }

    public void AddNewAlly(GameObject ally)
    {
       myPokemons.Add(ally);
    }

    public void SpawnEnemy()
    {
        spawnedEnemy = Instantiate(enemyPokemons[0], enemyPosition);
    }

    public void SpawnAlly(int value)
    {
        spawnedAlly = Instantiate(myPokemons[value], allyPosition);
        pkmInBattle = value;
        myPokemons[value] = null;
    }
    
    public void ChangeEnemyPKM()
    {

    }

    public void ChangeAllyPKM(int pokeballIndex)
    {
        if (pokeballIndex < 0 || pokeballIndex > 5)
        {
            Debug.Log("No existe esta pokeball");
            return;
        }

        myPokemons[pkmInBattle]/*.GetComponent<Pokemon>().currentHp */= spawnedAlly/*.GetComponent<Pokemon>().currentHp*/;
        KillAlly(spawnedAlly);
        SpawnAlly(pokeballIndex);

    }

    public void KillEnemy(GameObject enemy)
    {
        Destroy(enemy);
        enemyPokemons.RemoveAt(0);
    }
    
    public void KillAlly(GameObject ally)
    {
        Destroy(ally);
        
        //myPokemons.Remove(ally);
    }



    float time = 0;
    private void Update()
    {
        time += Time.deltaTime;
        if (time > 2)
        {
            time = 0;
            //Debug.Log(eso.GetComponent<Pokemon>().IsMyPokemon);
        }
        
    }
}

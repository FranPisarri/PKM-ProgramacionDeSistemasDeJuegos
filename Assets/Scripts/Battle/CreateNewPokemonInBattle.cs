using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewPokemonInBattle : MonoBehaviour
{
    private GameManager gameManager;

    //[SerializeField] private Vector2 enemyPosition;
    [SerializeField] private PokemonInBattleManager pokeManager;

    
    void Start()
    {
        gameManager = GameManager.Instance;

        if ( gameManager.IsRandomEncounter)
        {
            GenerateRandomEncounter();
        }
        else
        {
            GenerateTrainerBattle();
        }

        GenerateMyPokemons();
        
    }

    private void GenerateRandomEncounter()
    {
        GameObject newEnemyPokemon = PokemonFactory.Instance.GenerateNewPokemon(gameManager.IdNewPokemon, gameManager.LvlNewPokemon);
        pokeManager.AddNewEnemy(newEnemyPokemon);
        pokeManager.ChangeEnemyPKM(0);
    }

    private void GenerateTrainerBattle()
    {
        for (int i = 0; i < gameManager.EnemyPokemons.Length; i++)
        {
            GameObject newPKM = gameManager.EnemyPokemons[i];
            pokeManager.AddNewEnemy(newPKM);
        }
    }

    private void GenerateMyPokemons()
    {
        GameObject newEnemyPokemon = PokemonFactory.Instance.GenerateSpecificPokemon(GameManager.Instance.AllyPokemons, GameManager.Instance.MyLVL);
        pokeManager.AddNewAlly(newEnemyPokemon);
        pokeManager.ChangeAllyPKM(0);
    }
}

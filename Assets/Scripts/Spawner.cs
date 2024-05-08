using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{

    [SerializeField] private PokedexID[] routePokemons;
    [SerializeField] private int maxLevel = 100;
    [SerializeField] private int minLevel = 1;
    void Start()
    {
        MovPlayer.Instance.Walk.AddListener(SpawnPokemon);
    }

    // Update is called once per frame
    private void SpawnPokemon()
    {
        Debug.Log("Entra aca");
        //10 % de probabilidad de que apareca algún pokemon
        int chance = Random.Range(0, 10);
        if (chance < 1)
        {
            GameManager.Instance.IsRandomEncounter = true;
            int id = Random.Range(0, routePokemons.Length);
            int lvl = Random.Range(minLevel, maxLevel + 1);
            GameManager.Instance.SetNewPokemonParameters(routePokemons[id], lvl);
            MovPlayer.Instance.gameObject.GetComponent<InputManager>().enabled = false;
            GameManager.Instance.LoadNewScene(MovPlayer.Instance.gameObject.transform.position, "Battle");
            //PokemonFactory.Instance.GeneratePokemon(routePokemons[id], lvl);
        }

    }
}

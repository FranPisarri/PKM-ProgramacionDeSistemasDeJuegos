using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonFactory : MonoBehaviour
{
    public static PokemonFactory Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            PokemonFactory.Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField] private GameObject[] pokemons;

    public GameObject GenerateNewPokemon(PokedexID id, int lvl)
    {
        GameObject newPokemon = pokemons[(int)id];
        
        newPokemon.GetComponent<Pokemon>().SetStats(lvl);
        newPokemon.GetComponent<Pokemon>().IsMyPokemon = false;
        
        return newPokemon;
    }

    public GameObject GenerateSpecificPokemon(PokedexID id, int lvl)
    {
        GameObject newPokemon = pokemons[(int)id];

        Pokemon pokemon = newPokemon.GetComponent<Pokemon>();
        pokemon.SetStats(lvl);

        return newPokemon;
    }
}


public enum PokedexID
{
    Bulbasaur,
    Ivisaur,
    Venusaur,
    Charmander,
    Charmeleon,
    Charizard,
    Squirtle,
    Wartortle,
    Blastoise,
    Caterpie,
    Metapod,
    Buterfree,
    Weedle,
    Kakuna,
    Beedrill,
    Pidgey,
    Pidgeotto,
    Pidgeot,
    Rattata,
    Raticate,
    Spearow,
    Fearow,
    Ekans,
    Arbok,
    Pikachu,
    Raichu
}
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

    public GameObject GenerateNewPokemon(PokedexID id, int lvl, Vector2 position)
    {
        GameObject newPokemon = Instantiate(pokemons[(int)id]);

        newPokemon.GetComponent<Pokemon>().SetStats(lvl);
        newPokemon.GetComponent<Pokemon>().SetRandomMoves();
        newPokemon.transform.position = position;

        return newPokemon;
    }

    public void GenerateSpecificPokemon(PokedexID id, int lvl, Vector2 position, int[] moves)
    {
        GameObject newPokemon = pokemons[(int)id];
        Pokemon pokemon = newPokemon.GetComponent<Pokemon>();

        pokemon.SetStats(lvl);
        newPokemon.transform.position = position;
        for (int i = 0; i < moves.Length; i++)
        {
            pokemon.SetMoves(i, pokemon.PokemonData.Moves[moves[i]]);
        }

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
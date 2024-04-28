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

    public void GeneratePokemon(PokedexID id, int lvl)
    {
        GameObject newPokemon = Instantiate(pokemons[(int)id]);

        newPokemon.GetComponent<Pokemon>().SetStats(lvl);
        newPokemon.GetComponent<Pokemon>().SetRandomMoves();

        //Pokemon details = newPokemon.GetComponent<Pokemon>();
        //details.SetStats(lvl);
        //details.SetRandomMoves();

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
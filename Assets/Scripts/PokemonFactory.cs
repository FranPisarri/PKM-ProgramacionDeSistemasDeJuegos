using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonFactory : MonoBehaviour
{
    public static PokemonFactory Instance;

    [SerializeField] private GameObject[] pokemons;

    public GameObject GeneratePokemon(PokedexID id, int lvl)
    {
        GameObject newPokemon = pokemons[(int)id];
        Pokemon details = newPokemon.GetComponent<Pokemon>();
        details.SetStats(lvl);
        details.SetRandomMoves();

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
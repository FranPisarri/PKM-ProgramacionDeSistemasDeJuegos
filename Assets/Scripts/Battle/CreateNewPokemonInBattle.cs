using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewPokemonInBattle : MonoBehaviour
{
    private GameManager gameManager;

    
    void Start()
    {
        gameManager = GameManager.Instance;

        PokemonFactory.Instance.GeneratePokemon(gameManager.IdNewPokemon, gameManager.LvlNewPokemon);
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerPrueba : MonoBehaviour
{
    public GameObject pkm;
    [SerializeField] private PokemonInBattleManager pokeManager;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            pkm = PokemonFactory.Instance.GenerateSpecificPokemon(PokedexID.Charmander, 2, new int[1]);
            pkm = PokemonFactory.Instance.GenerateNewPokemon(/*GameManager.Instance.IdNewPokemon*/ PokedexID.Charmander, GameManager.Instance.LvlNewPokemon);
            pokeManager.AddNewEnemy(pkm);
            pokeManager.ChangeEnemyPKM(0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //PokemonFactory.Instance.GeneratePokemon(PokedexID.Charmander, 2);
    }
 

}

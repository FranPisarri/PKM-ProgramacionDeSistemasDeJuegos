using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonTeam : MonoBehaviour
{
    [SerializeField] private List<PokedexID> myTeam = new();
    [SerializeField] private List<Vector2Int> lvl_currentHp = new();
    public List<PokedexID> MyTeam => myTeam;

    public void NewPokemonInTeam(PokedexID newPokemon, int lvl)
    {
        myTeam.Add(newPokemon);
        lvl_currentHp.Add(new Vector2Int(lvl, 0));
    }

    public void BattleFinishedUpdatte(List<GameObject> updatedTeam)
    {
        for (int i = 0; i < myTeam.Count; i++)
        {
            lvl_currentHp[i] = new Vector2Int(updatedTeam[i].GetComponent<Pokemon>().Lvl, updatedTeam[i].GetComponent<Pokemon>().CurrentHp);
        }
    }
}

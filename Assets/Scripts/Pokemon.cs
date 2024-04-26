using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pokemon : MonoBehaviour
{
    [SerializeField] private PokemonData pokemonData;
    [SerializeField] private int lvl = 1;
    [SerializeField] private int[] stats = new int[6];
    [SerializeField] private MovesData[] movesDatas = new MovesData[4];

    void Start()
    {
        SetStats(lvl);
    }


    public void SetStats(int level)
    {
        lvl = level;
        for (int i = 0; i < stats.Length; i++)
        {
            stats[i] = pokemonData.BasicStats[i] + (lvl - 1) * pokemonData.StatsXLvl[i];
        }
    }

    public void SetRandomMoves()
    {
        List<MovesData> moves = new List<MovesData>();
        for (int i = 0; i < pokemonData.Moves.Length; i++)
        {
            if (pokemonData.LvlToLernMove[i] > lvl)
            {
                moves.Add(pokemonData.Moves[i]);
            }
        }

        //Randomizado de lista
        moves = moves.OrderBy( x => Random.value).ToList();

        int range = moves.Count;
        if (range > 4)
        {
            for (int i = 0; i< 4; i++)
            {
                SetMoves(i, moves[i]);
            }
        }
        else
        {
            for (int i = 0; i < range; i++)
            {
                SetMoves(i, moves[i]);
            }
        }
    }

    public void SetMoves(int position, MovesData move)
    {
        movesDatas[position] = move;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Pokemon : MonoBehaviour
{
    [SerializeField] private PokemonData pokemonData;
    [SerializeField] private int lvl = 1;
    [SerializeField] private int[] stats = new int[4];
    [SerializeField] private int currentHp;

    [SerializeField] private Animator animator;
    private bool isMyPokemon;
    private bool isAttacking;

    public int Lvl { get => lvl; set => lvl = value; }
    public int[] Stats => stats;
    public int CurrentHp { get => currentHp; set => currentHp = value; }
    public bool IsMyPokemon { get { return isMyPokemon; } set { isMyPokemon = value; } }
    public bool IsAttacking { get { return isAttacking; } set { isAttacking = value; } }
    public PokemonData PokemonData => pokemonData;

    public UnityEvent OnPokemonDead = new UnityEvent();
    
    void Start()
    {
        SetStats(lvl);
        SetAnimation(isMyPokemon);
    }

    public void SetStats(int level)
    {
        lvl = level;
        for (int i = 0; i < stats.Length; i++)
        {
            stats[i] = pokemonData.BasicStats[i] + (lvl - 1) * pokemonData.StatsXLvl[i];
        }
        if (currentHp == 0)
        {
            currentHp = stats[0];
        }
    }

    public void SetAnimation( bool isMyPKM)
    {
        //animator.runtimeAnimatorController = pokemonData.Meshes.PKMAnimation;
        if(isMyPKM)
        {
            animator.SetBool("IsMyPKM", true);
        }
        else
        {
            animator.SetBool("IsMyPKM", false);
        }
    }

    public void Changeanimation(bool isAtacking)
    {
        if(isAtacking)
        {
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }

    public int GetDamage()
    {
        return (int)(stats[1] * 0.5);
    }

    public void RecivedDamage(int damage)
    {
        damage = (int)(damage * (1 - stats[2]/500));
        currentHp -= damage;
        if (currentHp < 0)
        {
            OnPokemonDead.Invoke();
        }
    }
}

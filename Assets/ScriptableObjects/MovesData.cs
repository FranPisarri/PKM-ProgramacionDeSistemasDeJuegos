using UnityEngine;

[CreateAssetMenu(fileName = "NewMoveData", menuName = "Data/MovesData")]

public class MovesData : ScriptableObject
{
    [SerializeField] private PokemonTypeData type;
    [SerializeField] private bool dealsDamage;
    [SerializeField] private int damageDeal;
    [SerializeField] private bool healsDamage;
    [SerializeField] private int damageHeal;
    [SerializeField] private bool reduceStats;
    [SerializeField] private Stats statsToReduce;
    [SerializeField] private bool aumentStats;
    [SerializeField] private Stats statsToAument;

    public PokemonTypeData Type => type;
    public bool DealsDamage => dealsDamage;
    public int DamageDeal => damageDeal;
    public bool HealsDamage => healsDamage;
    public int DamageHeal => damageHeal;
    public bool ReduceStats => reduceStats;
    public Stats StatsToReduce => statsToReduce;
    public bool AumentStats => aumentStats;
    public Stats StatsToAument => statsToAument;
}

public enum Stats
{
    Health,
    Attack,
    Defence,
    SpecialAttack,
    SpecialDefence,
    Speed
}

using UnityEngine;

[CreateAssetMenu(fileName = "NewMoveData", menuName = "Data/MovesData")]

public class MovesData : ScriptableObject
{
    [SerializeField] private PokemonTypeData type;
    [SerializeField] private MoveTypeData moveType;
    [SerializeField] private Objetive objetive;
    [SerializeField] private Stats statsAffected;

    public PokemonTypeData Type => type;
    public MoveTypeData MoveTypeData => moveType;
    public Objetive Objetive => objetive;
    public Stats StatsAffected => statsAffected;
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

public enum Objetive
{
    None,
    Player,
    Enemy
}

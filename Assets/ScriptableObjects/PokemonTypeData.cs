using UnityEngine;

[CreateAssetMenu(fileName = "NewPokemonTypeData", menuName = "Data/PokemonTypeData")]

public class PokemonTypeData : ScriptableObject
{
    [SerializeField] private PokemonTypeData typeWeakness;

    public PokemonTypeData TypeWeakness => typeWeakness;

}

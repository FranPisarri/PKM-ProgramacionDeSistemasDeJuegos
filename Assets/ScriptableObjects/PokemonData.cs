using UnityEngine;

[CreateAssetMenu(fileName = "NewPokemonData", menuName = "Data/PokemonData")]

public class PokemonData : ScriptableObject
{
    [SerializeField] private PokemonTypeData type;              //Tipo
    [SerializeField] private int[] basicStats = new int[4];     //Stats lvl 1 HP-ATK-DEFF-VEL
    [SerializeField] private int[] statsXLvl = new int[4];      //Stats x lvl HP-ATK-DEFF-VEL
    [SerializeField] private PokemonMeshesData meshes;          //All mesh
    [SerializeField] private int evolveLvl;                     //Lvl to evlove (if the pokemon does not evolve select 101)


    public PokemonTypeData Type => type;
    public int[] BasicStats => basicStats;
    public int[] StatsXLvl => statsXLvl;
    public PokemonMeshesData Meshes => meshes;
}

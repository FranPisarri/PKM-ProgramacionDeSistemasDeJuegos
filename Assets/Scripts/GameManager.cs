using UnityEditor.Search;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool ShowMjs = true;

    private PokedexID idNewPokemon;
    public PokedexID IdNewPokemon => idNewPokemon;

    private int lvlNewPokemon;
    public int LvlNewPokemon => lvlNewPokemon;

    [SerializeField] private GameObject[] enemyPokemons;
    [SerializeField] private PokedexID allyPokemons;
    [SerializeField] private int myLVL;


    public GameObject[] EnemyPokemons => enemyPokemons;
    public PokedexID AllyPokemons => allyPokemons;
    public int MyLVL { get => myLVL; set => myLVL = value; }

    private bool isRandomEncounter = false;
    public bool IsRandomEncounter { get { return isRandomEncounter; } set { isRandomEncounter = value; } }

    

    private void Awake()
    {
        if (Instance == null)
        {
            GameManager.Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    

    public void LoadNewScene(Vector3 NewPosition, string sceneName)
    {
        MovPlayer.Instance.SetPosition(NewPosition);
        SceneManager.LoadScene(sceneName);
    }

    public void SetNewPokemonParameters(PokedexID id, int lvl)
    {
        idNewPokemon = id;
        lvlNewPokemon = lvl;
        //PokemonFactory.Instance.GeneratePokemon(id, lvl);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private PokedexID idNewPokemon;
    public PokedexID IdNewPokemon => idNewPokemon;

    private int lvlNewPokemon;
    public int LvlNewPokemon => lvlNewPokemon;

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

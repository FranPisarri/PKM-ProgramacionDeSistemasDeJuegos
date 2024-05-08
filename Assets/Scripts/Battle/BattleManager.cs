using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField] private GameObject enemyPKM;
    [SerializeField] private GameObject allyPKM;
    [SerializeField] private GameObject mjsTab;
    [SerializeField] private Button[] basicButtons;
    [SerializeField] private GameObject battleState;
    [SerializeField] private GameObject changePKMState;
    [SerializeField] private PokemonInBattleManager pkmInBattleManager;

    public GameObject EnemyPKM { get => enemyPKM; set => enemyPKM = value; }
    public GameObject AllyPKM { get => allyPKM; set => allyPKM = value; }

    public void Attack()
    {
        var attackCommand = new AttackCommand(enemyPKM, allyPKM);
        Event_Queue.Instance.QueueCommand(attackCommand);
    }

    bool a = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            a = true;
        }
        else
        {
            a = false;
        }
    }
    private bool NextPressed()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public IEnumerator EnemyAttack(bool attackFirst)
    {
        Debug.Log("siiiiii");
        foreach (Button button in basicButtons)
        {
            button.enabled = false;
        }
        mjsTab.SetActive(true);
        mjsTab.GetComponentInChildren<TextMeshProUGUI>().text = enemyPKM.name + " te ataca.";
        yield return new WaitUntil(NextPressed);
        enemyPKM.GetComponent<Pokemon>().ChangeAttackState();
        yield return new WaitForSeconds(enemyPKM.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        enemyPKM.GetComponent<Pokemon>().ChangeAttackState();
        allyPKM.GetComponent<Pokemon>().RecivedDamage(enemyPKM.GetComponent<Pokemon>().GetDamage());
        for (int i = 0; i < enemyPKM.GetComponent<Pokemon>().GetDamage(); i++)
        {
            pkmInBattleManager.ModifyAllyHealthBar();
            yield return new WaitForSeconds(0.1f);
        }
        mjsTab.GetComponentInChildren<TextMeshProUGUI>().text = allyPKM.name + " recibió " + enemyPKM.GetComponent<Pokemon>().GetDamage() + " de daño";
        yield return new WaitUntil(NextPressed);
        if (allyPKM.GetComponent<Pokemon>().CurrentHp < 0)
        {
            mjsTab.GetComponentInChildren<TextMeshProUGUI>().text = allyPKM.name + " está debilitado.";
            yield return new WaitUntil(NextPressed);
            foreach (Button button in basicButtons)
            {
                button.enabled = true;
            }
            if (pkmInBattleManager.MyPokemons.Count - 1 > pkmInBattleManager.allyInBattle)
            {
                battleState.SetActive(false);
                changePKMState.SetActive(true);
            }
            else
            {
                MovPlayer.Instance.gameObject.GetComponent<InputManager>().enabled = true;
                GameManager.Instance.LoadNewScene(MovPlayer.Instance.gameObject.transform.position, "MapaExterior1");
                StopAllCoroutines();
            }
            
            //MUERTE
        }
        else if (attackFirst)
        {
            yield return StartCoroutine(AllyAttack(false));
        }
        else
        {
            foreach (Button button in basicButtons)
            {
                button.enabled = true;
            }
        }
        
    }
    
    public IEnumerator AllyAttack(bool attackFirst)
    {
        Debug.Log("seeeeeee");
        foreach (Button button in basicButtons)
        {
            button.enabled = false;
        }
        mjsTab.SetActive(true);
        mjsTab.GetComponentInChildren<TextMeshProUGUI>().text = allyPKM.name + " ataca.";
        yield return new WaitUntil(NextPressed);
        allyPKM.GetComponent<Pokemon>().ChangeAttackState();
        yield return new WaitForSeconds(allyPKM.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        allyPKM.GetComponent<Pokemon>().ChangeAttackState();
        enemyPKM.GetComponent<Pokemon>().RecivedDamage(allyPKM.GetComponent<Pokemon>().GetDamage());
        for (int i = 0; i < allyPKM.GetComponent<Pokemon>().GetDamage(); i++)
        {
            pkmInBattleManager.ModifyEnemyHealthBar();
            yield return new WaitForSeconds(0.1f);
        }
        mjsTab.GetComponentInChildren<TextMeshProUGUI>().text = enemyPKM.name + " recibió " + allyPKM.GetComponent<Pokemon>().GetDamage() + " de daño";
        yield return new WaitUntil(NextPressed);
        if (enemyPKM.GetComponent<Pokemon>().CurrentHp < 0)
        {
            mjsTab.GetComponentInChildren<TextMeshProUGUI>().text = enemyPKM.name + " está debilitado.";
            yield return new WaitUntil(NextPressed);
            foreach (Button button in basicButtons)
            {
                button.enabled = true;
            }
            if (pkmInBattleManager.EnemyPokemons.Count - 1 > pkmInBattleManager.enemyInBattle)
            {
                pkmInBattleManager.ChangeEnemyPKM(pkmInBattleManager.enemyInBattle + 1);
            }
            else
            {
                MovPlayer.Instance.gameObject.GetComponent<InputManager>().enabled = true;
                GameManager.Instance.LoadNewScene(MovPlayer.Instance.gameObject.transform.position, "MapaExterior1");
                StopAllCoroutines();
            }
            
            //MUERTE
        }
        else if (attackFirst)
        {
            yield return StartCoroutine(EnemyAttack(false));
        }
        else
        {
            foreach (Button button in basicButtons)
            {
                button.enabled = true;
            }
        }
    }
}

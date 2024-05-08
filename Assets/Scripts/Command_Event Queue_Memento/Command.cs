using UnityEngine;

public interface ICommand
{
    public void Execute();
}

public class MovementCommand : ICommand
{
    private UnityEngine.Transform myPosition;
    private Vector3 movePointPosition;
    private float speed;
    private float deltaTime;

    public MovementCommand(UnityEngine.Transform myPosition, Vector3 movePointPosition, float speed, float deltaTime)
    {
        this.myPosition = myPosition;
        this.movePointPosition = movePointPosition;
        this.speed = speed;
        this.deltaTime = deltaTime;
    }

    public void Execute()
    {
        myPosition.position = Vector3.MoveTowards(myPosition.position, movePointPosition, speed * deltaTime);
    }
}

public class AttackCommand : ICommand
{
    private GameObject currentEnemy;
    private GameObject currentAlly;

    public AttackCommand(GameObject currentEnemy, GameObject currentAlly)
    {
        this.currentEnemy = currentEnemy;
        this.currentAlly = currentAlly;
    }

    private void EnemyAttack(Pokemon enemyPokemon, Pokemon allyPokemon)
    {
        allyPokemon.RecivedDamage(enemyPokemon.GetDamage());
    }

    private void AllyAttack(Pokemon enemyPokemon, Pokemon allyPokemon)
    {
        enemyPokemon.RecivedDamage(allyPokemon.GetDamage());
    }

    public void Execute()
    {
        Pokemon enemyPokemon = currentEnemy.GetComponent<Pokemon>();
        Pokemon allyPokemon = currentAlly.GetComponent<Pokemon>();
        if (enemyPokemon.Stats[3] > allyPokemon.Stats[3])
        {
            EnemyAttack(enemyPokemon, allyPokemon);
            AllyAttack(enemyPokemon, allyPokemon);
        }
        else
        {
            AllyAttack(enemyPokemon, allyPokemon);
            EnemyAttack(enemyPokemon, allyPokemon);
        }

    }
}
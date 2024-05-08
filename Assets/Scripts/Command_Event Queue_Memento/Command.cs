using System;
using System.Collections;
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

    public void Execute()
    {
        if (currentEnemy.GetComponent<Pokemon>().Stats[3] > currentAlly.GetComponent<Pokemon>().Stats[3])
        {
            BattleManager.instance.StartCoroutine(BattleManager.instance.EnemyAttack(true));
        }
        else
        {
            BattleManager.instance.StartCoroutine(BattleManager.instance.AllyAttack(true));
        }

    }

}
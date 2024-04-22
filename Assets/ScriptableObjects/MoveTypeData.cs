using UnityEngine;

[CreateAssetMenu(fileName = "NewMoveTypeData", menuName = "Data/MovesTypeData")]

public class MoveTypeData : ScriptableObject
{
    [SerializeField] private int amount;
    public int Amount => amount;
}

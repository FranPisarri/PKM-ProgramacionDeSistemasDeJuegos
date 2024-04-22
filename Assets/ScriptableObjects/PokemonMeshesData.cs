using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPokemonMeshesData", menuName = "Data/PokemonMeshesData")]

public class PokemonMeshesData : ScriptableObject
{
    [SerializeField] private Sprite frontSprite;
    [SerializeField] private Sprite backSprite;
    [SerializeField] private AnimatorController frontAnimations;
    [SerializeField] private AnimatorController backAnimations;


    public Sprite FrontSprite => frontSprite;
    public Sprite BackSprite => backSprite;
    public AnimatorController IdleAnimation => frontAnimations;
    public AnimatorController AttackAnimation => backAnimations;
    
}

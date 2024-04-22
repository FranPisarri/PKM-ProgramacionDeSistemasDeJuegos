using UnityEngine;

[CreateAssetMenu(fileName = "NewPokemonMeshesData", menuName = "Data/PokemonMeshesData")]

public class PokemonMeshesData : ScriptableObject
{
    [SerializeField] private Sprite frontSprite;
    [SerializeField] private Sprite backSprite;
    [SerializeField] private Animator frontAnimations;
    [SerializeField] private Animator backAnimations;

    [SerializeField] private Animation idleAnimation;
    [SerializeField] private Animation attackAnimation;
    [SerializeField] private Animation damageAnimation;

    public Sprite FrontSprite => frontSprite;
    public Sprite BackSprite => backSprite;
    public Animator IdleAnimation => frontAnimations;
    public Animator AttackAnimation => backAnimations;
    
}

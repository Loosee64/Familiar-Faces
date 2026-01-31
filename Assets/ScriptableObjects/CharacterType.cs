using UnityEngine;

[CreateAssetMenu(fileName = "CharacterType", menuName = "Scriptable Objects/CharacterType")]
public class CharacterType : ScriptableObject
{
    public string title = "";
    public int maxHealth = 0;
    public int xp = 0;

    // base stats
    public int defense = 1;
    public int attack = 1;
    public int agility = 3;
    public int abilityPoints = 10;
    public int maxAbilityPoints = 10;

    public MaskType mask;
}

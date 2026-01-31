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
    // multipliers
    public float lightMultiplier = 1.0f;
    public float heavyMultiplier = 2.0f;
    public float defenseMultiplier = 1.0f;
    public float attackMultiplier = 1.0f;
    public float agilityMultiplier = 1.0f;

    public MaskType mask;
}

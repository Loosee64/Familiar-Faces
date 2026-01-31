using UnityEngine;

public class CharacterData : MonoBehaviour
{
    [SerializeField]
    CharacterType m_character;

    CharacterType[] m_allTypes;

    int maxHealth;
    int xp;
    string title;
    int defense;
    int attack;
    int agility;
    int abilityPoints;
    int maxAbilityPoints;
    MaskType mask;

    private void Awake()
    {
        maxHealth = m_character.maxHealth;
        title = m_character.title;
        xp = m_character.xp;
        mask = m_character.mask;
        defense = m_character.defense;
        attack = m_character.attack;
        agility = m_character.agility;
        abilityPoints = m_character.abilityPoints;
        maxAbilityPoints = m_character.maxAbilityPoints;
    }

    public void IncreaseMax(int t_level)
    {
        maxHealth = maxHealth + ((maxHealth / 5) * t_level);
    }

    public void NewRandom()
    {
        m_allTypes = Resources.LoadAll<CharacterType>("ScriptableObjects/Characters/Enemy");
        m_character = m_allTypes[Random.Range(0, m_allTypes.Length)];

        maxHealth = m_character.maxHealth;
        title = m_character.title;
    }

    

    public int GetMax() { return maxHealth; }
    public string GetTitle() { return title; }
    public int GetXP() { return xp; }
    public MaskType GetMask() { return mask; }
    public int GetDefense() { return defense; }
    public int GetAttack() { return attack; }
    public int GetAgility() { return agility; }
    public int GetAbilityPoints() { return abilityPoints; }
    public int GetMaxAbilityPoints() { return maxAbilityPoints; }
}

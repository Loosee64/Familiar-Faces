using UnityEngine;

public class CharacterData : MonoBehaviour
{
    [SerializeField]
    CharacterType m_character;

    CharacterType[] m_allTypes;

    int maxHealth;
    int xp;
    string title;

    private void Awake()
    {
        maxHealth = m_character.maxHealth;
        title = m_character.title;
        xp = m_character.xp;
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

}
